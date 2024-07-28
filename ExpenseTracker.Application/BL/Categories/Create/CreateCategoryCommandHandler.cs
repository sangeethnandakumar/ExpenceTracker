using Application.AppDBContext;
using Application.Extenions;
using Domain.Entities;
using FluentValidation;
using FluentValidation.Results;
using LanguageExt.Common;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.BL.Categories.Create
{
    public sealed class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Result<Guid>>
    {
        private readonly ILogger<CreateCategoryCommandHandler> logger;
        private readonly IAppDBContext dbContext;
        private readonly IValidator<CreateCategoryCommand> validator;

        public CreateCategoryCommandHandler(ILogger<CreateCategoryCommandHandler> logger, IAppDBContext dbContext, IValidator<CreateCategoryCommand> validator)
        {
            this.logger = logger;
            this.dbContext = dbContext;
            this.validator = validator;
        }

        public async Task<Result<Guid>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            // Validate the request
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                logger.LogInformation("Validation errors: {@ValidationErrors}", validationResult.ToStandardDictionary());
                return new Result<Guid>(new ValidationException(validationResult.Errors));
            }

            // Decode and compress the image
            var compressedImageId = await ProcessImageAsync(request.CustomImage, cancellationToken);

            // Create and save category
            return await CreateCategoryAsync(request, compressedImageId, cancellationToken);
        }

        private async Task<string> ProcessImageAsync(string customImage, CancellationToken cancellationToken)
        {
            try
            {
                var imageBytes = DecodeBase64Image(customImage);
                var compressedImageData = await ImageProcessingHelper.CompressImageAsync(imageBytes, 16, 4, SixLabors.ImageSharp.Formats.Png.PngBitDepth.Bit8);

                // Create and save compressed image
                var compressedImage = new CompressedImage(Guid.NewGuid().ToString(), compressedImageData);
                await dbContext.Images.AddAsync(compressedImage, cancellationToken);
                await dbContext.SaveChangesAsync(cancellationToken);

                return compressedImage.MapId;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error processing image.");
                return Guid.Empty.ToString();
            }
        }

        private byte[] DecodeBase64Image(string customImage)
        {
            const string base64Prefix = "data:image/png;base64,";
            var base64Data = customImage.AsSpan().Slice(base64Prefix.Length);
            return Convert.FromBase64String(base64Data.ToString());
        }

        private async Task<Result<Guid>> CreateCategoryAsync(CreateCategoryCommand request, string compressedImageId, CancellationToken cancellationToken)
        {
            var category = new Category(
                request.Title,
                request.Text,
                request.Icon,
                request.Color,
                compressedImageId
            );

            // Add category to the database
            await dbContext.Categories.AddAsync(category, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new Result<Guid>(category.Id);
        }
    }
}

using Application.AppDBContext;
using Application.Constants;
using Application.Dtos;
using Application.Extenions;
using AutoMapper;
using FluentValidation;
using LanguageExt.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Globalization;

namespace Application.BL.Tracks.GetAll
{
    public sealed class GetTracksQueryHandler : IRequestHandler<GetTracksQuery, Result<IEnumerable<TrackDto>>>
    {
        private readonly ILogger<GetTracksQueryHandler> logger;
        private readonly IAppDBContext dbContext;
        private readonly IMapper mapper;
        private readonly IValidator<GetTracksQuery> validator;


        public GetTracksQueryHandler(ILogger<GetTracksQueryHandler> logger, IAppDBContext dbContext, IMapper mapper, IValidator<GetTracksQuery> validator)
        {
            this.logger = logger;
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.validator = validator;
        }

        public async Task<Result<IEnumerable<TrackDto>>> Handle(GetTracksQuery request, CancellationToken cancellationToken)
        {
            //Defaulting
            Defaulting(request);

            //Validate
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                logger.LogInformation("Validation errors: {@ValidationErrors}", validationResult.ToStandardDictionary());
                return new Result<IEnumerable<TrackDto>>(new ValidationException(validationResult.Errors));
            }

            //Proceed
            var queryResult = await dbContext.Tracks.Where(x =>
                x.Date <= DateTime.Parse(request.End) && x.Date >= DateTime.Parse(request.Start)
            ).ToListAsync();
            var result = mapper.Map<IEnumerable<TrackDto>>(queryResult);

            //Complete
            return new Result<IEnumerable<TrackDto>>(result);
        }

        private static void Defaulting(GetTracksQuery request)
        {
            if (string.IsNullOrEmpty(request.Start))
            {
                request.Start = DateTime.MinValue.ToString(ValidatorConstants.DATE_FORMAT, CultureInfo.InvariantCulture);
            }
            if (string.IsNullOrEmpty(request.End))
            {
                request.End = DateTime.UtcNow.ToString(ValidatorConstants.DATE_FORMAT, CultureInfo.InvariantCulture);
            }
        }
    }
}

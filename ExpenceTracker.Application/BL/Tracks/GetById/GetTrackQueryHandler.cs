using Application.AppDBContext;
using Application.Dtos;
using Application.Extenions;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using LanguageExt.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Data;

namespace Application.BL.Tracks.GetById
{
    public sealed class GetTrackQueryHandler : IRequestHandler<GetTrackQuery, Result<TrackDto>>
    {
        private readonly ILogger<GetTrackQueryHandler> logger;
        private readonly IAppDBContext dbContext;
        private readonly IMapper mapper;
        private readonly IValidator<GetTrackQuery> validator;


        public GetTrackQueryHandler(ILogger<GetTrackQueryHandler> logger, IAppDBContext dbContext, IMapper mapper, IValidator<GetTrackQuery> validator)
        {
            this.logger = logger;
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.validator = validator;
        }

        public async Task<Result<TrackDto>> Handle(GetTrackQuery request, CancellationToken cancellationToken)
        {
            //Validate
            var validationResult = await validator.ValidateAsync(request, cancellationToken);


            if (!validationResult.IsValid)
            {
                logger.LogInformation("Validation errors: {@ValidationErrors}", validationResult.ToStandardDictionary());
                return new Result<TrackDto>(new ValidationException(validationResult.Errors));
            }


            //Proceed
            var queryResult = await dbContext.Tracks.FirstOrDefaultAsync(x => x.Id == Guid.Parse(request.Id));
            if (queryResult is null)
            {
                logger.LogInformation("No data found for id: {@Id}", request.Id);
                return new Result<TrackDto>(new DataException($"No data found for id: {request.Id}"));
            }
            var result = mapper.Map<TrackDto>(queryResult);

            //Complete
            return result;
        }
    }
}

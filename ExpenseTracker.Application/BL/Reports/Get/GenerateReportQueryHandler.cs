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

namespace Application.BL.Reports.Get
{
    public sealed class GenerateReportQueryHandler : IRequestHandler<GenerateReportQuery, Result<ReportDto>>
    {
        private readonly ILogger<GenerateReportQueryHandler> logger;
        private readonly IAppDBContext dbContext;
        private readonly IMapper mapper;
        private readonly IValidator<GenerateReportQuery> validator;


        public GenerateReportQueryHandler(ILogger<GenerateReportQueryHandler> logger, IAppDBContext dbContext, IMapper mapper, IValidator<GenerateReportQuery> validator)
        {
            this.logger = logger;
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.validator = validator;
        }

        public async Task<Result<ReportDto>> Handle(GenerateReportQuery request, CancellationToken cancellationToken)
        {
            //Defaulting
            if (request.End is null)
            {
                request.End = DateTime.UtcNow.ToString(ValidatorConstants.DATE_FORMAT, CultureInfo.InvariantCulture);
            }

            //Validate
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                logger.LogInformation("Validation errors: {@ValidationErrors}", validationResult.ToStandardDictionary());
                return new Result<ReportDto>(new ValidationException(validationResult.Errors));
            }

            //Proceed
            var inScopeTracks = await dbContext.Tracks.Where(x => 
                x.Date <= DateTime.Parse(request.End) && x.Date >= DateTime.Parse(request.Start)
            ).ToListAsync();
            var groupedByCategeories = inScopeTracks.GroupBy(x => x.Category).ToList();

            var inScopeCategeories = await dbContext.Categories.Where(x=>inScopeTracks.Select(x=>x.Category).Contains(x.Id)).ToListAsync();

            var dictionary = new Dictionary<Guid, ReportCategoryBreakdown>();

            foreach(var group in groupedByCategeories)
            {
                var currentCatageory = inScopeCategeories.FirstOrDefault(x => x.Id == group.Key);
                dictionary.Add(group.Key, new ReportCategoryBreakdown
                {
                    Title = currentCatageory.Title,
                    Text = currentCatageory.Text,
                    Tracks = group.Select(x => new ReportTrack
                    {
                        Id = x.Id,
                        Date = x.Date,
                        Inc = x.Inc,
                        Exp = x.Exp,
                        Notes = x.Notes
                    }).ToList(),
                    Total = group.Sum(x=>x.Exp)
                });
            }

            var result = new ReportDto
            {
                Start = request.Start,
                End = request.End,
                Breakdown = dictionary,
                Total = dictionary.Sum(x=>x.Value.Total)
            };

            //Complete
            return result;
        }
    }
}

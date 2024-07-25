using Application.Dtos;
using LanguageExt.Common;
using MediatR;

namespace Application.BL.Reports.Get
{
    public sealed class GenerateReportQuery : IRequest<Result<ReportDto>>
    {
        public string Start { get; set; }
        public string End { get; set; }
    }
}

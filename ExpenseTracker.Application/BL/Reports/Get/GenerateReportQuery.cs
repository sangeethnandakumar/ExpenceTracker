using Application.Dtos;
using LanguageExt.Common;
using MediatR;

namespace Application.BL.Reports.Get
{
    public sealed record GenerateReportQuery(string Start, string End) : IRequest<Result<ReportDto>>;
}

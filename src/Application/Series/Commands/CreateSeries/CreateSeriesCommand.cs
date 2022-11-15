using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.Series.Commands.CreateSeries;
public class CreateSeriesCommand
{
    public string? title { get; set; }
}
public class CreateSerieCommandHandler : CreateSeriesCommand
{
    private readonly IApplicationDbContext _context;
    public CreateSerieCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public Task<int> Handle(CreateSeriesCommand request, CancellationToken cancellationToken)
    {
        
        throw new NotImplementedException();
    }
}

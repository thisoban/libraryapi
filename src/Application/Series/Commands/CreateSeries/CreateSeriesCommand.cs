using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Series.Commands.CreateSeries;
public class CreateSeriesCommand
{
    public string? name { get; set; }
    public string? description { get; set; }
    public string? smallDescription { get; set; }
}
public class CreateSerieCommandHandler : CreateSeriesCommand
{
    private readonly IApplicationDbContext _context;
    public CreateSerieCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateSeriesCommand request, CancellationToken cancellationToken)
    {
        var entity = new Serie
        {
            Name = request.name,
            Description = request.description,
            SmallDescription = request.smallDescription
        };
        
        _context.Series.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);
       return entity.Id;
        }
    }

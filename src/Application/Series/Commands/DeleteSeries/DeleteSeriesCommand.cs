using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Events;
using MediatR;

namespace CleanArchitecture.Application.Series.Commands.DeleteSeries;
public record DeleteSeriesCommand(int Id) : IRequest;

public class DeleteSeriesCommandHandler
{
    private readonly IApplicationDbContext _context;

    public DeleteSeriesCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<int> Handle(DeleteSeriesCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Series
            .FindAsync(request.Id, cancellationToken);
        if (entity == null)
        {
            throw new NotFoundException(nameof(Serie), request.Id);
        }
        _context.Series.Remove(entity);
        entity.AddDomainEvent(new SerieDeletedEvent(entity));

        return entity.Id;
    }
}



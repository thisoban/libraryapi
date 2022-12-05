using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Series.Commands.UpdateSeries;
public class UpdateSeriesCommand : IRequest
{
    public int Id { get; set; } 
    public string? Name { get; set; }    
    public string?  Description { get; set; }

}
public class UpdateSerieCommandHandler : IRequestHandler<UpdateSeriesCommand>
{
    private readonly IApplicationDbContext _context;
    public UpdateSerieCommandHandler(IApplicationDbContext  context)
    {
        _context = context;
    }
    public async Task<Unit> Handle(UpdateSeriesCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Series
           .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Serie), request.Id);
        }

        entity.Name = request.Name;
        entity.Description = request.Description;

        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
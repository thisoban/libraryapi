using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Series.Queries.GetSerieWithPagination;
using MediatR;

namespace CleanArchitecture.Application.Series.Queries.GetSerie;
public class GetserieQuery :IRequest<PaginatedList<SerieDto>>
{
    public int serieId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}
public class GetSerieWithPaginationQueryHandler : IRequestHandler<GetserieQuery, PaginatedList<SerieDto>>
{
    public int serieId { get;}
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetSerieWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;   
    }

    public async Task<PaginatedList<SerieDto>> IRequestHandler<GetserieQuery, PaginatedList<SerieDto>>Handle(GetserieQuery request, CancellationToken cancellationToken)
    {
        return await _context.Series
            .Where(x => serieId == request.serieId)
            .OrderBy(x => x.Name)
            .ProjectTo<SerieDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
        throw new NotImplementedException();
    }
}

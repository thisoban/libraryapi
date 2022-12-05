using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Series.Queries.GetSerieWithPagination;
using CleanArchitecture.Application.TodoItems.Queries.GetTodoItemsWithPagination;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Series.Queries.GetSerie;
public class GetserieQuery :IRequest<SerieDto>
{
    public int serieId { get; init; }
  
}

public class GetSerieQueryhandler : IRequest < SerieDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetSerieQueryhandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task <List<SerieDto>> Handle(GetserieQuery request, CancellationToken cancellationToken)
    {
         List<SerieDto> series = (List<SerieDto>)_context.Series.ProjectTo<SerieDto>(_mapper.ConfigurationProvider);
        return series;
    }
}
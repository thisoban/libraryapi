using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Series.Queries.GetSerieWithPagination;

namespace CleanArchitecture.Application.Series.Queries.GetSerie;
public  class SerieVm
{
    public IList<SerieDto> lists= new List<SerieDto>();
}

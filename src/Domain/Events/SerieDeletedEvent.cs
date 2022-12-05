using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Events;
public class SerieDeletedEvent : BaseEvent
{
    public SerieDeletedEvent(Serie serieItem)
    { SerieItem = serieItem; }
    public Serie SerieItem { get; }

}

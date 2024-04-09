using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflix3d.Application.Abstractions.AutoMapper
{
    public interface IMapper
    {
        TDestination Map<TDestination, TSource>(TSource source, string? ignore = null);
        IList<TDestination> Map<TDestination, TSource>(IList<TSource> sources, string? ignore = null);
        TDestination Map<TDestination>(object source, string? ignore = null);
        IList<TDestination> Map<TDestination>(IList<object> source, string? ignore = null);

    }
}

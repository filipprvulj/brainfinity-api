using Brainfinity.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainfinity.Data.Extensions
{
    public static class PaginatorExtensions
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> source, PaginatorInput paginator)
        {
            return source.Skip((paginator.Page - 1) * paginator.Size).Take(paginator.Size);
        }
    }
}
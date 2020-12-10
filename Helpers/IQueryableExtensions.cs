using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Dynamic.Core.Exceptions;

namespace UserService.Helpers
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> Sort<T>(this IQueryable<T> source,
                                            string sortBy,
                                            bool descending = false)
        {
            if(source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if(sortBy == null)
            {
                throw new ArgumentNullException(nameof(sortBy));
            }

            if (descending)
            {
                source = source.OrderBy(sortBy + " desc");
            }
            else
            {
                source = source.OrderBy(sortBy);
            }
            
            return source;
        }
    }
}
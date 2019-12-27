using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Masterpiece.Repository
{
    public class RepositoryCache
    {
        public static readonly Dictionary<Type, Dictionary<string, Tuple<Type, PropertyInfo>>> ComplexPropertyCache;

        static RepositoryCache()
        {
            ComplexPropertyCache = new Dictionary<Type, Dictionary<string, Tuple<Type, PropertyInfo>>>();
        }
    }
}

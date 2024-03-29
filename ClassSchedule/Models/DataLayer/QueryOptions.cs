using System;
using System.Linq.Expressions;

namespace ClassSchedule.Models
{
    public class QueryOptions<T>
    {
        public Expression<Func<T, object>> OrderBy { get; set; } = null!;
        public Expression<Func<T, object>> ThenOrderBy { get; set; } = null!;
        public Expression<Func<T, bool>> Where { get; set; } = null!;
        private string[] _includes = Array.Empty<string>();

        public string Includes
        {
            set => _includes = value?.Replace(" ", "").Split(',');
        }

        public string[] GetIncludes() => _includes ?? new string[0];

        public bool HasWhere => Where != null;
        public bool HasOrderBy => OrderBy != null;
        public bool HasThenOrderBy => ThenOrderBy != null;
    }
}

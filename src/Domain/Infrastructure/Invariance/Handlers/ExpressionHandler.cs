using System;
using System.Linq.Expressions;

namespace Mmu.Khb.Domain.Infrastructure.Invariance.Handlers
{
    internal static class ExpressionHandler
    {
        internal static string GetPropertyName<T>(Expression<Func<T>> propertyExpression)
        {
            var memberExpression = GetMemberExpression(propertyExpression);
            var result = memberExpression.Member.Name;

            return result;
        }

        private static MemberExpression GetMemberExpression<T>(Expression<Func<T>> propertyExpression)
        {
            var result = propertyExpression.Body as MemberExpression;
            if (result == null)
            {
                throw new ArgumentException("You must pass a lambda of the form: '() => Class.Property' or '() => object.Property'");
            }

            return result;
        }
    }
}
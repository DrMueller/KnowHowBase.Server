using System;
using System.Linq.Expressions;
using Mmu.Khb.Domain.Infrastructure.Invariance.Handlers;

namespace Mmu.Khb.Domain.Infrastructure.Invariance
{
    public static class Guard
    {
        public static void ObjectNotNull(Expression<Func<object>> propertyExpression)
        {
            var func = propertyExpression.Compile();
            var obj = func();

            if (obj == null)
            {
                var propertyName = ExpressionHandler.GetPropertyName(propertyExpression);
                throw new ArgumentException($"String {propertyName} must not be null or empty.");
            }
        }

        public static void StringNotNullorEmpty(Expression<Func<string>> propertyExpression)
        {
            var func = propertyExpression.Compile();
            var stringValue = func();

            if (string.IsNullOrEmpty(stringValue))
            {
                var propertyName = ExpressionHandler.GetPropertyName(propertyExpression);
                throw new ArgumentException($"Object {propertyName} must not be null.");
            }
        }
    }
}
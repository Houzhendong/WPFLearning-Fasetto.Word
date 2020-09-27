using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Fasetto.Word.Core
{
    public static class ExpressionHelpers
    {
        public static T GetPropertyValue<T>(this Expression<Func<T>> lambda)
        {
            return lambda.Compile().Invoke();
        }

        public static void SetPropertyValue<T>(this Expression<Func<T>> lambda, T value)
        {
            //converts a lambda to some.property
            var expression = (lambda as LambdaExpression).Body as MemberExpression;

            //get the property information so we can set it
            var propertyInfo = (PropertyInfo)expression.Member;
            var target = Expression.Lambda(expression.Expression).Compile().DynamicInvoke(); 

            //set the property value
            propertyInfo.SetValue(target, value);
        }
    }
}

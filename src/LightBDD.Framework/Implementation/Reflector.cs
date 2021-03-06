﻿using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace LightBDD.Framework.Implementation
{
    internal static class Reflector
    {
        public static string GetMemberName<T>(Expression<T> columnExpression)
        {
            if (columnExpression.Body is MemberExpression memberExpression)
                return memberExpression.Member.Name;
            throw new InvalidOperationException($"Expected {nameof(columnExpression)} to be member expression, got: {columnExpression}");
        }

        public static bool IsGenerated(MemberInfo methodInfo)
        {
            if (methodInfo.IsDefined(typeof(CompilerGeneratedAttribute)))
                return true;
            if (methodInfo.DeclaringType != null)
                return IsGenerated(methodInfo.DeclaringType.GetTypeInfo());
            return false;
        }
    }
}
﻿using System;
using System.Linq.Expressions;
using Komair.Specifications.Abstract;

namespace Komair.Specifications
{
    public class FalseSpecification<T> : SpecificationBase<T>
    {
        private static readonly Lazy<FalseSpecification<T>> IdentityInstance = new Lazy<FalseSpecification<T>>(() => new FalseSpecification<T>());

        public static FalseSpecification<T> Identity => IdentityInstance.Value;

        private FalseSpecification() { }

        public override Expression<Func<T, Boolean>> ToExpression() => Expression.Lambda<Func<T, Boolean>>(TrueSpecification<T>.Identity.Not().ToExpression());
    }
}
using System;
using System.Linq.Expressions;
using Komair.Specifications.Abstract;

namespace Komair.Specifications.UnitTests.Abstract
{
    public abstract class TestBase
    {
        protected const string LongString = "a long one";
        protected const string ShortString = "short";

        protected class ContainsLongSpecification : SpecificationBase<string>
        {
            public override Expression<Func<string, bool>> ToExpression() => t => t.Contains("long");
        }

        protected class ContainsOrtSpecification : SpecificationBase<string>
        {
            public override Expression<Func<string, bool>> ToExpression() => t => t.Contains("ort");
        }

        protected class EndsWithSpecification : SpecificationBase<string>
        {
            private readonly string _suffix;

            public EndsWithSpecification(string suffix)
            {
                _suffix = suffix;
            }

            public override Expression<Func<string, bool>> ToExpression() => t => t.EndsWith(_suffix);
        }

        protected class IsShortStringSpecification : SpecificationBase<string>
        {
            public override Expression<Func<string, bool>> ToExpression() => t => t.Length < 10;
        }

        protected class StartsWithSpecification : SpecificationBase<string>
        {
            private readonly string _prefix;

            public StartsWithSpecification(string prefix)
            {
                _prefix = prefix;
            }

            public override Expression<Func<string, bool>> ToExpression() => t => t.StartsWith(_prefix);
        }
    }
}
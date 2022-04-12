﻿using System;
using Komair.Specifications.UnitTests.Abstract;
using NUnit.Framework;

namespace Komair.Specifications.UnitTests;

public class TrueSpecificationTests : TestBase
{
    [Test]
    public void True_AndFalse_IsFalse()
    {
        var specification = TrueSpecification<String>.Identity;
        var result = specification.And(FalseSpecification<String>.Identity).IsSatisfiedBy(ShortString);

        Assert.IsFalse(result);
    }

    [Test]
    public void True_AndLongString_IsTrue()
    {
        var specification = TrueSpecification<String>.Identity;
        var result = specification.IsSatisfiedBy(LongString);

        Assert.IsTrue(result);
    }

    [Test]
    public void True_AndNull_IsTrue()
    {
        var specification = TrueSpecification<String>.Identity;
        var result = specification.IsSatisfiedBy(null);

        Assert.IsTrue(result);
    }

    [Test]
    public void True_AndShortString_IsTrue()
    {
        var specification = TrueSpecification<String>.Identity;
        var result = specification.IsSatisfiedBy(ShortString);

        Assert.IsTrue(result);
    }

    [Test]
    public void True_AndTrue_IsTrue()
    {
        var specification = TrueSpecification<String>.Identity;
        var result = specification.And(TrueSpecification<String>.Identity).IsSatisfiedBy(ShortString);

        Assert.IsTrue(result);
    }

    [Test]
    public void True_OrFalse_IsTrue()
    {
        var specification = TrueSpecification<String>.Identity;
        var result = specification.Or(FalseSpecification<String>.Identity).IsSatisfiedBy(ShortString);

        Assert.IsTrue(result);
    }
}

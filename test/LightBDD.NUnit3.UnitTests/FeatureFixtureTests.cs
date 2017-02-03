﻿using LightBDD;
using LightBDD.NUnit3;
using NUnit.Framework;

[assembly: LightBddScope]

namespace LightBDD.Integration.NUnit3.UnitTests
{
    [TestFixture]
    public class FeatureFixtureTests
    {
        class TestableFeatureFixture : FeatureFixture
        {
            public IBddRunner GetRunner() => Runner;
        }

        [Test]
        public void Runner_should_be_initialized()
        {
            Assert.IsNotNull(new TestableFeatureFixture().GetRunner());
        }
    }
}
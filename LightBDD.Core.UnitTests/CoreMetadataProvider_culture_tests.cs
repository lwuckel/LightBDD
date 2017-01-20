﻿using System.Globalization;
using LightBDD.Configuration;
using LightBDD.Core.Extensibility;
using LightBDD.Core.Formatting;
using LightBDD.Core.UnitTests.Helpers;
using LightBDD.UnitTests.Helpers.TestableIntegration;
using NUnit.Framework;

namespace LightBDD.Core.UnitTests
{
    [TestFixture]
    public class CoreMetadataProvider_culture_tests
    {
        [Test]
        [TestCase("pl-PL", 3.14, "3,14")]
        [TestCase("en-US", 3.14, "3.14")]
        public void It_should_format_step_parameters_with_specified_formatter(string cultureInfo, double parameter, string expectedFormattedParameter)
        {
            var parameterInfo = ParameterInfoHelper.GetMethodParameter<double>(Step_with_parameter);

            var formatter = new TestMetadataProvider(new DefaultNameFormatter(), new StepTypeConfiguration(), new TestCultureInfoProvider(new CultureInfo(cultureInfo)))
                .GetStepParameterFormatter(parameterInfo);

            Assert.That(formatter.Invoke(parameter), Is.EqualTo(expectedFormattedParameter));
        }

        private static void Step_with_parameter(double value) { }

        private class TestCultureInfoProvider : ICultureInfoProvider
        {
            private readonly CultureInfo _cultureInfo;

            public TestCultureInfoProvider(CultureInfo cultureInfo)
            {
                _cultureInfo = cultureInfo;
            }

            public CultureInfo GetCultureInfo()
            {
                return _cultureInfo;
            }
        }
    }
}

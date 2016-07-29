﻿using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LightBDD.Formatting.Parameters;
using NUnit.Framework;

namespace LightBDD.Core.UnitTests.Formatting.Parameters
{
    [TestFixture]
    public class FormatAttribute_tests
    {
        [Test]
        public void It_should_use_specified_format()
        {
            var attribute = new FormatAttribute("--{0}--");
            Assert.That(attribute.Format(CultureInfo.InvariantCulture, 55.5), Is.EqualTo("--55.5--"));
            Assert.That(attribute.Format(CultureInfo.GetCultureInfo("PL"), 55.5), Is.EqualTo("--55,5--"));
        }
    }
}
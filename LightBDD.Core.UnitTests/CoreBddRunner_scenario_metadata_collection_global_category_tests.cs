using System.Linq;
using LightBDD.UnitTests.Helpers.TestableIntegration;
using NUnit.Framework;
using Steps = LightBDD.Core.UnitTests.Helpers.Steps;

namespace LightBDD.Core.UnitTests
{
    [ScenarioCategory("global1")]
    [ScenarioCategory("global2")]
    [TestFixture]
    public class CoreBddRunner_scenario_metadata_collection_global_category_tests : Steps
    {
        private IBddRunner _runner;
        private IFeatureBddRunner _feature;

        [SetUp]
        public void SetUp()
        {
            _feature = TestableBddRunnerFactory.GetRunner(GetType());
            _runner = _feature.GetRunner(this);
        }

        [Test]
        public void It_should_capture_scenario_name_with_global_categories()
        {
            _runner.Test().TestScenario(Some_step);
            var scenario = _feature.GetFeatureResult().GetScenarios().Single();
            Assert.That(scenario.Info.Categories, Is.EqualTo(new[] { "global1", "global2" }));
        }

        [Test]
        [ScenarioCategory("local1")]
        [ScenarioCategory("local2")]
        public void It_should_capture_scenario_name_with_global_and_local_categories()
        {
            _runner.Test().TestScenario(Some_step);
            var scenario = _feature.GetFeatureResult().GetScenarios().Single();
            Assert.That(scenario.Info.Categories, Is.EqualTo(new[] { "global1", "global2", "local1", "local2" }));
        }
    }
}
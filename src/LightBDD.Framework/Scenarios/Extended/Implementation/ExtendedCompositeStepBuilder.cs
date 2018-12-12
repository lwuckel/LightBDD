using System;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LightBDD.Framework.Extensibility;

namespace LightBDD.Framework.Scenarios.Extended.Implementation
{
    [DebuggerStepThrough]
    internal class ExtendedCompositeStepBuilder<TContext>
    {
        private readonly IIntegrableStepGroupBuilder _builder;
        private readonly ExtendedStepCompiler<TContext> _stepCompiler;

        public ExtendedCompositeStepBuilder(IIntegrableStepGroupBuilder builder)
        {
            _builder = builder;
            _stepCompiler = new ExtendedStepCompiler<TContext>(builder.Configuration);
        }

        public void AddSteps(Expression<Func<TContext, Task>>[] steps)
        {
            _builder.AddSteps(steps.Select(_stepCompiler.ToStep));
        }

        public void AddSteps(Expression<Action<TContext>>[] steps)
        {
            _builder.AddSteps(steps.Select(_stepCompiler.ToStep));
        }
    }
}
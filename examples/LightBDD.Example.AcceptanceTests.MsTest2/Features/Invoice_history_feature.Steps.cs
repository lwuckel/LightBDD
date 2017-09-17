﻿using System.Threading.Tasks;
using LightBDD.Example.Helpers;
using LightBDD.Framework.Formatting;
using LightBDD.MsTest2;

namespace LightBDD.Example.AcceptanceTests.MsTest2.Features
{
    public partial class Invoice_history_feature : FeatureFixture
    {
        private async Task Given_invoice(string invoice)
        {
            await LongRunningOperationSimulator.SimulateAsync();
        }

        private void When_I_request_all_historical_invoices()
        {
            LongRunningOperationSimulator.Simulate();
        }

        private void Then_I_should_see_invoices([FormatCollection]params string[] invoices)
        {
        }
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
[assembly: PartId(PartId.TestUnits)]

namespace Z0.Parts
{
    public sealed class TestUnits : Part<TestUnits>
    {
        public static PartAssets Assets = new PartAssets();

        public sealed class PartAssets : Assets<PartAssets>
        {

        }
    }
}
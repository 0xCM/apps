//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
[assembly: PartId(PartId.LogixTest)]

namespace Z0.Parts
{
    public sealed class LogixTest : ExecutablePart<LogixTest>
    {
        public override void Execute(params string[] args) => LogixTestApp.Run(args);
    }
}

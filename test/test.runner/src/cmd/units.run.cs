//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    class TestRunner : TestApp<TestRunner>
    {
        protected override Assembly TargetComponent
            => Parts.TestUnits.Assembly;
    }

    partial class CheckRunCmd
    {
        [CmdOp("units/run")]
        Outcome RunUnits(CmdArgs args)
        {
            TestRunner.Run(core.array(PartId.Lib,PartId.TestUnits));
            return true;
        }
    }
}
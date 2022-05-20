//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
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
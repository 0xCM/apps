//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class AsmCoreCmd
    {
        [CmdOp("sdm/etl")]
        Outcome SdmImport(CmdArgs args)
            => Sdm.Etl();
    }
}
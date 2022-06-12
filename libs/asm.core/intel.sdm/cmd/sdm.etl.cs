//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;
    using static Asm.SdmModels;
    using static core;

    partial class AsmCoreCmd
    {
        [CmdOp("sdm/etl")]
        Outcome SdmImport(CmdArgs args)
            => Sdm.Etl();

    }
}
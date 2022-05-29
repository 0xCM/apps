//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;
    using static core;

    partial class AsmCoreCmd
    {

        [CmdOp("asm/cases/emit")]
        Outcome EmitAsmCases(CmdArgs args)
        {
            var src = AsmCases.mov();
            AppSvc.TableEmit(src, AppDb.ApiTargets().Table<AsmEncodingCase>());

            return true;
        }
    }
}
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
        [CmdOp("api/emit/msil")]
        void EmitMsil()
        {
            AppDb.MsilTargets().Delete();
            ApiMd.EmitMsil(ApiRuntimeCatalog.ApiHosts, AppDb.MsilTargets(il));
            AppSvc.TableEmit(Cil.opcodes(), AppDb.Targets("clr").Path("cil.opcodes", FileKind.Csv));
        }
    }
}
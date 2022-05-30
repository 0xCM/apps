//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class AsmCoreCmd
    {
        [CmdOp("api/emit/msil")]
        void EmitMsil()
        {
            AppDb.MsilTargets().Delete();
            ApiMd.EmitMsil(ApiMd.ApiHosts, AppDb.MsilTargets(il));
            AppSvc.TableEmit(Cil.opcodes(), AppDb.Targets("clr").Path("cil.opcodes", FileKind.Csv));
        }
    }
}
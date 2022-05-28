//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class AsmCoreCmd
    {
        [CmdOp("gen/replicants")]
        Outcome GenEnums(CmdArgs args)
        {
            const string Name = "api.types.enums";
            var src = AppDb.ApiTargets().Path(Name, FileKind.List);
            var types = ApiMd.LoadTypes(src);
            var name = "EnumDefs";
            CsLang.EmitReplicants(CsLang.replicant(AppDb.CgStage(name), out var spec), types, AppDb.CgStage(name));
            return true;
        }
    }
}
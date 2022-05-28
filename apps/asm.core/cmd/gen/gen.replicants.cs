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
        [CmdOp("gen/replicants")]
        Outcome GenEnums(CmdArgs args)
        {
            const string Name = "api.types.enums";
            var src = AppDb.ApiTargets().Path(Name, FileKind.List);
            var types = ApiSvc.LoadTypes(src);
            var name = "EnumDefs";
            CsLang.EmitReplicants(types, AppDb.CgStage(name));
            return true;
        }
    }
}
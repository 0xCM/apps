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
            const string Name = "api.enums.types";
            var src = AppDb.Api().Path(Name, FileKind.List);
            var types = CsLang.LoadReplicantTypes(src);
            var name = "EnumDefs";
            var dst = AppDb.CgStage().Path(name, FileKind.Cs);
            CsLang.GenEnumReplicants(types, dst);
            return true;
        }

        [CmdOp("xed/gen/replicants")]
        Outcome GenReplicants(CmdArgs args)
        {
            const string Name = "XedLiterals";
            //var src = AppDb.Api().Path(Name, FileKind.List);
            //var types = CsLang.LoadReplicantTypes(src);
            //var name = "EnumDefs";

            //var dst = AppDb.CgStage().Path(Name, FileKind.Cs);
            //CsLang.GenEnumReplicants(types, dst);
            return true;
        }

    }
}
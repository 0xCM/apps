//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedModels;
    using static XedPatterns;
    using static core;

    partial class XedCmdProvider
    {
        [CmdOp("xed/check/fields")]
        Outcome CheckFields(CmdArgs args)
        {
            var p = FieldPotential.create();
            ref readonly var regs = ref p.Regs;
            for(var i=0; i<regs.Count; i++)
            {
                ref readonly var reg = ref regs[i];
                Write(reg.ToString());

            }
            return true;
        }

        [CmdOp("gen/stores")]
        Outcome GenStores(CmdArgs args)
        {
            var assets = Parts.AsmOperands.Assets;
            var template = assets.DataStoreTemplate().Utf8();
            var path = AppDb.CgStagePath("DataStores", FileKind.Cs);
            var content = text.replace(template, "`{0}`", "589");
            FileEmit(content, 1,path);

            return true;

        }

    }
}
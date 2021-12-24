//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using static XedModels;

    partial class XedCmdProvider
    {
        [CmdOp("xed/emit/rules")]
        protected Outcome EmitXedRules(CmdArgs args)
        {
            Xed.Rules.EmitCatalog();
            return true;
        }

        [CmdOp("xed/emit/widths")]
        protected Outcome EmitXedWidths(CmdArgs args)
        {
            var src = Xed.Rules.ParseOperandWidths();
            var dst = ProjectDb.TablePath<OperandWidth>("xed");
            TableEmit(src.View,dst);
            return true;
        }

    }
}
//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static core;

    partial class XedRules
    {
        public void EmitFields()
        {
            exec(PllExec,
                EmitFieldDefs,
                EmitReflectedFields
                );
        }

        void EmitFieldDefs()
            => TableEmit(CalcFieldDefs().View, XedFieldDef.RenderWidths, XedPaths.FieldDefsTarget());

        void EmitReflectedFields()
            => TableEmit(XedFields.Specs.View, RuleFieldSpec.RenderWidths, AppDb.XedTable<RuleFieldSpec>());
    }
}
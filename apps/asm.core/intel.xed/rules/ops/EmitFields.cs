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
        void EmitSymbolicFields()
        {
            var src = XedFields.SymbolicFields.create();
            ApiMetadataService.create(Wf).EmitTokenSet(src, AppDb.XedPath("xed.fields.symbolic", FileKind.Csv));
        }

        void EmitFieldDefs()
            => TableEmit(CalcFieldDefs().View, XedFieldDef.RenderWidths, XedPaths.FieldDefsTarget());

        void EmitReflectedFields()
            => TableEmit(XedFields.Specs.View, RuleFieldSpec.RenderWidths, AppDb.XedTable<RuleFieldSpec>());
    }
}
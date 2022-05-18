//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedRules
    {
        public void EmitCatalog(Index<InstPattern> patterns, RuleTables rules)
        {
            exec(PllExec,
                () => AppSvc.TableEmit(OpCodeKinds.Instance.Records, XedPaths.Table<OcMapKind>()),
                //EmitOpWidths,
                //() => Emit(CalcPointerWidths().View),
                () => Emit(mapi(RuleMacros.matches().Values.ToArray().Sort(), (i,m) => m.WithSeq((uint)i))),
                () => Emit(CalcMacroDefs().View),
                () => Emit(XedFields.Defs.Positioned),
                EmitSymbolicFields
                //() => Emit(ImportFieldDefs())
            );

            Emit(patterns, rules);
        }

        void EmitSymbolicFields()
            => ApiMd.EmitTokenSet(XedFields.EffectiveFields.create(), XedPaths.Target("xed.fields.symbolic", FS.Csv));

        // public void EmitOpWidths()
        //     => Emit(XedOperands.Views.OpWidths);
    }
}
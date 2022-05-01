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
        public Index<InstPattern> CalcPatterns()
            => CalcInstPatterns(CalcInstDefs());

        public Index<InstLayout> CalcInstLayouts(Index<InstPattern> src)
            => Data(nameof(CalcInstLayouts), () => LayoutCalcs.layouts(src));

        void Emit(Index<InstLayout> src)
            => TableEmit(src.View, InstLayout.RenderWidths, XedPaths.Table<InstLayout>());

        public Index<InstFieldRow> CalcInstFields(Index<InstPattern> src)
            => Data(nameof(CalcInstFields), () => XedPatterns.fieldrows(src));

        public Index<InstPatternRecord> CalcPatternRecords(Index<InstPattern> src)
            => Data(nameof(CalcPatternRecords), () => XedPatterns.describe(src));

        public Index<InstGroup> CalcInstGroups(Index<InstPattern> src)
            => Data(nameof(CalcInstGroups),() => XedPatterns.groups(src).Values.ToArray().Sort());

        public Index<InstPattern> EmitPatterns(Index<InstPattern> src)
        {
            exec(PllExec,
                () => Emit(CalcInstLayouts(src)),
                () => Emit(CalcPatternRecords(src)),
                () => EmitFlagEffects(src),
                () => EmitInstAttribs(src),
                () => Emit(CalcInstFields(src)),
                () => Emit(CalcInstGroups(src)),
                () => EmitDetails(src),
                () => {},
                () => Emit(CalcPoc(src))
                );

            return src;
        }

        void EmitDetails(Index<InstPattern> src)
        {
            var details = CalcInstOpDetails(src);
            exec(PllExec,
            () => Emit(CalcInstOpRows(details)),
            () => Emit(CalcOpClasses(details))
            );
        }
    }
}
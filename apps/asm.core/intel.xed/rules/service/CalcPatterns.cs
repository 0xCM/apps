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

        public Index<InstFieldRow> CalcInstFields(Index<InstPattern> src)
            => Data(nameof(CalcInstFields), () => XedPatterns.fieldrows(src));

        public Index<InstPatternRecord> CalcPatternRecords(Index<InstPattern> src)
            => Data(nameof(CalcPatternRecords), () => XedPatterns.describe(src));

        public Index<InstGroup> CalcInstGroups(Index<InstPattern> src)
            => Data(nameof(CalcInstGroups),() => XedPatterns.groups(src).Values.ToArray().Sort());

        public Index<InstPattern> Emit(Index<InstPattern> src)
        {
            exec(PllExec,
                () => Emit(CalcInstLayouts(src)),
                () => Emit(CalcPatternRecords(src)),
                () => EmitFlagEffects(src),
                () => EmitInstAttribs(src),
                () => Emit(CalcInstFields(src)),
                () => Emit(CalcInstGroups(src)),
                () => Emit(CalcInstOpDetails(src)),
                () => Emit(CalcPoc(src))
                );
            return src;
        }
    }
}
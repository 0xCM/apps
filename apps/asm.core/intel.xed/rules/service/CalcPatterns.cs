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
        {
            var patterns = CalcInstPatterns(CalcInstDefs());
            return patterns;
        }

        public Index<InstFieldRow> CalcInstFields(Index<InstPattern> src)
            => Data(nameof(CalcInstFields), () => XedPatterns.fieldrows(src));

        public Index<InstPatternRecord> CalcPatternRecords(Index<InstPattern> src)
            => Data(nameof(CalcPatternRecords), () => XedPatterns.describe(src));

        public Index<InstGroup> CalcInstGroups(Index<InstPattern> src)
            => Data(nameof(CalcInstGroups),() => XedPatterns.groups(src).Values.ToArray().Sort());

        public Index<InstPattern> EmitPatterns(Index<InstPattern> patterns)
        {
            var records = CalcPatternRecords(patterns);
            Emit(records);
            var fields = CalcInstFields(patterns);
            var details = CalcInstOpDetails(patterns);
            var classes = CalcOpClasses(details);
            var ops = CalcInstOpRows(details);
            var groups = CalcInstGroups(patterns);
            var poc = CalcPoc(patterns);
            exec(PllExec,
                () => Emit(ops),
                () => Emit(classes),
                () => Emit(groups),
                () => Emit(poc),
                () => Emit(fields),
                () => EmitFlagEffects(patterns),
                () => EmitInstAttribs(patterns)
                );
            return patterns;
        }
    }
}
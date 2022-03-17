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
        [MethodImpl(Inline), Op]
        public static RuleSchema schema(RuleSig sig, params RuleCellSpec[] cols)
            => new RuleSchema(sig,cols);

        public static RuleSchema schema(RuleSig sig, ReadOnlySpan<RuleTableRow> src)
            => schema(sig, specs(src));

        public static RuleSchema schema(in RuleTable src)
        {
            var data = rows(src).Data;
            if(data.IsNonEmpty)
                return schema(src.Sig, data);
            else
                return RuleSchema.Empty;
        }

        [Op]
        public static Index<RuleCellSpec> specs(ReadOnlySpan<RuleTableRow> src)
        {
            const byte ColCount = RuleTableRow.ColCount;
            var dst = hashset<RuleCellSpec>();
            Span<RuleCellSpec> buffer = stackalloc RuleCellSpec[ColCount];
            for(var i=0; i<src.Length; i++)
            {
                buffer.Clear();
                var count = specs(skip(src,i), buffer);
                var defined = slice(buffer,0,count);
                foreach(var spec in defined)
                    dst.Add(spec);
            }
            return dst.Array().Sort();
        }

        [MethodImpl(Inline), Op]
        public static byte specs(in RuleTableRow src, Span<RuleCellSpec> dst)
        {
            const byte ColCount = RuleTableRow.ColCount;
            var counter = z8;
            for(byte i=0; i<ColCount; i++)
            {
                var col = src[i];
                if(col.IsNonEmpty && col.Field != 0)
                    seek(dst,counter++) = col.Spec;
            }
            return counter;
        }
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;
    using static XedRecords;

    using OCP = XedRecords.OcPatternNames;

    public readonly struct XedOpCodeParser
    {
        public static XedOpCodeParser create()
            =>new XedOpCodeParser();

        public Index<XedOpCodeRecord> Parse(ReadOnlySpan<RulePattern> src)
        {
            var count = src.Length;
            var buffer = alloc<XedOpCodeRecord>(count);
            var @class = IClass.INVALID;
            var kseq = z8;
            for(var i=0u; i<count; i++)
            {
                ref readonly var rule = ref skip(src,i);
                ref var dst = ref seek(buffer,i);
                if(i==0)
                    @class = rule.Class;
                else
                {
                    if(@class != rule.Class)
                    {
                        @class = rule.Class;
                        kseq = 0;
                    }
                }

                dst.Seq = i;
                dst.Class = rule.Class;
                dst.Kind = rule.OpCodeKind;
                dst.ClassSeq = kseq++;
                dst.Value = value(rule);
                dst.Source = rule.Expression;
            }

            return buffer;
        }

        internal static uint value(in string rule)
        {
            var dst = 0u;
            var k = z8;
            var parts = rule.Split(Chars.Space);
            var count = parts.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var part = ref skip(parts,i);
                if(part.Equals(OCP.VV1) || part.Equals(OCP.EVV) || part.Equals(OCP.XOPV))
                    continue;

                if(ocbyte(part, out var b))
                {
                    dst |= ((uint)b << k*8);
                    k++;
                }
                else
                    break;
            }
            return dst;
        }

        internal static uint value(in RulePattern rule)
            => value(rule.Expression);

        static bool ocbyte(string src, out Hex8 dst)
            => DataParser.parse(src, out dst);
    }
}
//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using OCP = XedModels.OcPatternNames;

    partial class XedRules
    {
        public readonly struct XedOpCodeParser
        {
            public static XedOpCodeParser create()
                =>new XedOpCodeParser();

            public Index<RuleOpCode> Parse(ReadOnlySpan<RulePatternInfo> src)
            {
                var count = src.Length;
                var buffer = alloc<RuleOpCode>(count);
                for(var i=0u; i<count; i++)
                {
                    ref readonly var rule = ref skip(src,i);
                    ref var dst = ref seek(buffer,i);
                    dst.Kind = rule.OpCodeKind;
                    dst.Index = (byte)ocindex(rule.OpCodeKind);
                    dst.Value = value(rule);
                    dst.Class = rule.Class;
                    dst.Source = rule.Expression;
                }

                buffer.Sort();
                for(var i=0u; i<count; i++)
                    seek(buffer,i).Seq = i;

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

            internal static uint value(in RulePatternInfo rule)
                => value(rule.Expression);

            static bool ocbyte(string src, out Hex8 dst)
            {
                var t = text.trim(src);
                if(text.index(t, "0b") >= 0)
                {
                    if(BitNumbers.parse(text.remove(t, Chars.Underscore).Remove("0b"), out uint8b y))
                    {
                        dst = (byte)y;
                        return true;
                    }
                }
                return DataParser.parse(src, out dst);
            }
        }
    }
}
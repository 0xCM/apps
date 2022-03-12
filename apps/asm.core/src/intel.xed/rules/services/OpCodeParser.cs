//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;

    using OCP = XedModels.OcPatternNames;

    partial class XedRules
    {
        public readonly struct XedOpCodeParser
        {
            public static XedOpCodeParser create()
                =>new XedOpCodeParser();

            public Index<XedOpCode> Parse(ReadOnlySpan<RulePatternInfo> src)
            {
                var count = src.Length;
                var buffer = alloc<XedOpCode>(count);
                for(var i=0u; i<count; i++)
                    seek(buffer,i) = opcode(skip(src,i));

                // buffer.Sort();
                // for(var i=0u; i<count; i++)
                //     seek(buffer,i).Seq = i;

                return buffer.Sort();
            }

            public static XedOpCode opcode(in RulePatternInfo rule)
            {
                var dst = XedOpCode.Empty;
                dst.PatternId = rule.PatternId;
                dst.InstId = rule.InstId;
                dst.Kind = rule.OpCodeKind;
                dst.Index = (byte)ocindex(rule.OpCodeKind);
                dst.Value = value(rule);
                dst.Class = rule.Class;
                dst.Pattern = rule.BodyExpr;
                return dst;
            }

            static uint value(in RulePatternInfo src)
            {
                var expr = src.BodyExpr.Text;
                var dst = 0u;
                var k = z8;
                var parts = expr.Split(Chars.Space);
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
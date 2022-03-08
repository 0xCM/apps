//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedModels;
    using static core;

    partial class XedRules
    {
        public XedOpCode opcode(in RulePatternInfo src)
            => new XedOpCode(src.Class, src.OpCodeKind, XedOpCodeParser.value(src));

        public static AsmOcValue ocvalue(ReadOnlySpan<RuleToken> tokens)
        {
            var count = tokens.Length;
            var parsing = false;
            var storage = ByteBlock4.Empty;
            var dst = storage.Bytes;
            var j=0;
            for(var i=0; i<count; i++)
            {
                ref readonly var token = ref skip(tokens,i);
                if(parsing)
                {
                    if(token.Kind == RuleTokenKind.HexLit)
                        seek(dst,j++) = token.AsHexLit();
                    else
                        break;
                }
                else
                {
                    if(token.Kind ==  RuleTokenKind.HexLit)
                    {
                        seek(dst,j++) = token.AsHexLit();
                        parsing = true;
                    }
                }
            }
            return new AsmOcValue(slice(dst,0,j));
        }
    }
}
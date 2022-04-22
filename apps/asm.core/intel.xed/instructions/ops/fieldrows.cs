//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;

    partial class XedPatterns
    {
        public static Index<InstFieldRow> fieldrows(Index<InstPattern> src)
        {
            var dst = list<InstFieldRow>();
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var pattern = ref src[i];
                for(byte j=0; j<pattern.Body.FieldCount; j++)
                {
                    ref readonly var body = ref pattern.Body;
                    ref readonly var fields = ref body.Fields;
                    for(var k=z8; k<fields.Count; k++)
                        dst.Add(fieldrow(pattern, fields[k], k));
                }
            }
            return dst.ToIndex();
        }

        [Op]
        static InstFieldRow fieldrow(InstPattern pattern, in InstField src, byte index)
        {
            var dst = InstFieldRow.Empty;
            dst.PatternId = pattern.PatternId;
            dst.Mode = pattern.Mode;
            dst.Lock = XedFields.@lock(pattern.Fields);
            dst.Index = Require.equal(index,src.Position);
            dst.FieldClass = src.FieldClass;
            dst.FieldKind = src.FieldKind;
            dst.InstClass = pattern.InstClass;
            dst.OpCode = pattern.OpCode;
            switch(src.DataKind)
            {
                case InstFieldKind.Seg:
                    dst.Seg = src.AsSegField();
                break;
                case InstFieldKind.BitLiteral:
                    dst.BitLiteral = src.AsBitLit();
                break;
                case InstFieldKind.Expr:
                    dst.FieldExpr = src.ToFieldExpr();
                    if(dst.FieldExpr.IsNonTerminal)
                        dst.Nonterminal = dst.FieldExpr.Value.ToNonterminal();
                break;
                case InstFieldKind.HexLiteral:
                    dst.HexLiteral = src.AsHexLit();
                break;
                case InstFieldKind.IntLiteral:
                    dst.IntLiteral = src.AsIntLit();
                break;
                case InstFieldKind.Nonterm:
                    dst.Nonterminal = src.AsNonterminal();
                break;
            }

            return dst;
        }
    }
}
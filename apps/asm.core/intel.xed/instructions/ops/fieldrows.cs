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
            var count = 0u;
            iter(src, p => count += p.Body.FieldCount);
            var dst = alloc<InstFieldRow>(count);
            var k=0u;
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var pattern = ref src[i];
                ref readonly var body = ref pattern.Body;
                for(byte j=0; j<body.FieldCount; j++,k++)
                    seek(dst,k) = fieldrow(pattern, body[j], j);
            }
            return dst;
        }

        [Op]
        public static InstFieldRow fieldrow(InstPattern pattern, in InstField src, byte index)
        {
            var dst = InstFieldRow.Empty;
            dst.PatternId = pattern.PatternId;
            dst.InstId = pattern.InstId;
            dst.Mode = pattern.Mode;
            dst.Index = index;
            dst.FieldClass = src.DataKind;
            dst.FieldKind = src.FieldKind;
            dst.InstClass = pattern.InstClass;
            dst.OcKind = pattern.OpCode.Kind;
            dst.OcValue = pattern.OpCode.Value;
            switch(src.DataKind)
            {
                case InstFieldKind.Seg:
                    dst.Seg = src.AsSegField();
                break;
                case InstFieldKind.BitLiteral:
                    dst.BitLiteral = src.AsBitLit();
                break;
                case InstFieldKind.Expr:
                    dst.FieldExpr = src.AsFieldExpr();
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
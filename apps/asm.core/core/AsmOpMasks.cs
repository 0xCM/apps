//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    public readonly struct AsmOpMasks
    {
        readonly Symbols<OpMaskToken> Tokens;

        public AsmOpMasks()
        {
            Tokens = Symbols.index<OpMaskToken>();
        }

        public bool Test(string src)
            => Tokens.ExprKind(src, out _);

        public bool Test(in AsmSigOpExpr src)
            => Tokens.ExprKind(src.Text, out _);

        public bool Kind(string src, out OpMaskToken dst)
            => Tokens.ExprKind(src, out dst);

        public bool Split(string src, out AsmSigOpExpr op1, out AsmSigOpExpr op2)
        {
            var result = Kind(src, out var token);
            op1 = AsmSigOpExpr.Empty;
            op2 = AsmSigOpExpr.Empty;
            if(result)
            {
                var parts = text.split(src, Chars.Underscore);
                if(parts.Length == 2)
                {
                    op1 = skip(parts,0);
                    op2 = skip(parts,1);
                }
            }

            return result;
        }

        public bool Split(AsmSigOpExpr src, out AsmSigOpExpr op1, out AsmSigOpExpr op2)
            => Split(src.Text, out op1, out op2);
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class AsmSigs
    {
        public static bool modifier(AsmSigOpExpr src, out string target, out AsmModifierKind mod)
        {
            var modifiers = Symbols.index<AsmModifierKind>();
            mod = AsmModifierKind.None;
            target = EmptyString;
            var i = text.index(src.Text, Chars.LBrace);
            if(i > 0)
            {
                target = text.trim(text.left(src.Text,i));
                modifiers.ExprKind(text.trim(text.right(src.Text,i-1)), out mod);
            }
            return mod != 0;
        }
    }
}
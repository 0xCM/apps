//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial class AsmSigs
    {
        public static bool modifier(AsmSigOpExpr src, out string target, out AsmModifierKind mod)
        {
            mod = AsmModifierKind.None;
            target = EmptyString;
            var i = text.index(src.Text, Chars.LBrace);
            if(i > 0)
            {
                target = text.trim(text.left(src.Text,i));
                var modtext = text.trim(text.right(src.Text,i-1));
                var modifiers = Symbols.index<AsmModifierKind>();
                modifiers.ExprKind(modtext, out mod);
            }
            return mod != 0;
        }

        public static bool modified(in AsmSigOpExpr src)
            => src.Text.Contains(Chars.LBrace);
    }
}
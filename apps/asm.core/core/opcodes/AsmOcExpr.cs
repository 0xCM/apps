//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct AsmOcExpr
    {
        [MethodImpl(Inline), Op]
        public static AsmOcExpr define(in CharBlock36 expr)
            => new AsmOcExpr(expr);

        public CharBlock36 Content;

        [MethodImpl(Inline)]
        public AsmOcExpr(CharBlock36 expr)
        {
            Content = expr;
        }

        public bool IsEmpty
            => text.empty(Content.Format());

        public bool IsNonEmpty
            => text.nonempty(Content.Format());

        public string Format()
            => Content.Format();

        public override string ToString()
            => Format();

        public static AsmOcExpr Empty
            => default;
    }
}
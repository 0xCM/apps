//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class XTend
    {
        [MethodImpl(Inline), Op]
        public static char ToChar(this SymNotKind src)
            => (char)src;

        [MethodImpl(Inline), Op]
        public static string Format(this SymNotKind src)
            => ((char)src).ToString();

        [Op]
        public static Label ToCsKeyword(this ClrLiteralKind src)
            => CsKeywords.keyword(src);

        [Op]
        public static Label ToCsKeyword(this ClrAccessKind src)
            => CsKeywords.keyword(src);

        [Op]
        public static Index<Label> ToCsKeywords(this ClrModifierKind src)
            => CsKeywords.keywords(src);

    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        [MethodImpl(Inline), Op]
        public static Label CsKeyword(this ClrEnumKind kind)
            => Z0.CsKeywords.keyword(kind);

        [MethodImpl(Inline), Op]
        public static char ToChar(this SymNotKind src)
            => (char)src;

        [MethodImpl(Inline), Op]
        public static string Format(this SymNotKind src)
            => ((char)src).ToString();

        [Op]
        public static Label CsKeyword(this ClrLiteralKind src)
            => Z0.CsKeywords.keyword(src);

        [Op]
        public static Label CsKeyword(this ClrAccessKind src)
            => Z0.CsKeywords.keyword(src);

        [Op]
        public static Index<Label> CsKeywords(this ClrModifierKind src)
           => Z0.CsKeywords.keywords(src);
    }
}
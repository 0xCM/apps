//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using C = AsciCode;

    partial struct Asci
    {
        /// <summary>
        /// Tests whether a character is an uppercase asci letter character
        /// </summary>
        /// <param name="c">The character to test</param>
        [MethodImpl(Inline), Op]
        public static bool letter(UpperCased @case, char c)
            => (C)c >= AsciCodeFacets.MinUpperLetter && (C)c <= AsciCodeFacets.MaxUpperLetter;

        /// <summary>
        /// Tests whether a character is a lowercase asci letter character
        /// </summary>
        /// <param name="c">The character to test</param>
        [MethodImpl(Inline), Op]
        public static bool letter(LowerCased @case, char c)
            => (C)c >= AsciCodeFacets.MinLowerLetter && (C)c <= AsciCodeFacets.MaxLowerLetter;

        /// <summary>
        /// Tests whether a character is an asci letter character
        /// </summary>
        /// <param name="c">The character to test</param>
        [MethodImpl(Inline), Op]
        public static bool letter(char c)
            => letter(UpperCase, c) || letter(LowerCase, c);
    }
}
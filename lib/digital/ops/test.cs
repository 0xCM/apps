//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using D = DecimalDigitFacets;
    using O = OctalDigitFacets;
    using B = BinaryDigitFacets;
    using X = HexDigitFacets;

    /// <summary>
    /// Defines operations over character digits
    /// </summary>
    partial struct Digital
    {
        /// <summary>
        /// Determines whether a character can be interpreted as a <see cref='OctalDigitCode'/> or <see cref='OctalDigitSym'/>
        /// </summary>
        /// <param name="c">The character to test</param>
        [MethodImpl(Inline), Op]
        public static bool test(Base2 @base, char c)
            => (BinaryDigitCode)c >= B.MinCode && (BinaryDigitCode)c <= B.MaxCode;

        /// <summary>
        /// Determines whether a byte can be interpreted as a <see cref='OctalDigitValue'/>
        /// </summary>
        /// <param name="c">The character to test</param>
        [MethodImpl(Inline), Op]
        public static bool test(Base2 @base, byte c)
            => (BinaryDigitValue)c >= B.MinDigit && (BinaryDigitValue)c <= B.MaxDigit;

        /// <summary>
        /// Determines whether a character can be interpreted as a <see cref='OctalDigitCode'/> or <see cref='OctalDigitSym'/>
        /// </summary>
        /// <param name="c">The character to test</param>
        [MethodImpl(Inline), Op]
        public static bool test(Base8 @base, char c)
            => (OctalDigitCode)c >= O.MinCode && (OctalDigitCode)c <= O.MaxCode;

        /// <summary>
        /// Determines whether a byte can be interpreted as a <see cref='OctalDigitValue'/>
        /// </summary>
        /// <param name="c">The character to test</param>
        [MethodImpl(Inline), Op]
        public static bool test(Base8 @base, byte c)
            => (OctalDigitValue)c >= O.MinDigit && (OctalDigitValue)c <= O.MaxDigit;

        /// <summary>
        /// Determines whether a character can be interpreted as a <see cref='DecimalDigitCode'/> or <see cref='DecimalDigitSym'/>
        /// </summary>
        /// <param name="c">The character to test</param>
        [MethodImpl(Inline), Op]
        public static bool test(Base10 @base, char c)
            => (DecimalDigitCode)c >= D.MinCode && (DecimalDigitCode)c <= D.MaxCode;

        /// <summary>
        /// Determines whether a character can be interpreted as a <see cref='DecimalDigitValue'/>
        /// </summary>
        /// <param name="c">The character to test</param>
        [MethodImpl(Inline), Op]
        public static bool test(Base10 @base, byte c)
            => (DecimalDigitValue)c >= D.MinDigit && (DecimalDigitValue)c <= D.MaxDigit;

        /// <summary>
        /// Determines whether a character can be interpreted as a <see cref='HexDigitValue'/>
        /// </summary>
        /// <param name="c">The character to test</param>
        [MethodImpl(Inline), Op]
        public static bool test(Base16 @base, char c)
            => scalar(@base, c) || upper(@base, c) || lower(@base,c);

        /// <summary>
        /// Determines whether a character corresponds to one of the lower hex codes
        /// </summary>
        /// <param name="c">The character to test</param>
        [MethodImpl(Inline), Op]
        public static bool scalar(Base16 @base, char c)
            => (HexDigitCode)c >= X.MinScalarCode && (HexDigitCode)c <= X.MaxScalarCode;

        /// <summary>
        /// Determines whether a character corresponds to one of the uppercase hex code characters
        /// </summary>
        /// <param name="c">The character to test</param>
        [MethodImpl(Inline), Op]
        public static bool upper(Base16 @base, char c)
            => (HexDigitCode)c >= X.MinLetterCodeU && (HexDigitCode)c <= X.MaxLetterCodeU;

        /// <summary>
        /// Determines whether a character corresponds to one of the lowercase hex code characters
        /// </summary>
        /// <param name="c">The character to test</param>
        [MethodImpl(Inline), Op]
        public static bool lower(Base16 @base, char c)
            => (HexDigitCode)c >= X.MinLetterCodeL && (HexDigitCode)c <= X.MaxLetterCodeL;
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Lo = HexLowerSym;
    using Up = HexUpperSym;

    /// <summary>
    /// Defines the symbols that represent both upper and lower-case base-16 digits
    /// </summary>
    [SymSource]
    public enum HexDigitSym : ushort
    {
        /// <summary>
        /// Specifies 0 base 16, asci code 48
        /// </summary>
        x0 = Lo.x0,

        /// <summary>
        /// Specifies 1 base 16, asci code 49
        /// </summary>
        x1 = Lo.x1,

        /// <summary>
        /// Specifies 2 base 16, asci code 50
        /// </summary>
        x2 = Lo.x2,

        /// <summary>
        /// Specifies 3 base 16, asci code 51
        /// </summary>
        x3 = Lo.x3,

        /// <summary>
        /// Specifies 4 base 16, asci code 52
        /// </summary>
        x4 = '4',

        /// <summary>
        /// Specifies 5 base 16
        /// </summary>
        x5 = '5',

        /// <summary>
        /// Specifies 6 base 16
        /// </summary>
        x6 = '6',

        /// <summary>
        /// Specifies 7 base 16
        /// </summary>
        x7 = '7',

        /// <summary>
        /// Specifies 8 base 16
        /// </summary>
        x8 = '8',

        /// <summary>
        /// Specifies 9 base 16
        /// </summary>
        x9 = '9',

        /// <summary>
        /// Specifies 10 base 16, asci code 65
        /// </summary>
        A = Up.A,

        /// <summary>
        /// Specifies 11 base 16, asci code 66
        /// </summary>
        B = Up.B,

        /// <summary>
        /// Specifies 12 base 16, asci code 67
        /// </summary>
        C = Up.C,

        /// <summary>
        /// Specifies 13 base 16, asci code 68
        /// </summary>
        D = Up.D,

        /// <summary>
        /// Specifies 14 base 16, asci code 69
        /// </summary>
        E = Up.E,

        /// <summary>
        /// Specifies 15 base 16, asci code 70
        /// </summary>
        F = Up.F,

        /// <summary>
        /// Specifies 10 base 16, asci code 97
        /// </summary>
        a = Lo.a,

        /// <summary>
        /// Specifies 10 base 16, asci code 98
        /// </summary>
        b = Lo.b,

        /// <summary>
        /// Specifies 10 base 16, asci code 99
        /// </summary>
        c = Lo.c,

        /// <summary>
        /// Specifies 10 base 16, asci code 100
        /// </summary>
        d = Lo.d,

        /// <summary>
        /// Specifies 10 base 16, asci code 101
        /// </summary>
        e = Lo.e,

        /// <summary>
        /// Specifies 10 base 16, asci code 102
        /// </summary>
        f = Lo.f,
    }
}
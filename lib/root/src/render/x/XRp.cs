//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    partial class XTend
    {
        [Op]
        public static string Format(this sbyte i, byte n)
            => string.Format(RP.digits(n), i);

        [Op]
        public static string Format(this byte i, byte n)
            => string.Format(RP.digits(n), i);

        [Op]
        public static string Format(this short i, byte n)
            => string.Format(RP.digits(n), i);

        [Op]
        public static string Format(this ushort i, byte n)
            => string.Format(RP.digits(n), i);

        [Op]
        public static string Format(this int i, byte n)
            => string.Format(RP.digits(n), i);

        [Op]
        public static string Format(this uint i, byte n)
            => string.Format(RP.digits(n), i);
    }
}
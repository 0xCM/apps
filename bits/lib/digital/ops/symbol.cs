//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct Digital
    {
        [MethodImpl(Inline), Op]
        public static BinaryDigitSym symbol(BinaryDigitValue src)
            => (BinaryDigitSym)(src + (byte)BinarySymFacet.First);

        [MethodImpl(Inline), Op]
        public static OctalDigitSym symbol(OctalDigitValue src)
            => (OctalDigitSym)((byte)src + (byte)OctalSymFacet.First);

        [MethodImpl(Inline), Op]
        public static BinaryDigitSym symbol(Base2 @base, byte src)
            => (BinaryDigitSym)(src + (byte)BinarySymFacet.First);

        [MethodImpl(Inline), Op]
        public static DecimalDigitSym symbol(DecimalDigitValue src)
            => (DecimalDigitSym)((byte)src + DecimalSymFacet.First);

        [MethodImpl(Inline), Op]
        public static HexDigitSym symbol(UpperCased @case, HexDigitValue src)
            => Hex.symbol(@case, src);

        [MethodImpl(Inline), Op]
        public static HexDigitSym symbol(LowerCased @case, HexDigitValue src)
            => Hex.symbol(@case, src);
    }
}
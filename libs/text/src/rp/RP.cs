//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static SeqEnclosureKind;
    using static Chars;

    [LiteralProvider]
    public partial class RP
    {
        [MethodImpl(Inline), Op]
        public static string pad(int pad)
            => pad == 0 ? "{0}" : "{0," + pad.ToString() + "}";

/*
        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public static DataSlot<T> dataslot<T>(byte index, short pad)
            => new DataSlot<T>(index, pad);

        [MethodImpl(Inline), Op]
        public static DataSlot dataslot(byte index, short pad)
            => new DataSlot(index, pad);

        public static DataSlot[] dataslots(short[] padding)
        {
            var count = padding.Length;
            var slots = new DataSlot[count];
            for(var i=0; i<count; i++)
                slots[i] = dataslot((byte)i, padding[i]);
            return slots;
        }

*/
        /// <summary>
        /// Defines the format pattern '{n,pad}'
        /// </summary>
        /// <param name="n">The zero-based slot index</param>
        /// <param name="pad">The pad width specifier</param>
        [MethodImpl(Inline), Op]
        public static string pad(uint n, int pad)
            => "{0" + n.ToString() + "," + pad.ToString() + "}";

        [MethodImpl(Inline), Op]
        public static char left(SeqEnclosureKind kind)
            => kind == Embraced ? LBrace : kind == Bracketed ? LBracket : LParen;

        [MethodImpl(Inline), Op]
        public static char right(SeqEnclosureKind kind)
            => kind == Embraced ? RBrace : kind == Bracketed ? RBracket : RParen;

        [MethodImpl(Inline)]
        static string msgarg<T>(T src)
            => string.Format("<{0}>", src);

        public static string msg<T>(string pattern, T a)
            => string.Format(pattern, msgarg(a));
    }
}
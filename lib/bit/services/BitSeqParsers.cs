//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public readonly struct BitSeqParsers
    {
        [Parser]
        public static Outcome parse(string src, out bits<byte> dst)
            => u8().Parse(src,out dst);

        [Parser]
        public static Outcome parse(string src, out bits<sbyte> dst)
            => i8().Parse(src,out dst);

        [Parser]
        public static Outcome parse(string src, out bits<short> dst)
            => i16().Parse(src,out dst);

        [Parser]
        public static Outcome parse(string src, out bits<ushort> dst)
            => u16().Parse(src,out dst);

        [Parser]
        public static Outcome parse(string src, out bits<int> dst)
            => i32().Parse(src,out dst);

        [Parser]
        public static Outcome parse(string src, out bits<uint> dst)
            => u32().Parse(src,out dst);

        [Parser]
        public static Outcome parse(string src, out bits<long> dst)
            => i64().Parse(src,out dst);

        [Parser]
        public static Outcome parse(string src, out bits<ulong> dst)
            => u64().Parse(src,out dst);

        public static BitsParser<byte> u8()
            => BitsParser<byte>.Service;

        public static BitsParser<sbyte> i8()
            => BitsParser<sbyte>.Service;

        public static BitsParser<ushort> u16()
            => BitsParser<ushort>.Service;

        public static BitsParser<short> i16()
            => BitsParser<short>.Service;

        public static BitsParser<uint> u32()
            => BitsParser<uint>.Service;

        public static BitsParser<int> i32()
            => BitsParser<int>.Service;

        public static BitsParser<ulong> u64()
            => BitsParser<ulong>.Service;

        public static BitsParser<long> i64()
            => BitsParser<long>.Service;
    }
}
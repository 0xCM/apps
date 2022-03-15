//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct BitNumbers
    {
        static Outcome parse(string src, byte width, out byte b)
        {
            var count = 0;
            b = default;
            var storage = 0ul;
            var buffer = recover<bit>(slice(bytes(storage), 0, width));
            count = Z0.bits.parse(src, buffer);
            if(count >= 0)
            {
                b = BitPack.scalar<byte>(buffer);
                return true;
            }

            var i = text.index(src, HexFormatSpecs.PreSpec);
            var result = false;
            if(i >=0)
                result = HexParser.parse8u(src, out b);
            else
                result = DataParser.parse(src, out b);
            return result;
        }

        [Parser]
        public static Outcome parse(string src, out uint2 dst)
        {
            var result = parse(src, 2, out byte b);
            if(result)
                dst = b;
            else
                dst = default;
            return result;
        }

        [Parser]
        public static Outcome parse(string src, out uint3 dst)
        {
            var result = parse(src, 3, out byte b);
            if(result)
                dst = b;
            else
                dst = default;
            return result;
        }

        [Parser]
        public static Outcome parse(string src, out uint4 dst)
        {
            var result = parse(src, 4, out byte b);
            if(result)
                dst = b;
            else
                dst = default;
            return result;
        }

        [Parser]
        public static Outcome parse(string src, out uint5 dst)
        {
            var result = parse(src, 5, out byte b);
            if(result)
                dst = b;
            else
                dst = default;
            return result;
        }

        [Parser]
        public static Outcome parse(string src, out uint6 dst)
        {
            var result = parse(src, 6, out byte b);
            if(result)
                dst = b;
            else
                dst = default;
            return result;
        }

        [Parser]
        public static Outcome parse(string src, out uint7 dst)
        {
            var result = parse(src, 7, out byte b);
            if(result)
                dst = b;
            else
                dst = default;
            return result;
        }

        [Parser]
        public static Outcome parse(string src, out uint8b dst)
        {
            var result = parse(src, 8, out byte b);
            if(result)
                dst = b;
            else
                dst = default;
            return result;
        }
    }
}
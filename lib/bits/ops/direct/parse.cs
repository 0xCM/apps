//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static bit;

    partial class bits
    {
        /// <summary>
        /// Constructs a bitstring from text
        /// </summary>
        /// <param name="src">The bit source</param>
        [Op]
        public static int parse(string src, out Span<bit> dst)
        {
            dst = alloc<bit>(src.Length);
            var count = parse(src,dst);
            if(count >= 0)
                dst = core.slice(dst, 0, count);
            else
                dst = default;
            return count;
        }

        public static int parse(string src, byte n, out byte dst)
        {
            var storage = 0ul;
            var width = min(n, (byte)8);
            dst = 0;
            var buffer = recover<bit>(core.slice(core.bytes(storage), 0, width));
            var count = parse(src, buffer);
            if(count >= 0)
                dst = BitPack.scalar<byte>(buffer);
            return count;
        }

        public static int parse(string src, byte n, out ushort dst)
        {
            var storage = 0ul;
            var width = min(n, (byte)16);
            dst = 0;
            var buffer = recover<bit>(core.slice(core.bytes(storage), 0, width));
            var count = parse(src, buffer);
            if(count >= 0)
                dst = BitPack.scalar<ushort>(buffer);
            return count;
        }

        public static int parse(string src, byte n, out uint dst)
        {
            var storage = 0ul;
            var width = min(n, (byte)32);
            dst = 0;

            var buffer = recover<bit>(core.slice(core.bytes(storage), 0, width));
            var count = parse(src, buffer);
            if(count >= 0)
                dst = BitPack.scalar<uint>(buffer);
            return count;
        }

        public static int parse(string src, byte n, out ulong dst)
        {
            var storage = 0ul;
            var width = min(n, (byte)64);
            dst = 0;
            var buffer = recover<bit>(core.slice(core.bytes(storage), 0, width));
            var count = parse(src, buffer);
            if(count >= 0)
                dst = BitPack.scalar<ulong>(buffer);
            return count;
        }

        public static int parse(string src, Span<bit> dst)
        {
            var input = core.span(src.RemoveBlanks().Remove("0b").Remove("_")).Reverse();
            if(input.Length > dst.Length)
                return -1;

            var result = true;
            var count = input.Length;
            var counter = 0;
            for(var i=0; i<count; i++)
            {
                ref readonly var c = ref skip(input,i);
                ref var bit = ref seek(dst, i);
                if(c == bit.Zero)
                    bit = Off;
                else if(c == bit.One)
                    bit = On;
                else
                {
                    result = false;
                    break;
                }
                counter++;
            }
            return result ? counter : -1;
        }
    }
}
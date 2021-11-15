//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public readonly struct BitsParser
    {
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

    [Parser(typeof(bits<>))]
    public readonly struct BitsParser<T> : IParser<bits<T>>
        where T : unmanaged
    {
        public static BitsParser<T> Service => default;
        public Outcome Parse(string src, out bits<T> dst)
        {
            var result = Outcome.Success;
            dst = default;
            result = text.unfence(src, RenderFence.Embraced, out var content);
            if(!result)
                return (false,"Fence not found");

            var parts = text.split(content, Chars.Comma);
            var n = (uint)parts.Length;
            var storage = default(T);
            var target = bytes(storage);
            var size = target.Length;
            var k = 0u;
            for(var i=0; i<size; i++)
            {
                ref var b = ref seek(target,i);
                for(byte j=0; j<8 && k < n; j++, k++)
                {
                    ref readonly var part = ref skip(parts,k);
                    if(bit.digit(part,out var d))
                        b |= (Bytes.sll((byte)d,j));
                }
            }
            dst = new bits<T>(n,storage);

            return result;
        }
    }
}
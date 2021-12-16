//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Root;
    using static core;

    public readonly struct BitsParser<T> : IParser<bits<T>>
        where T : unmanaged
    {
        public static BitsParser<T> Service => default;

        public static Outcome parse(string src, out bits<T> dst)
        {
            var result = Outcome.Success;
            dst = default;
            result = text.unfence(src, Fencing.Embraced, out var content);
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

        public Outcome Parse(string src, out bits<T> dst)
            => parse(src, out dst);
    }
}
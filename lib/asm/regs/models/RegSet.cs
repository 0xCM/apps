//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public readonly struct RegOpSeq : ISeq<RegOp>
    {
        Index<RegOp> Data {get;}

        [MethodImpl(Inline)]
        public RegOpSeq(RegOp[] src)
        {
            Data = src;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public ref readonly RegOp this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public ReadOnlySpan<RegOp> Elements
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        public RegOpSeq Concat(params RegOpSeq[] src)
        {
            var count = Count + gcalc.sum(src.Map(x => x.Count));
            var dst = alloc<RegOp>(count);
            var j=0;
            for(var i=0u; i<Count; i++)
                seek(dst,j++) = this[i];

            for(var k=0; k<src.Length; k++)
            {
                ref readonly var set = ref skip(src,k);
                var kset = set.Count;
                for(var m=0u; m<kset; m++)
                    seek(dst,j++) = set[m];
            }

            return dst;
        }

        [MethodImpl(Inline)]
        public RegOpSeq Replicate()
            => new RegOpSeq(Data);

        [MethodImpl(Inline)]
        public static implicit operator RegOpSeq(RegOp[] src)
            => new RegOpSeq(src);

        public static RegOpSeq Empty
            => new RegOpSeq(sys.empty<RegOp>());
    }
}
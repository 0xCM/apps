//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct RegSet
    {
        Index<RegOp> Data {get;}

        [MethodImpl(Inline)]
        public RegSet(RegOp[] src)
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

        public ReadOnlySpan<RegOp> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        [MethodImpl(Inline)]
        public RegSet Replicate()
            => new RegSet(Data);

        [MethodImpl(Inline)]
        public static implicit operator RegSet(RegOp[] src)
            => new RegSet(src);

        public static RegSet Empty
            => new RegSet(sys.empty<RegOp>());
    }
}
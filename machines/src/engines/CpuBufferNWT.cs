//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Machines
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public struct CpuBuffer<N,W,T>
        where N : unmanaged, ITypeNat
        where W : unmanaged, ITypeWidth
        where T : unmanaged
    {
        readonly Index<T> Data;

        [MethodImpl(Inline)]
        public CpuBuffer(T[] data)
            => Data = data;

        public int Length
        {
            [MethodImpl(Inline)]
            get => (int)nat64u<N>();
        }

        public Span<T> Edit
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        [MethodImpl(Inline)]
        public void Clear(W16 w)
        {
            first(Data.Edit.Recover<T,ushort>()) = z16;
        }

        [MethodImpl(Inline)]
        public void Clear(W32 w)
        {
            first(Data.Edit.Recover<T,uint>()) = z32;
        }

        [MethodImpl(Inline)]
        public void Clear(W64 w)
        {
            first(Data.Edit.Recover<T,ulong>()) = z64;
        }

        [MethodImpl(Inline)]
        public void Clear(W128 w)
        {
            first(Data.Edit.Recover<T,Cell128>()) = Cell128.Empty;
        }
    }
}
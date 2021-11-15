//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Types
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public struct vector<N,T> : IVector<T>
        where T : unmanaged
        where N : unmanaged, ITypeNat
    {
        public static ByteSize SZ => size<T>()*Typed.nat32u<N>();

        readonly Index<T> Data;

        [MethodImpl(Inline)]
        internal vector(T[] src)
        {
            Data = src;
        }

        public Span<T> Cells
        {
            [MethodImpl(Inline)]
            get => Data.Edit;
        }

        [MethodImpl(Inline)]
        public ref T Cell(uint index)
            => ref Data[index];

        public ref T this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Cell(index);
        }

        public string Format()
            => vectors.format(this);

        public override string ToString()
            => Format();

        BitWidth IBlittable.StorageWidth
            => Data.Length*width<T>();

        BitWidth IBlittable.ContentWidth
            => Data.Length* Typed.nat32u<N>();

        uint IVector.N
            => Typed.nat32u<N>();

        public static vector<N,T> Empty => default;
    }
}
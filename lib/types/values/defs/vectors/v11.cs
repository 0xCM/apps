//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Types
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;
    using static core;

    /// <summary>
    /// Defines an 11-cell T-vector
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct v11<T> : IVector<T>
        where T : unmanaged
    {
        v10<T> A;

        v1<T> B;

        public uint N => 11;

        public BitWidth StorageWidth
        {
            [MethodImpl(Inline)]
            get => N*size<T>();
        }

        public BitWidth ContentWidth
        {
            [MethodImpl(Inline)]
            get => StorageWidth;
        }

        public Span<T> Cells
        {
            [MethodImpl(Inline)]
            get => TS.cells(ref this);
        }

        public ref T this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref seek(Cells, i);
        }

        public string Format()
            => TS.format(this);

        public override string ToString()
            => Format();
    }
}
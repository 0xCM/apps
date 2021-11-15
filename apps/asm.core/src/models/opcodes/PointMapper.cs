//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct PointMapper<I,T>
        where I : unmanaged
        where T : unmanaged
    {
        readonly Index<I,PointMap<I,T>> Storage;

        public PointMapper(PointMap<I,T>[] maps)
        {
            Storage = maps;
        }

        [MethodImpl(Inline)]
        public ref PointMap<I,T> Map(I index)
            => ref Storage[index];

        public ref PointMap<I,T> this[I index]
        {
            [MethodImpl(Inline)]
            get => ref Map(index);
        }

        public Span<PointMap<I,T>> Points
        {
            [MethodImpl(Inline)]
            get => Storage.Edit;
        }

        public uint PointCount
        {
            [MethodImpl(Inline)]
            get => Storage.Count;
        }
    }
}
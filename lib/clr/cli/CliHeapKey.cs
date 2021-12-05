//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct CliHeapKey : ICliHeapKey<CliHeapKey>
    {
        public CliHeapKind HeapKind {get;}

        public uint Value {get;}

        [MethodImpl(Inline)]
        public CliHeapKey(CliHeapKind heap, uint value)
        {
            HeapKind = heap;
            Value = value;
        }
    }

    public readonly struct CliHeapKey<K> : ICliHeapKey<CliHeapKey<K>>
        where K : unmanaged, ICliHeapKey
    {
        public CliHeapKind HeapKind => default(K).HeapKind;

        public uint Value {get;}

        [MethodImpl(Inline)]
        public CliHeapKey(uint value)
        {
            Value = value;
        }

        [MethodImpl(Inline)]
        public bool Equals(CliHeapKey<K> src)
            => Value.Equals(src.Value);

        [MethodImpl(Inline)]
        public int CompareTo(CliHeapKey<K> src)
            => Value.CompareTo(src.Value);

        [MethodImpl(Inline)]
        public static implicit operator CliHeapKey(CliHeapKey<K> src)
            => new CliHeapKey(src.HeapKind, src.Value);
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection.Metadata;

    using static Root;

    public readonly struct GuidIndex : ICliHeapKey<GuidIndex>
    {
        public CliHeapKind HeapKind => CliHeapKind.Guid;

        public uint Value {get;}

        [MethodImpl(Inline)]
        public GuidIndex(uint value)
        {
            Value = value;
        }

        [MethodImpl(Inline)]
        public GuidIndex(GuidHandle value)
        {
            Value = core.u32(value);
        }

        [MethodImpl(Inline)]
        public static implicit operator GuidIndex(GuidHandle src)
            => new GuidIndex(src);

        [MethodImpl(Inline)]
        public static implicit operator CliHeapKey(GuidIndex src)
            => new CliHeapKey(src.HeapKind, src.Value);
    }
}
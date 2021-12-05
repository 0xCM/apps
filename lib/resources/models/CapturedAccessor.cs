//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct CapturedAccessor
    {
        public static CapturedAccessor define(uint index, in SpanResAccessor accessor, MemorySeg seg)
        {
            var name = string.Format("{0}/{1}", accessor.Member.DeclaringType.Name, accessor.Member.DisplayName());
            return new CapturedAccessor(index,name, seg);
        }

        public uint Index {get;}

        public CharBlock128 Name {get;}

        readonly MemorySeg Segment;

        [MethodImpl(Inline)]
        internal CapturedAccessor(uint index, string name, MemorySeg seg)
        {
            Index = index;
            Name = name;
            Segment = seg;
        }

        public MemoryAddress BaseAddress
        {
            [MethodImpl(Inline)]
            get => Segment.BaseAddress;
        }

        public ByteSize Size
        {
            [MethodImpl(Inline)]
            get => Segment.Size;
        }

        public ReadOnlySpan<byte> Code
        {
            [MethodImpl(Inline)]
            get => Segment.Load();
        }

        public string Format()
            => string.Format("x{0}[{1:D5}:{2:D5}]:{3}", BaseAddress, Index, (uint)Size, Name);

        public override string ToString()
            => Format();
    }
}
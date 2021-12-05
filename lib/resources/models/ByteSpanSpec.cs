//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    using api = SpanRes;

    public readonly struct ByteSpanSpec : ISpanResSpec
    {
        public Identifier Name {get;}

        public BinaryCode Data {get;}

        public bool IsStatic {get;}

        public string CellType {get;}

        [MethodImpl(Inline)]
        public ByteSpanSpec(string name, byte[] data, bool isStatic = true)
        {
            Name = name;
            Data = data;
            IsStatic = isStatic;
            CellType = "byte";
        }

        public ref byte FirstByte
        {
            [MethodImpl(Inline)]
            get => ref Data.First;
        }

        public uint CellCount
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public ByteSize DataSize
        {
            [MethodImpl(Inline)]
            get => Data.Size;
        }

        [MethodImpl(Inline)]
        public ReadOnlySpan<byte> Segment(ByteSize offset, ByteSize size)
            => slice(Data.View, offset, size);

        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();
    }
}
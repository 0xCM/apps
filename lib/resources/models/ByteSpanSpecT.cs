//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using api = SpanRes;

    public readonly struct ByteSpanSpec<T> : ISpanResSpec
        where T : unmanaged
    {
        public Identifier Name {get;}

        public Index<T> Data {get;}

        public bool IsStatic {get;}

        public string CellType {get;}

        [MethodImpl(Inline)]
        public ByteSpanSpec(string name, T[] data, bool isStatic = true)
        {
            Name = name;
            Data = data;
            IsStatic = isStatic;
            CellType = "byte";
        }

        public ref T FirstCell
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

        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();
    }
}
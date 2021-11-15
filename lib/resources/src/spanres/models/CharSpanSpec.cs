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

    public readonly struct CharSpanSpec : ISpanResSpec
    {
        public Identifier Name {get;}

        public string _Data {get;}

        public bool IsStatic {get;}

        public string CellType {get;}

        [MethodImpl(Inline)]
        public CharSpanSpec(string name, string data, bool isStatic = true)
        {
            Name = name;
            _Data = data;
            IsStatic = isStatic;
            CellType = "char";
        }

        public ReadOnlySpan<char> Data
        {
            get => _Data;
        }

        public ref readonly char FirstCell
        {
            [MethodImpl(Inline)]
            get => ref first(Data);
        }

        public uint CellCount
        {
            [MethodImpl(Inline)]
            get => (uint)Data.Length;
        }

        public ByteSize DataSize
        {
            [MethodImpl(Inline)]
            get => CellCount*2;
        }

        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();
    }
}
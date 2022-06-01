//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public readonly struct CharSpanSpec
    {
        public readonly Identifier Name {get;}

        public readonly string _Data {get;}

        public readonly bool IsStatic {get;}

        public readonly string CellType {get;}

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
    }
}
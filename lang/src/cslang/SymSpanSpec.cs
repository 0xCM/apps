//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly ref struct SymSpanSpec
    {
        public readonly Identifier Name {get;}

        public readonly ReadOnlySpan<Sym> Data {get;}

        public readonly bool IsStatic {get;}

        public readonly string CellType {get;}

        [MethodImpl(Inline)]
        public SymSpanSpec(string name, ReadOnlySpan<Sym> data, bool isStatic, string type)
        {
            Name = name;
            Data = data;
            IsStatic = isStatic;
            CellType = type;
        }

        public uint CellCount
        {
            [MethodImpl(Inline)]
            get => (uint)Data.Length;
        }
    }
}
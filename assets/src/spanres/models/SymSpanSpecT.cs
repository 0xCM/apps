//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly ref struct SymSpanSpec<T>
        where T : unmanaged
    {
        public readonly Identifier Name {get;}

        public readonly ReadOnlySpan<Sym<T>> Data {get;}

        public readonly bool IsStatic {get;}

        public readonly string CellType {get;}

        [MethodImpl(Inline)]
        public SymSpanSpec(string name, ReadOnlySpan<Sym<T>> data, bool isStatic = true, string type = null)
        {
            Name = name;
            Data = data;
            IsStatic = isStatic;
            CellType = type ?? typeof(T).Name;
        }

        public uint CellCount
        {
            [MethodImpl(Inline)]
            get => (uint)Data.Length;
        }
    }
}
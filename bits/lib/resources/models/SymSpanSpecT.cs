//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly ref struct SymSpanSpec<T>
        where T : unmanaged
    {
        public Identifier Name {get;}

        public ReadOnlySpan<Sym<T>> Data {get;}

        public bool IsStatic {get;}

        public string CellType {get;}

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
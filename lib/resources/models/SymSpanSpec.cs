//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly ref struct SymSpanSpec
    {
        public Identifier Name {get;}

        public ReadOnlySpan<Sym> Data {get;}

        public bool IsStatic {get;}

        public string CellType {get;}

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
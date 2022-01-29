//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public class LiteralSeq<T> : ILiteralSeq<T>
        where T : IEquatable<T>, IComparable<T>
    {
        Index<Literal<T>> Data;

        public Identifier Name {get;}

        public LiteralSeq(Identifier name, Literal<T>[] values)
        {
            Name = name;
            Data = values;
        }

        public ReadOnlySpan<Literal<T>> Elements
        {
            [MethodImpl(Inline)]
            get => Data;
        }


        public ref readonly Literal<T> this[ulong index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public ref readonly Literal<T> this[long index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }
    }
}
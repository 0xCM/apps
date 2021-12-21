//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public interface ILiteralSeq<T> : ISeq<Literal<T>>
    {

    }

    public interface IEnum
    {
        Identifier Name {get;}

        Type LiteralType {get;}

    }

    public interface IEnum<T> : IEnum, ILiteralSeq<T>
        where T : IEquatable<T>, IComparable<T>
    {
        ReadOnlySpan<Literal<T>> Members {get;}

        ReadOnlySpan<Literal<T>> ISeq<Literal<T>>.Elements
            => Members;
    }

    public class Enum<T> : IEnum<T>
        where T : IEquatable<T>, IComparable<T>
    {
        protected Index<Literal<T>> Data;

        public Identifier Name {get;}

        public Enum(Identifier name, Literal<T>[] values)
        {
            Name = name;
            Data = values;
        }

        public Type LiteralType
            => typeof(T);

        public ReadOnlySpan<Literal<T>> Members
        {
            [MethodImpl(Inline)]
            get => Data;
        }
    }

    public class Enum8u : Enum<byte>
    {
        public Enum8u(Identifier name, Literal<byte>[] values)
            : base(name, values)
        {
            Data = values;
        }
    }

    public class Enum8i : Enum<sbyte>
    {
        public Enum8i(Identifier name, Literal<sbyte>[] values)
            : base(name, values)
        {
            Data = values;
        }
    }

    public class Enum16u : Enum<ushort>
    {
        public Enum16u(Identifier name, Literal<ushort>[] values)
            : base(name, values)
        {
            Data = values;
        }
    }

    public class Enum16i : Enum<short>
    {
        public Enum16i(Identifier name, Literal<short>[] values)
            : base(name, values)
        {
            Data = values;
        }
    }

    public class Enum32u : Enum<uint>
    {
        public Enum32u(Identifier name, Literal<uint>[] values)
            : base(name, values)
        {
            Data = values;
        }
    }

    public class Enum32i : Enum<int>
    {
        public Enum32i(Identifier name, Literal<int>[] values)
            : base(name, values)
        {
            Data = values;
        }
    }

    public class Enum64u : Enum<ulong>
    {
        public Enum64u(Identifier name, Literal<ulong>[] values)
            : base(name, values)
        {
            Data = values;
        }
    }

    public class Enum64i : Enum<long>
    {
        public Enum64i(Identifier name, Literal<long>[] values)
            : base(name, values)
        {
            Data = values;
        }
    }
}
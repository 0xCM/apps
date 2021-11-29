//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct TableId<I,T> : ITableId
        where T : struct, IRecord<T>
        where I : unmanaged
    {
        public TableId Value {get;}

        public I Index {get;}

        [MethodImpl(Inline)]
        public TableId(TableId value, I index)
        {
            Value = value;
            Index = index;
        }

        public Name Identifier
            => Value.Identifier;

        public Name Identity
            => Value.Identity;

        [MethodImpl(Inline)]
        public string Format()
            => Identifier.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator TableId(TableId<I,T> src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator TableId<T>(TableId<I,T> src)
            => new TableId<T>(src.Value);
    }
}
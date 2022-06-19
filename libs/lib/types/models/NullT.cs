//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct Null<T> : ITextual, INullity, INullary<Null>, IType
        where T : IType
    {
        public static Null<T> Empty => default;

        public Identifier Name => "null<" + typeof(T).Name + ">";
        public bool IsEmpty
            => true;

        public Null<T> Zero
            => Empty;

        public ulong Kind
            => 0;

        [MethodImpl(Inline)]
        public string Format()
            => Name;

        public override string ToString()
            => Format();
    }
}
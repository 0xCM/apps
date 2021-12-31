//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    public readonly struct ResolvedVar<T> : IValue<T>, ITerm<T>
    {
        public readonly T Value;

        [MethodImpl(Inline)]
        public ResolvedVar(T value)
        {
            Value = value;
        }

        T IValue<T>.Value
            => Value;

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Value == null;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Value != null;
        }

        public string Format()
            => IsNonEmpty ? Value.ToString() : EmptyString;

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator ResolvedVar<T>(T src)
            => new ResolvedVar<T>(src);

        [MethodImpl(Inline)]
        public static implicit operator ResolvedVar(ResolvedVar<T> src)
            => new ResolvedVar(src.Value);
    }
}
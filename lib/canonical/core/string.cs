//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Types
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public readonly struct @string : ITerm<string>
    {
        readonly string Data;

        [MethodImpl(Inline)]
        public @string(string src)
        {
            Data = src;
        }

        public string Value
        {
            [MethodImpl(Inline)]
            get => Data ?? EmptyString;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => empty(Data);
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => nonempty(Data);
        }

        public string Format()
            => Value;

        public override string ToString()
            => Format();

        public bool Equals(@string src)
            => Value.Equals(src.Value);

        public static @string Empty
        {
            [MethodImpl(Inline)]
            get => new @string(EmptyString);
        }

        [MethodImpl(Inline)]
        public static implicit operator @string(string src)
            => new @string(src);

        [MethodImpl(Inline)]
        public static implicit operator string(@string src)
            => src.Value;
    }
}
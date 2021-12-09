//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct TypeSpec : INullity, IEquatable<TypeSpec>
    {
        readonly string Pattern;

        [MethodImpl(Inline)]
        public TypeSpec(string src)
        {
            Pattern = src;
        }

        public string Text
        {
            [MethodImpl(Inline)]
            get => Pattern ?? EmptyString;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => text.empty(Pattern);
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => text.nonempty(Pattern);
        }

        [MethodImpl(Inline)]
        public bool Equals(TypeSpec src)
            => Text.Equals(src.Text);

        [MethodImpl(Inline)]
        public static implicit operator TypeSpec(string src)
            => new TypeSpec(src);

        [MethodImpl(Inline)]
        public static implicit operator string(TypeSpec src)
            => src.Text;

        public string Format()
            => Text;

        public override string ToString()
            => Format();

    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct TypeSpecifier : INullity, IEquatable<TypeSpecifier>
    {
        readonly string Pattern;

        [MethodImpl(Inline)]
        public TypeSpecifier(string src)
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
        public bool Equals(TypeSpecifier src)
            => Text.Equals(src.Text);

        [MethodImpl(Inline)]
        public static implicit operator TypeSpecifier(string src)
            => new TypeSpecifier(src);

        [MethodImpl(Inline)]
        public static implicit operator string(TypeSpecifier src)
            => src.Text;

        public string Format()
            => Text;

        public override string ToString()
            => Format();

    }
}
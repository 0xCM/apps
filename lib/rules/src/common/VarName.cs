//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct VarName : ITextual
    {
        readonly string Value;

        [MethodImpl(Inline)]
        public VarName(string value)
        {
            Value = value;
        }

        public string Content
        {
            [MethodImpl(Inline)]
            get => Value ?? EmptyString;
        }

        [MethodImpl(Inline)]
        public VarDecoration Decorate(VarDecorator decorator)
            => new VarDecoration(this,decorator);

        [MethodImpl(Inline)]
        public string Format()
            => Content;

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator string(VarName src)
            => src.Content;

        [MethodImpl(Inline)]
        public static implicit operator VarName(string src)
            => new VarName(src);
    }
}
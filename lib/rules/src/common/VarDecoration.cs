//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct VarDecoration : ITextual
    {
        public VarName Name {get;}

        public VarDecorator Decorator {get;}

        [MethodImpl(Inline)]
        public VarDecoration(VarName name, VarDecorator decorator)
        {
            Name = name;
            Decorator = decorator;
        }

        [MethodImpl(Inline)]
        public string Format()
            => string.Format(Decorator.Pattern, Name);

        public override string ToString()
            => Format();
    }
}
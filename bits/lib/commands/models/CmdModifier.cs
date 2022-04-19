//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public readonly struct CmdModifier
    {
        public @string Value {get;}

        [MethodImpl(Inline)]
        public CmdModifier(@string value)
        {
            Value = value;
        }

        [MethodImpl(Inline)]
        public string Format()
            => Value.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator CmdModifier(string src)
            => new CmdModifier(src);
    }
}
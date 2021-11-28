//-----------------------------------------------------------------------------
// Copyright   : (c) Chris Moore, 2020
// License     : MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct CmdJob : ITextual
    {
        public Name Name {get;}

        public TextBlock Spec {get;}

        [MethodImpl(Inline)]
        public CmdJob(Name name, TextBlock spec)
        {
            Name = name;
            Spec = spec;
        }

        [MethodImpl(Inline)]
        public string Format()
            => Spec;

        public override string ToString()
            => Format();
    }
}
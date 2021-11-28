//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct CmdVerb<T>
    {
        readonly CmdVerb Verb;

        public T Flags {get;}

        [MethodImpl(Inline)]
        public CmdVerb(CmdVerb verb, T options)
        {
            Verb = verb;
            Flags = options;
        }

        public StringAddress Name
        {
            [MethodImpl(Inline)]
            get => Verb.Name;
        }

        public StringAddress Symbol
        {
            [MethodImpl(Inline)]
            get => Verb.Symbol;
        }
    }

}
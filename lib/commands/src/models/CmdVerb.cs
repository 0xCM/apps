//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct CmdVerb
    {
        public StringAddress Name {get;}

        public StringAddress Symbol {get;}

        [MethodImpl(Inline)]
        public CmdVerb(StringAddress name, StringAddress symbol)
        {
            Name = name;
            Symbol = symbol;
        }
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct LiteralProvider
    {
        public string Name {get;}

        public Type Definition {get;}

        [MethodImpl(Inline)]
        public LiteralProvider(string name, Type src)
        {
            Definition = src;
            Name = name;
        }
    }
}
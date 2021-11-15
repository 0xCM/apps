//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct VarDecorator
    {
        public string Pattern {get;}

        [MethodImpl(Inline)]
        public VarDecorator(string value)
        {
            Pattern = value;
        }

        [MethodImpl(Inline)]
        public static implicit operator VarDecorator(string src)
            => new VarDecorator(src);
    }
}
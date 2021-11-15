//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct ClrHandle
    {
        public CliToken Token {get;}

        public ClrArtifactKind Kind {get;}

        public Ptr Pointer {get;}

        [MethodImpl(Inline)]
        public ClrHandle(ClrArtifactKind kind, CliToken key, Ptr ptr)
        {
            Kind = kind;
            Token = key;
            Pointer = ptr;
        }
    }
}
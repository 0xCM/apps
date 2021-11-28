//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Represents a type parameter in a generic artifact definition
    /// </summary>
    public readonly struct ApiOpenSigParam : IOpenSigParam
    {
        public ushort Position {get;}

        public Name Name {get;}

        [MethodImpl(Inline)]
        public ApiOpenSigParam(ushort position, string name)
        {
            Position = position;
            Name = name;
        }
    }
}
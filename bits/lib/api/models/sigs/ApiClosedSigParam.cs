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
    public class ApiClosedSigParam : IClosedSigParam
    {
        public ushort Position {get;}

        public Name Name {get;}

        public ApiTypeSig Closure {get;}

        [MethodImpl(Inline)]
        public ApiClosedSigParam(ushort position, string name, ApiTypeSig closure)
        {
            Position = position;
            Name = name;
            Closure = closure;
        }
    }
}
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
    /// Represents either a closed or open type parameter
    /// </summary>
    public class ApiSigTypeParam : ISigTypeParam
    {
        public ushort Position {get;}

        public Name Name {get;}

        public ApiTypeSig Closure {get;}

        [MethodImpl(Inline)]
        public ApiSigTypeParam(ushort pos, string name)
        {
            Position = pos;
            Name = name;
            Closure = ApiTypeSig.Empty;
        }

        [MethodImpl(Inline)]
        public ApiSigTypeParam(ushort pos, string name, ApiTypeSig closure)
        {
            Position = pos;
            Name = name;
            Closure = closure;
        }

        public bool IsClosed
        {
            [MethodImpl(Inline)]
            get => Closure.IsNonEmpty;
        }

        public bool IsOpen
        {
            [MethodImpl(Inline)]
            get => !IsClosed;
        }
    }
}
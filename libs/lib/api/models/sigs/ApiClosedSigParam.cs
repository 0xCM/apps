//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Represents a type parameter in a generic artifact definition
    /// </summary>
    public class ApiClosedSigParam : IClosedSigParam
    {
        public ushort Position {get;}

        public NameOld Name {get;}

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
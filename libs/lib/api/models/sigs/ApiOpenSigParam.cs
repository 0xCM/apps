//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Represents a type parameter in a generic artifact definition
    /// </summary>
    public readonly struct ApiOpenSigParam : IOpenSigParam
    {
        public ushort Position {get;}

        public NameOld Name {get;}

        [MethodImpl(Inline)]
        public ApiOpenSigParam(ushort position, string name)
        {
            Position = position;
            Name = name;
        }
    }
}
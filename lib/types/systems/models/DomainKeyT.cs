//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    /// <summary>
    /// Defines a key over a kind-stratified domain
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct DomainKey
    {
        public Domain Domain {get;}

        public uint Id {get;}

        [MethodImpl(Inline)]
        public DomainKey(Domain kind, uint id)
        {
            Id = id;
            Domain = kind;
        }
    }
}
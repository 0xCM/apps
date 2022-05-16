//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Relations
    {
        /// <summary>
        /// Identifies a domain-relative target
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public readonly struct TargetKey
        {
            public DomainKey Domain {get;}

            public uint Id {get;}

            [MethodImpl(Inline)]
            public TargetKey(DomainKey d, uint id)
            {
                Domain = d;
                Id = id;
            }
        }
    }
}
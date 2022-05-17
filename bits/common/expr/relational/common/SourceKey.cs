//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Relations
    {
        /// <summary>
        /// Identifies a domain-relative source
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public readonly struct SourceKey
        {
            public DomainKey Domain {get;}

            public uint Id {get;}

            [MethodImpl(Inline)]
            public SourceKey(DomainKey d, uint id)
            {
                Domain = d;
                Id = id;
            }
        }

    }
}
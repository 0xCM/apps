//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Relations
    {
        [StructLayout(LayoutKind.Sequential)]
        public readonly struct SourceKey<S>
        {
            public DomainKey Domain {get;}

            public S Rep {get;}

            [MethodImpl(Inline)]
            public SourceKey(DomainKey d, S rep)
            {
                Domain = d;
                Rep = rep;
            }
        }
    }
}
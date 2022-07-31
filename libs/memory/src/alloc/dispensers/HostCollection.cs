//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class HostCollection : Seq<CollectedHost>
    {
        readonly IDisposable Dispenser;

        public HostCollection(ICompositeDispenser dispenser, CollectedHost[] src)
            : base(src)
        {
            Dispenser = dispenser;
        }
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class ClrCanonical : TypeMap<ClrTypeSystem, CanonicalTypes>
    {
        public override Outcome Map(IType src, out IType dst)
        {
            dst = default;
            return false;
        }
    }
}
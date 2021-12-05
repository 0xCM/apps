//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public sealed class CanonicalTypeSystem : TypeSystem<CanonicalTypeSystem, CanonicalTypeSort>
    {
        public const string SystemName = "canonical";

        public CanonicalTypeSystem()
            : base(SystemName)
        {

        }

        public override ReadOnlySpan<IType<CanonicalTypeSort>> Primitives => throw new NotImplementedException();
    }

}
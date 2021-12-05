//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public sealed class ClrTypeSystem : TypeSystem<ClrTypeSystem, ClrPrimitiveKind>
    {
        public const string SystemName = "clr";

        public ClrTypeSystem()
            : base(SystemName)
        {

        }

        public override ReadOnlySpan<IType<ClrPrimitiveKind>> Primitives => throw new NotImplementedException();
    }


}
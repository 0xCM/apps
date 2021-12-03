//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using static Root;

    public sealed class BlittableTypes : TypeSystem<BlittableTypes>
    {
        public const string SystemName = "blittable";

        public BlittableTypes()
            : base(SystemName)
        {

        }

        public override ReadOnlySpan<TypeKind> Kinds => throw new NotImplementedException();
    }
}
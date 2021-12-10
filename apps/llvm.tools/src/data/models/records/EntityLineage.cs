//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct EntityLineage
    {
        public readonly Identifier EntityName;

        public readonly Lineage Ancestors;

        [MethodImpl(Inline)]
        public EntityLineage(Identifier name, Lineage ancestors)
        {
            EntityName = name;
            Ancestors = ancestors;
        }

        public string Format()
            =>  Ancestors.IsEmpty ? EntityName.Format() : string.Format("{0} -> {1}", EntityName, Ancestors.Format());

        public override string ToString()
            => Format();
    }
}
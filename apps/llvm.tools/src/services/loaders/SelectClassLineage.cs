//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using System.Collections.Concurrent;

    using static core;

    partial class LlvmDataProvider
    {
        public Index<EntityLineage> SelectClassLineage()
        {
            return (Index<EntityLineage>)DataSets.GetOrAdd(nameof(SelectClassLineage), key => Load());

            Index<EntityLineage> Load()
            {
                return SelectClassRelations().Select(r => new EntityLineage(r.Name, r.Ancestors));
            }
        }
    }
}
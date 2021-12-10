//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmDataProvider
    {
        public ConstLookup<Identifier,EntityLineage> SelectClassLineage()
        {
            return (ConstLookup<Identifier,EntityLineage>)DataSets.GetOrAdd(nameof(SelectClassLineage), key => Load());

            ConstLookup<Identifier,EntityLineage> Load()
            {
                var items = SelectClassRelations().Select(r => new EntityLineage(r.Name, r.Ancestors));
                return items.Select(x => (x.EntityName,x)).Storage.ToConstLookup();
            }
       }
    }
}
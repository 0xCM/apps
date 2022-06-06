//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmDataProvider
    {
        public ConstLookup<Identifier,EntityLineage> ClassLineage()
        {
            return (ConstLookup<Identifier,EntityLineage>)DataSets.GetOrAdd(nameof(ClassLineage), key => Load());

            ConstLookup<Identifier,EntityLineage> Load()
            {
                var items = ClassRelations().Select(r => new EntityLineage(r.Name, r.Ancestors));
                return items.Select(x => (x.EntityName,x)).Storage.ToConstLookup();
            }
       }
    }
}
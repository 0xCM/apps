//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmDataCalcs
    {
        public ConstLookup<Identifier,EntityLineage> CalcDefLineage(Index<DefRelations> relations)
        {
            var items = relations.Select(r => new EntityLineage(r.Name, r.Ancestors));
            return items.Select(x => (x.EntityName,x)).Storage.ToConstLookup();
        }

        public Index<string> CalcAsmMnemonicNames(Index<LlvmAsmVariation> variations)
        {
            var names = variations.Where(x => x.Mnemonic.IsNonEmpty).Map(x => x.Mnemonic.Format()).Distinct().Sort();
            return names;
        }
    }
}
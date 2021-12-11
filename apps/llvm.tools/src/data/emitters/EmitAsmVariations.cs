//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    using static core;
    using static Root;

    partial class LlvmDataEmitter
    {
        public Index<LlvmAsmVariation> EmitAsmVariations()
        {
            var entities = DataProvider.SelectEntities(e => e.IsInstruction()).Select(x => x.ToInstruction());
            var count = entities.Length;
            var asmid = DataProvider.DiscoverAsmIdDefs();
            var variations = list<LlvmAsmVariation>();
            var seq = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var inst = ref entities[i];
                var name = inst.EntityName.Content;
                var asmstr = inst.AsmString;
                var mnemonic = asmstr.Mnemonic;
                var id = z16;
                if(asmid.Find(name, out var descriptor))
                    id = descriptor.Id;
                else
                    Warn(string.Format("Instruction id for '{0}' not found", name));

                var j = text.index(name.ToLower(), mnemonic.Content);
                var vcode = inst.VarCode;
                if(vcode.IsNonEmpty)
                    variations.Add(new LlvmAsmVariation(id, name, mnemonic, vcode));
            }

            var records = variations.Array();
            TableEmit(@readonly(records), LlvmPaths.Table<LlvmAsmVariation>());
            return records;
        }
    }
}
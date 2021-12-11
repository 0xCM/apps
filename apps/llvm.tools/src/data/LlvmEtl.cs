//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using static LlvmNames;
    using static Root;
    using static core;

    public partial class LlvmEtl : AppService<LlvmEtl>
    {
        LlvmPaths LlvmPaths;

        LlvmDataProvider DataProvider;

        LlvmDataEmitter DataEmitter;

        public LlvmEtl()
        {
        }

        protected override void Initialized()
        {
            LlvmPaths = Wf.LlvmPaths();
            DataProvider = Wf.LlvmDataProvider();
            DataEmitter = Wf.LlvmDataEmitter();
        }

        public void Run()
        {
            ImportRecords();
            ImportEntityData();
        }

        void ImportRecords()
        {
            var records = DataProvider.SelectSourceRecords(Datasets.X86);
            DataEmitter.EmitToolHelp();
            //EmitLinedRecords(records, Datasets.X86Lined);
            var classes = DataEmitter.EmitClassRelations(records);
            var defs = DataEmitter.EmitDefRelations(records);
            var defMap = DataEmitter.EmitLineMap(defs.View, records, Datasets.X86Defs);
            var defFields = RecordFieldParser.parse(records, defMap);
            DataEmitter.EmitFields(defFields, Datasets.X86DefFields);
            var classMap = DataEmitter.EmitLineMap(classes.View, records, Datasets.X86Classes);
            var classFields = RecordFieldParser.parse(records, classMap);
            DataEmitter.EmitFields(classFields, Datasets.X86ClassFields);
        }

        public Outcome ImportEntityData()
        {
            DataEmitter.EmitLists();
            DataEmitter.EmitChildRelations();
            ImportInstructions();
            DataEmitter.EmitInstDefs();
            DataEmitter.EmitInstPatterns();
            return true;
        }

        void ImportInstructions()
        {
            var entities = DataProvider.SelectEntities(e => e.IsInstruction()).Select(x => x.ToInstruction());
            var count = entities.Length;
            var asmid = DataProvider.DiscoverAsmIdDefs();
            var obmapped = list<LlvmAsmIdentity>();
            var variations = list<LlvmAsmVariation>();
            var vcodes = hashset<string>();
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

                var identity = new LlvmAsmIdentity(id, name);

                if(inst.OpMap.Equals("OB"))
                    obmapped.Add(identity);

                var j = text.index(name.ToLower(), mnemonic.Content);
                var vcode = inst.VarCode;
                if(vcode.IsNonEmpty)
                {
                    vcodes.Add(vcode.Format());
                    variations.Add(new LlvmAsmVariation(id, name, mnemonic, vcode));
                }
            }

            DataEmitter.EmitList(vcodes.Array().Sort().Mapi((i,v) => new LlvmListItem((uint)i, v)).ToLlvmList(LlvmPaths.ListImportPath("vcodes")));
            TableEmit(variations.ViewDeposited(), LlvmPaths.Table<LlvmAsmVariation>());
        }
   }
}
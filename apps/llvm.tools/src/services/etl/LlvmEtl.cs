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

        OmniScript OmniScript;

        llvm.LlvmNm Nm;

        llvm.LlvmObjDump ObjDump;

        llvm.LlvmMc McSyntaxLogs;

        public LlvmEtl()
        {
        }

        protected override void Initialized()
        {
            LlvmPaths = Wf.LlvmPaths();
            OmniScript = Wf.OmniScript();
            Nm = Wf.LlvmNm();
            ObjDump = Wf.LlvmObjDump();
            McSyntaxLogs = Wf.LlvmMc();
        }

        public EtlDatasets Run()
        {
            var dst = new EtlDatasets();
            var records = LoadSourceRecords(Datasets.X86);
            dst.Records = records;
            EmitLinedRecords(records, Datasets.X86Lined);
            var classes = EmitClassRelations(records);
            dst.ClassRelations = classes;
            var defs = EmitDefRelations(records);
            dst.DefRelations = defs;
            var defMap = EmitLineMap(defs, records, Datasets.X86Defs);
            dst.DefMap = defMap;
            var defFields = LoadFields(records, defMap);
            dst.Defs = defFields;
            EmitFields(defFields, Datasets.X86DefFields);
            var classMap = EmitLineMap(classes, records, Datasets.X86Classes);
            dst.ClassMap = classMap;
            var classFields = LoadFields(records, classMap);
            dst.Classes = classFields;
            EmitFields(classFields, Datasets.X86ClassFields);
            return dst;
        }

        public void GenDocs(in EtlDatasets src)
        {
            var dst = LlvmPaths.Docs("instructions");
            dst.Clear();
            var running = Running(string.Format("Emitting instruction docs to {0}", dst));
            var docgen = LlvmDocGen.create(Wf,src);
            var count = docgen.GenInsructionDocs(dst);
            Ran(running, string.Format("Emitted docs for {0} instructions", count));
        }

        public Outcome RunEntityEtl()
        {
            var entities = Wf.LlvmDb().Entities();
            var members = entities.Members;
            var count = members.Length;
            var key = 0u;
            var records = list<LlvmAsmPattern>();
            var asmids = list<LlvmAsmIdentity>();
            var obmapped = list<LlvmAsmIdentity>();
            var variations = list<LlvmAsmVariation>();
            for(var i=0; i<count; i++)
            {
                ref readonly var entity = ref skip(members,i);
                ref readonly var def = ref entity.Def;
                var ancestors = def.AncestorNames;
                var parent = def.ParentName;
                if(ancestors.Contains(RecordClasses.Instruction))
                {
                    var name = entity.EntityName.Content;
                    var identity = new LlvmAsmIdentity(key, name);
                    asmids.Add(identity);

                    if(bit.parse(entity["isPseudo"].Value, out var pseudo) && bit.parse(entity["isCodeGenOnly"].Value, out var cgonly))
                    {
                        if(pseudo || cgonly)
                            continue;

                        var asms = entity["AsmString"];
                        var map = entity["OpMap"];
                        if(map.Value.Equals("OB"))
                            obmapped.Add(identity);
                        var mnemonic = AsmString.mnemonic(asms.Value);
                        var fmt = AsmString.format(asms.Value);
                        var j = text.index(name.ToLower(),mnemonic);
                        if(j >=0)
                            variations.Add(new LlvmAsmVariation(key, name, mnemonic, text.right(name, j + mnemonic.Length - 1)));

                        records.Add(LlvmAsmPattern.define(key, name, mnemonic, fmt, out var _));
                    }
                    key++;
                }
            }

            TableEmit(records.ViewDeposited(), LlvmPaths.Table<LlvmAsmPattern>());
            TableEmit(asmids.ViewDeposited(), LlvmPaths.Table<LlvmAsmIdentity>());
            TableEmit(variations.ViewDeposited(), LlvmPaths.Table<LlvmAsmVariation>());

            EmitChildRelations(entities);

            Wf.LlvmCodeGen().GenListStringTables(EmitLists(entities, RecordClasses.Names));
            return true;
        }
   }
}
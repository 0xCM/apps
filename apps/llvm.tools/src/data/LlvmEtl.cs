//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static LlvmNames;
    using static Root;
    using static core;

    public partial class LlvmEtl : AppService<LlvmEtl>
    {
        LlvmPaths LlvmPaths;

        OmniScript OmniScript;

        LlvmDataProvider DataProvider;

        LlvmDataEmitter DataEmitter;

        public LlvmEtl()
        {
        }

        protected override void Initialized()
        {
            LlvmPaths = Wf.LlvmPaths();
            OmniScript = Wf.OmniScript();
            DataProvider = Wf.LlvmDataProvider();
            DataEmitter = Wf.LlvmDataEmitter();
        }

        Index<string> ListNames()
        {
            var src = LlvmPaths.Settings("ListEmissions", FS.List);
            var lines = src.ReadLines();
            return lines.Select(x => x.Trim()).Where(x => nonempty(x));
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
            EmitLinedRecords(records, Datasets.X86Lined);
            var classes = EmitClassRelations(records);
            var defs = EmitDefRelations(records);
            var defMap = DataEmitter.EmitLineMap(defs, records, Datasets.X86Defs);
            var defFields = RecordFieldParser.parse(records, defMap);
            EmitFields(defFields, Datasets.X86DefFields);
            var classMap = DataEmitter.EmitLineMap(classes, records, Datasets.X86Classes);
            var classFields = RecordFieldParser.parse(records, classMap);
            EmitFields(classFields, Datasets.X86ClassFields);
        }

        void ProcessInstructions()
        {
            var asmid = DiscoverAsmIdDefs();
            var src = DataProvider.SelectEntities();
            var count = src.Length;
            var patterns = list<LlvmAsmPattern>();
            var obmapped = list<LlvmAsmIdentity>();
            var variations = list<LlvmAsmVariation>();
            var vcodes = hashset<string>();
            var seq = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var entity = ref src[i];
                if(entity.IsInstruction())
                {
                    var inst = entity.ToInstruction();
                    var name = inst.EntityName.Content;
                    var id = z16;
                    if(asmid.Find(name, out var descriptor))
                        id = descriptor.Id;
                    else
                        Warn(string.Format("Instruction id for '{0}' not found", name));

                    var identity = new LlvmAsmIdentity(id, name);

                    if(inst.OpMap.Equals("OB"))
                        obmapped.Add(identity);

                    var mnemonic = inst.Mnemonic;
                    var j = text.index(inst.EntityName.Content.ToLower(), inst.Mnemonic.Content);
                    var vcode = inst.VarCode;
                    if(vcode.IsNonEmpty)
                    {
                        vcodes.Add(vcode.Format());
                        variations.Add(new LlvmAsmVariation(id, name, mnemonic, vcode));
                    }

                    var pattern = LlvmAsmPattern.Empty;
                    pattern.Seq = seq++;
                    pattern.AsmId = id;
                    pattern.Instruction = name;
                    pattern.Mnemonic = mnemonic;
                    pattern.VarCode = vcode;
                    pattern.CGOnly = inst.isCodeGenOnly;
                    pattern.Pseudo = inst.isPseudo;
                    pattern.FormatPattern = inst.AsmString;
                    pattern.SourcePattern = inst.RawAsmString;
                    patterns.Add(pattern);
                }
            }

            DataEmitter.EmitList(vcodes.Array().Sort().Mapi((i,v) => new LlvmListItem((uint)i, v)).ToLlvmList(LlvmPaths.ListImportPath("vcodes")));
            TableEmit(patterns.ViewDeposited(), LlvmAsmPattern.RenderWidths, LlvmPaths.Table<LlvmAsmPattern>());
            TableEmit(variations.ViewDeposited(), LlvmPaths.Table<LlvmAsmVariation>());
        }

        public Outcome ImportEntityData()
        {
            EmitLists();
            DataEmitter.EmitChildRelations();
            ProcessInstructions();
            return true;
        }

        public AsmIdDefs DiscoverAsmIdDefs()
        {
            const string BeginAsmIdMarker = "PHI	= 0,";
            var src = LlvmPaths.TableGenHeaders().Where(x => x.FileName.WithoutExtension.Format() == TableGenHeaders.X86Info);
            if(src.Count != 1)
            {
                Error("Path not found");
                return llvm.AsmIdDefs.Empty;
            }
            return enumliterals<ushort>(src[0],BeginAsmIdMarker).Map(x => new AsmIdDef(x.Key, x.Value));
        }

        public RegIdDefs DiscoverRegIdDefs()
        {
            const string BeginRegsMarker = "NoRegister,";
            var src = LlvmPaths.TableGenHeaders().Where(x => x.FileName.WithoutExtension.Format() == TableGenHeaders.X86Registers);
            if(src.Count != 1)
            {
                Error("Path not found");
                return llvm.RegIdDefs.Empty;
            }
            return enumliterals<ushort>(src[0],BeginRegsMarker).Map(x => new RegIdDef(x.Key, x.Value));
        }

        static bool enumliteral<T>(string src, out LlvmListItem<T,string> dst)
            where T : unmanaged
        {
            if(definesliteral(src))
            {
                var i = text.index(src, Chars.Eq);
                var name = text.left(src,i).Trim();
                var idtext = text.remove(text.right(src,i),Chars.Comma).Trim();
                DataParser.numeric(idtext, out ushort id);
                dst = (generic<T>(id),name);
                return true;
            }
            else
            {
                dst = default;
                return false;
            }
        }

        static bool definesliteral(string src)
            => src.Contains(Chars.Eq) && src.Trim().EndsWith(Chars.Comma);

        static LlvmListItem<T,string>[] enumliterals<T>(FS.FilePath header, string marker)
            where T : unmanaged
        {
            var items = list<LlvmListItem<T,string>>();
            using var reader = header.Utf8LineReader();
            var parsing = false;
            while(reader.Next(out var line))
            {
                if(parsing)
                {
                    if(enumliteral<T>(line.Content, out var literal))
                        items.Add(literal);
                    else
                        break;
                }
                else
                {
                    if(line.Contains(marker))
                    {
                        parsing = true;
                        if(definesliteral(marker))
                        {
                            if(enumliteral<T>(marker, out var first))
                                items.Add(first);
                        }
                        else
                            items.Add((zero<T>(), text.remove(marker, Chars.Comma)));
                    }
                }
            }
            return items.ToArray();
        }
   }
}
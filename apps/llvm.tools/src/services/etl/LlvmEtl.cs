//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static LlvmNames;
    using static Root;
    using static core;

    using Asm;

    public partial class LlvmEtl : AppService<LlvmEtl>
    {
        LlvmPaths LlvmPaths;

        OmniScript OmniScript;

        LlvmDataLoader DataLoader;

        public LlvmEtl()
        {
        }

        protected override void Initialized()
        {
            LlvmPaths = Wf.LlvmPaths();
            OmniScript = Wf.OmniScript();
            DataLoader = Wf.LlvmDataLoader();
        }

        Index<string> ListNames()
        {
            var src = LlvmPaths.Settings("ListEmissions", FS.List);
            var lines = src.ReadLines();
            return lines.Select(x => x.Trim()).Where(x => nonempty(x));
        }

        public EtlDatasets Run()
        {
            var dst = new EtlDatasets();
            RunHeaderEtl(ref dst);
            var records = DataLoader.LoadSourceRecords(Datasets.X86);
            dst.Records = records;
            EmitLinedRecords(records, Datasets.X86Lined);
            var classes = EmitClassRelations(records);
            var defs = EmitDefRelations(records);
            var defMap = EmitLineMap(defs, records, Datasets.X86Defs);
            dst.DefMap = defMap;
            var defFields = DataLoader.LoadFields(records, defMap);
            dst.Defs = defFields;
            EmitFields(defFields, Datasets.X86DefFields);
            var classMap = EmitLineMap(classes, records, Datasets.X86Classes);
            var classFields = DataLoader.LoadFields(records, classMap);
            EmitFields(classFields, Datasets.X86ClassFields);
            RunEntityEtl();
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

        void ProcessInstructions(RecordEntitySet src, AsmIdDescriptors asmid)
        {
            var members = src.Members;
            var count = members.Length;
            //var key = 0u;
            var patterns = list<LlvmAsmPattern>();
            var obmapped = list<LlvmAsmIdentity>();
            var variations = list<LlvmAsmVariation>();
            var vcodes = hashset<string>();
            var seq = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var entity = ref skip(members,i);
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
                    var vcode = inst.VariationCode;
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
                    pattern.Variation = vcode;
                    pattern.IsCodeGenOnly = inst.isCodeGenOnly;
                    pattern.IsPseudo = inst.isPseudo;
                    pattern.ExprFormat = AsmString.normalize(inst.AsmString);
                    patterns.Add(pattern);
                }
            }

            EmitList(vcodes.Array().Sort().Mapi((i,v) => new LlvmListItem((uint)i, v)).ToLlvmList(LlvmPaths.List("vcodes")));
            TableEmit(patterns.ViewDeposited(), LlvmPaths.Table<LlvmAsmPattern>());
            TableEmit(variations.ViewDeposited(), LlvmPaths.Table<LlvmAsmVariation>());
        }

        public Outcome RunEntityEtl()
        {
            var src = DataLoader.LoadEntities();
            EmitLists();
            EmitChildRelations(src);
            ProcessInstructions(src, ExtractAsmIdList());
            return true;
        }

        public AsmIdDescriptors ExtractAsmIdList()
        {
            const string BeginAsmIdMarker = "PHI	= 0,";
            var src = LlvmPaths.TableGenHeaders().Where(x => x.FileName.WithoutExtension.Format() == TableGenHeaders.X86Info);
            if(src.Count != 1)
            {
                Error("Path not found");
                return AsmIdDescriptors.Empty;
            }
            return enumliterals<ushort>(src[0],BeginAsmIdMarker).Map(x => new AsmIdDescriptor(x.Key, x.Value));
        }

        Outcome RunHeaderEtl(ref EtlDatasets datasets)
        {
            const string BeginRegsMarker = "NoRegister,";
            const string BeginAsmIdMarker = "PHI	= 0,";

            var src = LlvmPaths.TableGenHeaders().View;
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var header = ref skip(src,i);
                var name = header.FileName.WithoutExtension.Format();
                switch(name)
                {
                    case TableGenHeaders.X86Registers:
                        EmitList("RegisterId", enumliterals<ushort>(header,BeginRegsMarker));
                    break;
                    case TableGenHeaders.X86Info:
                        EmitList("AsmId", enumliterals<ushort>(header,BeginAsmIdMarker));
                    break;
                }

            }
            return true;
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
                            items.Add((zero<T>(),text.remove(marker, Chars.Comma)));
                    }
                }
            }
            return items.ToArray();
        }
   }
}
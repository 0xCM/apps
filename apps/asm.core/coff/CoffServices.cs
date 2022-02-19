//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class CoffServices : AppService<CoffServices>
    {
        HexDataReader HexReader => Service(Wf.HexDataReader);

        HexDataFormatter Formatter => Service(() => HexDataFormatter.create(0,32,true));

        Symbols<CoffSectionKind> SectionKinds;

        public CoffServices()
        {
            SectionKinds = Symbols.index<CoffSectionKind>();
        }

        public void Collect(CollectionContext collect)
        {
            CollectObjHex(collect);
            CollectSymbols(collect);
            CollectHeaders(collect);
        }

        FS.FolderPath ObjHexDir(IProjectWs project)
            => ProjectDb.ProjectData(string.Format("{0}.objhex", project.Name));

        public Outcome CollectObjHex(CollectionContext collect)
        {
            var outdir = ObjHexDir(collect.Project);
            outdir.Clear();
            var result = Outcome.Success;
            var project = collect.Project;
            var files = collect.Files.Entries(FileKind.Obj, FileKind.O);
            var count = files.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var file = ref files[i];
                ref readonly var path = ref file.Path;
                var srcid = text.ifempty(path.SrcId(FileKind.Obj, FileKind.O), path.FileName.WithoutExtension.Format());
                var dst = outdir + FS.file(srcid, FileKind.HexDat.Ext());
                var running = Running(string.Format("Emitting {0}", dst));
                using var writer = dst.AsciWriter();
                var data = path.ReadBytes();
                var lines = Formatter.FormatLines(data);
                iter(lines, line => writer.WriteLine(line));
                Ran(running, string.Format("coffobj:{0} -> {1}", path.ToUri(), dst.ToUri()));
            }

            return result;
        }

        public HexFileData LoadObjHex(CollectionContext context)
        {
            var src = ObjHexDir(context.Project).Files(FileKind.HexDat.Ext());
            var count = src.Length;
            var dst = dict<FS.FilePath,Index<HexDataRow>>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var path = ref src[i];
                dst[path] = HexReader.Read(path);
            }

            return dst;
        }

        public CoffObjectData LoadObjData(FileCatalog src)
        {
            var files = src.Entries(FileKind.Obj, FileKind.O);
            var count = files.Count;
            var dst = dict<FS.FilePath,CoffObject>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var file = ref files[i];
                dst[file.Path] = CoffObjects.Load(file);
            }
            return dst;
        }

        public CoffObject LoadObjData(in FileRef fref)
            => CoffObjects.Load(fref);

        public CoffSectionKind CalcSectionKind(string name)
        {
            var kind = CoffSectionKind.Unknown;
            if(SectionKinds.MapExpr(name, out var sym))
                kind = sym.Kind;
            return kind;
        }

        public Index<CoffSection> CalcObjHeaders(in FileRef fref)
        {
            var records = list<CoffSection>();
            var seq = 0u;
            CalcObjHeaders(fref,ref seq, records);
            return records.ToArray();
        }

        void CalcObjHeaders(in FileRef fref, ref uint seq, List<CoffSection> records)
        {
            var obj = LoadObjData(fref);
            var view = CoffObjectView.cover(obj.Data);
            ref readonly var header = ref view.Header;
            var strings = view.StringTable;
            var sections = view.SectionHeaders;
            for(var j=0u; j<sections.Length; j++)
            {
                ref readonly var section = ref skip(sections,j);
                var number = j+1 ;
                var name = CoffObjects.format(strings, section.Name);
                var record = default(CoffSection);
                record.Seq = seq++;
                record.DocId = fref.DocId;
                record.SectionNumber = (ushort)number;
                record.SectionName = name;
                record.SectionKind = CalcSectionKind(name);
                record.SectionId = CalcSectionId(record.DocId, record.SectionNumber);
                record.RawDataAddress = section.PointerToRawData;
                record.RawDataSize = section.SizeOfRawData;
                record.RelocAddress = section.PointerToRelocations;
                record.RelocCount = section.NumberOfRelocations;
                record.Flags = section.Characteristics;
                records.Add(record);
            }
        }

        public Index<CoffSection> CalcObjHeaders(CollectionContext context)
        {
            var project = context.Project;
            var src = LoadObjData(context.Files);
            var entries = src.Entries;
            var count = entries.Count;
            var records = list<CoffSection>();
            var seq = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var entry = ref entries[i];
                ref readonly var path = ref entry.Left;
                ref readonly var obj = ref entry.Right;
                var fref = context.FileRef(path);
                var view = CoffObjectView.cover(obj.Data);
                ref readonly var header = ref view.Header;
                var strings = view.StringTable;
                var sections = view.SectionHeaders;
                CalcObjHeaders(fref, ref seq, records);
            }

            return records.ToArray();
        }

        public Outcome CollectHeaders(CollectionContext context)
        {
            var records = CalcObjHeaders(context);
            var dst = ProjectDb.ProjectTable<CoffSection>(context.Project);
            TableEmit(records.View, CoffSection.RenderWidths, dst);
            return true;
        }

        public Index<CoffSymRecord> LoadSymbols(IProjectWs project)
        {
            var src = ProjectDb.ProjectTable<CoffSymRecord>(project);
            var lines = src.ReadLines(true);
            var count = lines.Count - 1;
            Index<CoffSymRecord> dst = alloc<CoffSymRecord>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var line = ref lines[i+1];
                var cells = text.trim(text.split(line,Chars.Pipe));
                Require.equal(cells.Length, CoffSymRecord.FieldCount);
                var reader = cells.Reader();
                ref var row = ref dst[i];
                DataParser.parse(reader.Next(), out row.Seq).Require();
                DataParser.parse(reader.Next(), out row.DocId).Require();
                DataParser.parse(reader.Next(), out row.SectionNumber).Require();
                DataParser.parse(reader.Next(), out row.SectionId).Require();
                DataParser.parse(reader.Next(), out row.Address).Require();
                DataParser.parse(reader.Next(), out row.SymSize).Require();
                DataParser.parse(reader.Next(), out row.Value).Require();
                DataParser.eparse(reader.Next(), out row.SymClass).Require();
                DataParser.parse(reader.Next(), out row.AuxCount).Require();
                DataParser.parse(reader.Next(), out row.Name).Require();
            }
            return dst;
        }

        public Index<CoffSection> LoadHeaders(IProjectWs project)
        {
            var src = ProjectDb.ProjectTable<CoffSection>(project);
            var lines = src.ReadLines(true);
            var count = lines.Count - 1;
            Index<CoffSection> dst = alloc<CoffSection>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var line = ref lines[i+1];
                var cells = text.trim(text.split(line,Chars.Pipe));
                Require.equal(cells.Length, CoffSection.FieldCount);
                var reader = cells.Reader();
                ref var row = ref dst[i];
                DataParser.parse(reader.Next(), out row.Seq).Require();
                DataParser.parse(reader.Next(), out row.DocId).Require();
                DataParser.parse(reader.Next(), out row.SectionNumber).Require();
                DataParser.parse(reader.Next(), out row.SectionName).Require();
                SectionKinds.ExprKind(reader.Next(), out row.SectionKind);
                DataParser.parse(reader.Next(), out row.SectionId).Require();
                DataParser.parse(reader.Next(), out row.RawDataSize).Require();
                DataParser.parse(reader.Next(), out row.RawDataAddress).Require();
                DataParser.parse(reader.Next(), out row.RelocCount).Require();
                DataParser.parse(reader.Next(), out row.RelocAddress).Require();
                DataParser.eparse(reader.Next(), out row.Flags).Require();
            }
            return dst;
        }

        public Outcome CheckObjHex(CollectionContext context)
        {
            var result = Outcome.Success;
            var hexSrc = LoadObjHex(context);
            var hexDat = hexSrc.ToLookup(FileKind.HexDat);
            var objSrc = LoadObjData(context.Files);

            if(hexSrc.Count != objSrc.Count)
                result = (false,string.Format("Counts differ"));

            if(result.Fail)
                return result;

            var paths = objSrc.Paths.Array();
            var count = paths.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var objPath = ref skip(paths,i);
                var obj = objSrc[objPath];
                ref readonly var srcId = ref obj.SrcId;
                if(!hexDat.ContainsKey(srcId))
                {
                    Warn("No hex data found for {0}", srcId);
                    continue;
                }

                var hex = hexDat[srcId];
                result = CoffObjects.validate(obj, hex, out var _);
                if(result.Fail)
                    break;

                result = (true,string.Format("{0}.{1} validated", srcId, FileKind.HexDat.Ext()));

                if(i!=count-1)
                    Status(result.Message);
            }

            return result;
        }

        [MethodImpl(Inline)]
        static uint CalcSectionId(uint docid, ushort section)
        {
            var hi = (section > Pow2.T15) ? ((uint)(ushort.MaxValue - section) + byte.MaxValue) : (uint)section;
            return docid | hi << 16;
        }

        Outcome CollectSymbols(CollectionContext context)
        {
            var src = LoadObjData(context.Files);
            var files = context.Files;
            var paths = src.Paths.Array();
            var objCount = paths.Length;
            var path = ProjectDb.ProjectTable<CoffSymRecord>(context.Project);
            var formatter = Tables.formatter<CoffSymRecord>(CoffSymRecord.RenderWidths);
            var seq = 0u;
            var emitting = EmittingFile(path);
            using var writer = path.Writer();
            writer.WriteLine(formatter.FormatHeader());
            for(var i=0; i<objCount; i++)
            {
                ref readonly var objPath = ref skip(paths,i);
                var obj = src[objPath];
                var file = files.Entry(objPath);
                var objData = obj.Data.View;
                var offset = 0u;
                var view = CoffObjectView.cover(obj.Data, offset);
                var symcount = view.SymCount;
                if(symcount == 0)
                    continue;

                var syms = view.Symbols;
                var strings = view.StringTable;
                var size = 0u;
                for(var j=0; j<symcount; j++)
                {
                    ref readonly var sym = ref skip(syms,j);
                    var symtext = strings.Text(sym);
                    if(nonempty(symtext))
                    {
                        var record = default(CoffSymRecord);
                        var name = sym.Name;
                        record.Seq = seq++;
                        record.DocId = file.DocId;
                        record.Address = name.NameKind == CoffNameKind.String ? Address32.Zero : name.Address;
                        record.SymSize = CoffObjects.length(strings, name);
                        record.SectionNumber = sym.Section;
                        record.SectionId = CalcSectionId(record.DocId, record.SectionNumber);
                        record.Value = sym.Value;
                        record.SymClass = sym.Class;
                        record.AuxCount = sym.NumberOfAuxSymbols;
                        record.Name = symtext;
                        writer.WriteLine(formatter.Format(record));

                        size += record.SymSize;
                    }
                }
            }

            EmittedFile(emitting, seq);

            return true;
        }
    }
}
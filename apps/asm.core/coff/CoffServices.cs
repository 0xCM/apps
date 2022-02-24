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

        WsProjects Projects => Service(Wf.WsProjects);

        Symbols<CoffSectionKind> SectionKinds;

        public CoffServices()
        {
            SectionKinds = Symbols.index<CoffSectionKind>();
        }

        public CoffSymIndex Collect(WsContext context)
        {
            CollectObjHex(context);
            var index = CollectSymIndex(context);
            context.Receiver.Collected(index);
            return index;
        }

        public CoffSymIndex CollectSymIndex(WsContext context)
            => new CoffSymIndex(CollectHeaders(context), CollectSymbols(context));

        public Outcome CollectObjHex(WsContext context)
        {
            var outdir = Projects.ObjHexDir(context.Project);
            outdir.Clear();
            var result = Outcome.Success;
            var project = context.Project;
            var files = context.Files.Entries(FileKind.Obj, FileKind.O);
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
                var obj = CoffObjects.load(path);
                writer.WriteLine(obj.Format());
                Ran(running, string.Format("objhex:{0} -> {1}", path.ToUri(), dst.ToUri()));
            }

            return result;
        }

        public HexFileData LoadObjHex(WsContext context)
        {
            var src = Projects.ObjHexDir(context.Project).Files(FileKind.HexDat.Ext());
            var count = src.Length;
            var dst = dict<FS.FilePath,Index<HexDataRow>>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var path = ref src[i];
                dst[path] = HexReader.Read(path);
            }

            return dst;
        }

        public CoffObjectData LoadObjData(WsContext context)
        {
            var files = context.Files.Entries(FileKind.Obj, FileKind.O);
            var count = files.Count;
            var dst = dict<FS.FilePath,CoffObject>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var file = ref files[i];
                dst[file.Path] = CoffObjects.load(file);
            }
            return dst;
        }

        public CoffObject LoadObj(in FileRef fref)
            => CoffObjects.load(fref);

        public CoffSectionKind CalcSectionKind(string name)
        {
            var kind = CoffSectionKind.Unknown;
            if(SectionKinds.MapExpr(name, out var sym))
                kind = sym.Kind;
            return kind;
        }

        public Index<CoffSection> CalcObjSections(WsContext context, in FileRef src)
        {
            var buffer = list<CoffSection>();
            var seq = 0u;
            CalcObjHeaders(context, src,buffer);
            var records = buffer.ToArray().Sort();
            for(var i=0u; i<records.Length; i++)
                seek(records,i).Seq = i;
            return records;
        }

        void CalcObjHeaders(WsContext context, in FileRef src, List<CoffSection> records)
        {
            var obj = LoadObj(src);
            var view = CoffObjectView.cover(obj.Data);
            ref readonly var header = ref view.Header;
            var strings = view.StringTable;
            var sections = view.SectionHeaders;
            var originated = context.Root(src.Path, out var origin);
            for(var j=0u; j<sections.Length; j++)
            {
                ref readonly var section = ref skip(sections,j);
                var number = j+1 ;
                var name = CoffObjects.format(strings, section.Name);
                var record = default(CoffSection);
                if(originated)
                    record.OriginId = origin.DocId;
                record.SectionNumber = (ushort)number;
                record.SectionName = name;
                record.SectionKind = CalcSectionKind(name);
                record.RawDataAddress = section.PointerToRawData;
                record.RawDataSize = section.SizeOfRawData;
                record.RelocAddress = section.PointerToRelocations;
                record.RelocCount = section.NumberOfRelocations;
                record.Flags = section.Characteristics;
                record.Source = src.Path;
                records.Add(record);
            }
        }

        public Index<CoffSection> CalcObjHeaders(WsContext context)
        {
            var project = context.Project;
            var src = LoadObjData(context);
            var entries = src.Entries;
            var count = entries.Count;
            var buffer = list<CoffSection>();
            for(var i=0; i<count; i++)
            {
                ref readonly var entry = ref entries[i];
                ref readonly var path = ref entry.Left;
                ref readonly var obj = ref entry.Right;
                var view = CoffObjectView.cover(obj.Data);
                ref readonly var header = ref view.Header;
                var strings = view.StringTable;
                var sections = view.SectionHeaders;
                CalcObjHeaders(context, context.FileRef(path), buffer);
            }

            var records = buffer.ToArray().Sort();
            for(var i=0u; i<records.Length; i++)
                seek(records,i).Seq = i;
            return records;
        }

        public Index<CoffSection> CollectHeaders(WsContext context)
        {
            var records = CalcObjHeaders(context);
            var dst = Projects.Table<CoffSection>(context.Project);
            TableEmit(records.View, CoffSection.RenderWidths, dst);
            return records;
        }

        public CoffSymIndex LoadSymIndex(IProjectWs project)
            => new CoffSymIndex(LoadHeaders(project), LoadSymbols(project));

        public Index<CoffSymRecord> LoadSymbols(IProjectWs project)
        {
            var src = Projects.Table<CoffSymRecord>(project);
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
                DataParser.parse(reader.Next(), out row.OriginId).Require();
                DataParser.parse(reader.Next(), out row.SectionNumber).Require();
                DataParser.parse(reader.Next(), out row.Address).Require();
                DataParser.parse(reader.Next(), out row.SymSize).Require();
                DataParser.parse(reader.Next(), out row.Value).Require();
                DataParser.eparse(reader.Next(), out row.SymClass).Require();
                DataParser.parse(reader.Next(), out row.AuxCount).Require();
                DataParser.parse(reader.Next(), out row.Name).Require();
                DataParser.parse(reader.Next(), out row.Source).Require();
            }
            return dst;
        }

        public Index<CoffSection> LoadHeaders(IProjectWs project)
        {
            var src = Projects.Table<CoffSection>(project);
            var lines = src.ReadLines(true);
            var count = lines.Count - 1;
            var buffer = alloc<CoffSection>(count);
            var docreader = lines.Reader();
            docreader.Next();
            var i=0u;
            while(docreader.Next(out var line))
            {
                var cells = text.trim(text.split(line,Chars.Pipe));
                Require.equal(cells.Length, CoffSection.FieldCount);

                var reader = cells.Reader();
                ref var row = ref seek(buffer,i++);
                DataParser.parse(reader.Next(), out row.Seq).Require();
                DataParser.parse(reader.Next(), out row.OriginId).Require();
                DataParser.parse(reader.Next(), out row.SectionNumber).Require();
                DataParser.parse(reader.Next(), out row.SectionName).Require();
                SectionKinds.ExprKind(reader.Next(), out row.SectionKind);
                DataParser.parse(reader.Next(), out row.RawDataSize).Require();
                DataParser.parse(reader.Next(), out row.RawDataAddress).Require();
                DataParser.parse(reader.Next(), out row.RelocCount).Require();
                DataParser.parse(reader.Next(), out row.RelocAddress).Require();
                DataParser.eparse(reader.Next(), out row.Flags).Require();
                DataParser.parse(reader.Next(), out row.Source).Require();
            }
            return buffer;
        }

        public Outcome CheckObjHex(WsContext context)
        {
            var result = Outcome.Success;
            var hexDat = LoadObjHex(context);
            var objDat = LoadObjData(context);

            if(hexDat.Count != objDat.Count)
                result = (false,string.Format("Counts differ"));

            if(result.Fail)
                return result;


            return result;
        }


        void CalcSymbols(WsContext context, in FileRef file, ref uint seq, List<CoffSymRecord> buffer)
        {
            var obj = CoffObjects.load(file);
            var objData = obj.Data.View;
            var offset = 0u;
            var view = CoffObjectView.cover(obj.Data, offset);
            var symcount = view.SymCount;
            if(symcount != 0)
            {
                var originated = context.Root(file.Path, out var origin);
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
                        if(originated)
                            record.OriginId = origin.DocId;

                        record.Address = name.NameKind == CoffNameKind.String ? Address32.Zero : name.Address;
                        record.SymSize = CoffObjects.length(strings, name);
                        record.SectionNumber = sym.Section;
                        record.Value = sym.Value;
                        record.SymClass = sym.Class;
                        record.AuxCount = sym.NumberOfAuxSymbols;
                        record.Name = symtext;
                        record.Source = file.Path;
                        buffer.Add(record);

                        size += record.SymSize;
                    }
                }
            }
        }

        public Index<CoffSymRecord> CalcSymbols(WsContext context)
        {
            var buffer = list<CoffSymRecord>();
            var files = context.Files.Entries(FileKind.Obj, FileKind.O);
            var count = files.Count;
            var seq = 0u;
            for(var i=0; i<count; i++)
                CalcSymbols(context,files[i], ref seq, buffer);
            return buffer.ToArray();
        }

        public Index<CoffSymRecord> CollectSymbols(WsContext context)
        {
            var buffer = list<CoffSymRecord>();
            var src = LoadObjData(context);
            var files = context.Files;
            var paths = src.Paths.Array();
            var objCount = paths.Length;
            for(var i=0; i<objCount; i++)
            {
                ref readonly var objPath = ref skip(paths,i);
                var originated = context.Root(objPath, out var origin);
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
                for(var j=0; j<symcount; j++)
                {
                    ref readonly var sym = ref skip(syms,j);
                    var symtext = strings.Text(sym);
                    if(nonempty(symtext))
                    {
                        var record = default(CoffSymRecord);
                        var name = sym.Name;
                        if(originated)
                            record.OriginId = origin.DocId;

                        record.Address = name.NameKind == CoffNameKind.String ? Address32.Zero : name.Address;
                        record.SymSize = CoffObjects.length(strings, name);
                        record.SectionNumber = sym.Section;
                        record.Value = sym.Value;
                        record.SymClass = sym.Class;
                        record.AuxCount = sym.NumberOfAuxSymbols;
                        record.Name = symtext;
                        record.Source = file.Path;
                        buffer.Add(record);
                    }
                }
            }

            var records = buffer.ToArray().Sort();
            for(var i=0u; i<records.Length; i++)
                seek(records,i).Seq = i;
            TableEmit(@readonly(records), CoffSymRecord.RenderWidths, Projects.CoffSymPath(context.Project));
            return records;
        }
    }
}
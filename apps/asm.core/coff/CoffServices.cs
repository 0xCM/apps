//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public class CoffServices : AppService<CoffServices>
    {
        HexDataReader HexReader => Service(Wf.HexDataReader);

        HexDataFormatter Formatter => Service(() => HexDataFormatter.create(0,32,true));

        public Outcome CollectObjHex(ProjectCollection collection)
        {
            var result = Outcome.Success;
            var project = collection.Project;
            var paths = project.OutFiles(FileKind.Obj, FileKind.O).View;
            var count = paths.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var src = ref skip(paths,i);
                var srcid = text.ifempty(src.SrcId(FileKind.Obj, FileKind.O), src.FileName.WithoutExtension.Format());
                var dst = ProjectDb.ProjectData(scope(project)) + FS.file(srcid, FileKind.HexDat.Ext());
                var running = Running(string.Format("Emitting {0}", dst));
                using var writer = dst.AsciWriter();
                var data = src.ReadBytes();
                var lines = Formatter.FormatLines(data);
                iter(lines, line => writer.WriteLine(line));
                Ran(running, string.Format("coffobj:{0} -> {1}", src.ToUri(), dst.ToUri()));
            }

            return result;
        }

        static string scope(IProjectWs project)
            => string.Format("{0}.{1}", project.Name, "objhex");

        public HexFileData LoadObjHex(IProjectWs project)
        {
            var src = ProjectDb.ProjectDataFiles(project, scope(project), FileKind.HexDat.Ext());
            var count = src.Length;
            var dst = dict<FS.FilePath,Index<HexDataRow>>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var path = ref src[i];
                dst[path] = HexReader.Read(path);
            }

            return dst;
        }

        public CoffObjectData LoadObjData(IProjectWs project)
        {
            var src = project.OutFiles(FileKind.Obj, FileKind.O);
            var count = src.Length;
            var dst = dict<FS.FilePath,CoffObject>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var path = ref src[i];
                dst[path] = CoffObjects.Load(path);
            }
            return dst;
        }

        public Outcome CollectSymbols(ProjectCollection collection)
        {
            var project = collection.Project;
            var src = LoadObjData(project);
            var paths = src.Paths.Array();
            var objCount = paths.Length;
            var path = ProjectDb.ProjectTable<CoffSymRecord>(project);
            var formatter = Tables.formatter<CoffSymRecord>(CoffSymRecord.RenderWidths);
            var seq = 0u;
            var emitting = EmittingFile(path);
            using var writer = path.Writer();
            writer.WriteLine(formatter.FormatHeader());
            for(var i=0; i<objCount; i++)
            {
                ref readonly var objPath = ref skip(paths,i);
                var obj = src[objPath];
                ref readonly var srcId = ref obj.SrcId;

                var objData = obj.Data.View;
                var offset = 0u;
                var view = CoffObjectView.cover(obj.Data, offset);

                var symcount = view.SymCount;
                if(symcount == 0)
                    break;

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
                        record.SrcId = srcId;
                        record.Timestamp = view.Timestamp;
                        record.Address = name.NameKind == CoffNameKind.String ? Address32.Zero : name.Address;
                        record.SymSize = CoffObjects.length(strings, name);
                        record.Section = sym.Section;
                        record.Value = sym.Value;
                        record.SymType = sym.Type;
                        record.SymClass = sym.Class;
                        record.AuxCount = sym.NumberOfAuxSymbols;
                        record.SymText = symtext;
                        writer.WriteLine(formatter.Format(record));

                        size += record.SymSize;
                    }
                }
            }

            EmittedFile(emitting, seq);

            return true;
        }

        public Outcome CheckObjHex(IProjectWs project)
        {
            var result = Outcome.Success;
            var hexSrc = LoadObjHex(project);
            var hexDat = hexSrc.ToLookup(FileKind.HexDat);
            var objSrc = LoadObjData(project);
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
    }
}
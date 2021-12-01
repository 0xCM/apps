//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    using static LlvmNames;
    using static core;

    public class LlvmProjectCollector : AppService<LlvmProjectCollector>
    {
        llvm.LlvmNm Nm;

        llvm.LlvmObjDump ObjDump;

        llvm.LlvmMc Mc;

        protected override void Initialized()
        {
            Nm = Wf.LlvmNm();
            ObjDump = Wf.LlvmObjDump();
            Mc = Wf.LlvmMc();
        }

        public void Collect()
        {
            iter(Projects.ProjectNames, name => Collect(Ws.Project(name)));
        }

        public void Collect(IProjectWs ws)
        {
            var result = Outcome.Success;
            result = ObjDump.Consolidate(ws);
            if(result.Fail)
                Error(result.Message);

            result = Nm.Collect(ws);
            if(result.Fail)
                Error(result.Message);

            result = CollectObjHex(ws);
            if(result.Fail)
                Error(result.Message);

            Mc.Collect(ws);
        }

        // Outcome CollectEncoding(IProjectWs ws)
        // {
        //     var result = Outcome.Success;
        //     var docs = Mc.EncodingDocs(ws);
        //     var dst = ws.Table<LlvmAsmEncoding>(ws.Project.Format());
        //     var counter=0u;
        //     var record = LlvmAsmEncoding.Empty;
        //     var formatter = Tables.formatter<LlvmAsmEncoding>(LlvmAsmEncoding.RenderWidths);
        //     var emitting = EmittingTable<LlvmAsmEncoding>(dst);
        //     using var writer = dst.Utf8Writer();
        //     writer.WriteLine(formatter.FormatHeader());
        //     foreach(var doc in docs)
        //     {
        //         var encoded = doc.Encoded;
        //         var count = encoded.Length;
        //         for(var i=0u; i<count; i++)
        //         {
        //             ref readonly var e = ref skip(encoded,i);
        //             record = LlvmAsmEncoding.Empty;
        //             record.Doc = doc.Source.LineRef(e.Line);
        //             record.Seq = counter++;
        //             record.DocSeq = i;
        //             record.Asm = e.Asm;
        //             record.Code = e.Encoding;
        //             writer.WriteLine(formatter.Format(record));
        //         }
        //     }
        //     EmittedTable(emitting, counter);

        //     return result;
        // }

        Outcome CollectObjHex(IProjectWs ws)
        {
            var result = Outcome.Success;
            var paths = ws.OutFiles(FileKind.Obj, FileKind.O).View;
            var count = paths.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var src = ref skip(paths,i);
                var id = src.FileName.WithoutExtension.Format();
                var dst = ws.OutDir(WsAtoms.objhex) + FS.file(id,FileTypes.ext(FileKind.HexDat));
                using var writer = dst.AsciWriter();
                var data = src.ReadBytes();
                var size = HexFormatter.emit(data, writer);
                Write(string.Format("({0:D5} bytes)[{1} -> {2}]", size, src.ToUri(), dst.ToUri()));
            }

            return result;
        }

        // Outcome CollectSyms(IProjectWs ws)
        // {
        //     var result = Outcome.Success;
        //     var src = ws.OutFiles(FS.Sym).View;
        //     var dst = ws.Table<ObjSymRow>(ws.Project.Format());
        //     var symbols = Nm.Collect(src, dst);
        //     return result;
        // }
    }
}
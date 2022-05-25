//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class WsContext
    {
        public static WsContext create(IProjectWs project)
            => new WsContext(project, flows(project));

        static WsDataFlows flows(IProjectWs ws)
        {
            var unserviced = WsUnserviced.create();
            var lines = unserviced.ProjectFile(ws, "build.flows", FileKind.Csv).ReadLines(TextEncodingKind.Asci,true);
            var buffer = alloc<ToolCmdFlow>(lines.Length - 1);
            var src = lines.Reader();
            src.Next(out _);
            var i = 0u;
            while(src.Next(out var line))
            {
                var cells = text.trim(text.split(line,Chars.Pipe));
                Require.equal(cells.Length,ToolCmdFlow.FieldCount);
                var reader = cells.Reader();
                ref var dst = ref seek(buffer,i++);
                DataParser.parse(reader.Next(), out dst.Tool).Require();
                DataParser.parse(reader.Next(), out dst.SourceName).Require();
                DataParser.parse(reader.Next(), out dst.TargetName).Require();
                DataParser.parse(reader.Next(), out dst.SourcePath).Require();
                DataParser.parse(reader.Next(), out dst.TargetPath).Require();
            }
            return new (FileCatalog.load(ws), buffer);
        }

        public readonly IProjectWs Project;

        public readonly FileCatalog Catalog;

        public readonly WsDataFlows Flows;

        WsContext(IProjectWs project, WsDataFlows flows)
        {
            Project = project;
            Catalog = flows.Catalog;
            Flows = flows;
        }

        public Index<FileRef> Files(FileKind k)
            => Catalog.Entries(k);

        public Index<FileRef> Files(FileKind k0, FileKind k1)
            => Catalog.Entries(k0,k1);

        public Index<FileRef> Files(FileKind k0, FileKind k1, FileKind k2)
            => Catalog.Entries(k0,k1,k2);

        public FileRef Ref(FS.FilePath path)
            => Catalog[path];

        public FileRef File(uint docid)
            => Catalog[docid];

        public FileRef Root(in FS.FilePath dst)
        {
            if(Flows.Root(dst, out var src))
                return src;
            else
                return Z0.FileRef.Empty;
        }

        public FileRef Root(in FileRef dst)
        {
            if(Flows.Root(dst.Path, out var src))
                return src;
            else
                return Z0.FileRef.Empty;
        }
    }
}
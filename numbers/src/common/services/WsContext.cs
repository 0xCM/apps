//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class WsContext
    {
        static WsUnserviced Unserviced = WsUnserviced.create();

        public static IProjectWs project(IAppService service, ProjectId id)
            => service.Ws.Project(id);

        public static IProjectProvider provider(IProjectWs ws)
            => ProjectProvider.create(ws);

        public static WsContext create(IAppService service, ProjectId id)
            => create(provider(project(service,id)));

        public static WsContext create(IProjectProvider provider)
            => create(provider, provider.Project(), flows(provider.Project()));

        public static WsContext create(IProjectProvider provider, IProjectWs project)
            => create(provider, project, flows(project));

        public static WsContext create(IProjectProvider projects, IProjectWs project, WsDataFlows flows)
            => new WsContext(projects, project, flows);

        static WsDataFlows flows(IProjectWs ws)
            => flows(FileCatalog.load(ws), commands(ws));

        static Index<ToolCmdFlow> commands(IProjectWs ws)
        {
            const byte FieldCount = ToolCmdFlow.FieldCount;
            var lines = Unserviced.ProjectFile(ws, "build.flows", FileKind.Csv).ReadLines(TextEncodingKind.Asci,true);
            var buffer = alloc<ToolCmdFlow>(lines.Length - 1);
            var src = lines.Reader();
            src.Next(out _);
            var i = 0u;
            while(src.Next(out var line))
            {
                var cells = text.trim(text.split(line,Chars.Pipe));
                Require.equal(cells.Length,FieldCount);
                var reader = cells.Reader();
                ref var dst = ref seek(buffer,i++);
                DataParser.parse(reader.Next(), out dst.Tool).Require();
                DataParser.parse(reader.Next(), out dst.SourceName).Require();
                DataParser.parse(reader.Next(), out dst.TargetName).Require();
                DataParser.parse(reader.Next(), out dst.SourcePath).Require();
                DataParser.parse(reader.Next(), out dst.TargetPath).Require();
            }
            return buffer;
        }

        static WsDataFlows flows(FileCatalog files, ReadOnlySpan<ToolCmdFlow> src)
            => new WsDataFlows(files, src);

        public IProjectProvider Projects {get;}

        public IProjectWs Project {get;}

        public FileCatalog Catalog {get;}

        public WsDataFlows Flows {get;}

        WsContext(IProjectProvider projects, IProjectWs project, WsDataFlows flows)
        {
            Projects = projects;
            Project = project;
            Catalog = flows.FileCatalog;
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
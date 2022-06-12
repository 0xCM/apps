//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class CmdFlows : AppService<CmdFlows>
    {
        static AppDb AppDb => GlobalSvc.Instance.AppDb;

        public static IProjectWs project(FS.FolderPath root, ProjectId id)
            => ProjectWs.create(root, id);

        [MethodImpl(Inline)]
        public static Relation<K,S,T> relation<K,S,T>(K kind, S src, T dst)
            where K : unmanaged
            where S : unmanaged
            where T : unmanaged
                => new Relation<K,S,T>(kind, src, dst);

        [MethodImpl(Inline)]
        public static WsContext context(IProjectWs project)
            => new WsContext(project, CmdFlows.flows(project.Project));

        [MethodImpl(Inline)]
        public static FileFlow flow(in CmdFlow src)
            => new FileFlow(CmdFlows.flow(src.Tool, src.SourcePath.ToUri(), src.TargetPath.ToUri()));

        [MethodImpl(Inline)]
        public static DataFlow<Actor,S,T> flow<S,T>(Tool tool, S src, T dst)
            => new DataFlow<Actor,S,T>(tool,src,dst);

        [MethodImpl(Inline)]
        public static FlowId identify<A,S,T>(A actor, S src, T dst)
            => new FlowId(hash(actor), hash(src), hash(dst));

        public static IDbTargets data(ProjectId id)
            => AppDb.ProjectData(id);

        public static IDbTargets data(ProjectId id, string scope)
            => AppDb.ProjectData(id).Targets(scope);

        public static FS.FilePath flow(ProjectId id)
            => data(id).Path(FS.file(string.Format("{0}.build.flows", id), FS.Csv));

        public static FS.FilePath table<T>(ProjectId project)
            where T : struct
                => data(project).Path(FS.file(string.Format("{0}.{1}", project, TableId.identify<T>()),FS.Csv));

        public static FS.FilePath table<T>(ProjectId project, string scope)
            where T : struct
                => data(project,scope).Path(FS.file(string.Format("{0}.{1}", project, TableId.identify<T>()),FS.Csv));

        public static WsDataFlows flows(ProjectId id)
        {
            var path = flow(id);
            var lines = path.ReadLines(TextEncodingKind.Asci,true);
            var buffer = alloc<CmdFlow>(lines.Length - 1);
            var src = lines.Reader();
            src.Next(out _);
            var i = 0u;
            while(src.Next(out var line))
            {
                var cells = text.trim(text.split(line,Chars.Pipe));
                Require.equal(cells.Length,CmdFlow.FieldCount);
                var reader = cells.Reader();
                ref var dst = ref seek(buffer,i++);
                Tools.parse(reader.Next(), out dst.Tool).Require();
                DataParser.parse(reader.Next(), out dst.SourceName).Require();
                DataParser.parse(reader.Next(), out dst.TargetName).Require();
                DataParser.parse(reader.Next(), out dst.SourcePath).Require();
                DataParser.parse(reader.Next(), out dst.TargetPath).Require();
            }
            return new(FileCatalog.load(id), buffer);
        }
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class WsCmdFlows : AppService<WsCmdFlows>
    {
        static AppDb AppDb => AppData.AppDb;

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
            => new WsContext(project, WsCmdFlows.flows(project.Project));

        [MethodImpl(Inline)]
        public static FileFlow flow(in CmdFlow src)
            => new FileFlow(WsCmdFlows.flow(src.Tool, src.SourcePath.ToUri(), src.TargetPath.ToUri()));

        [MethodImpl(Inline)]
        public static DataFlow<Actor,S,T> flow<S,T>(Tool tool, S src, T dst)
            => new DataFlow<Actor,S,T>(tool,src,dst);

        [MethodImpl(Inline)]
        public static FlowId identify<A,S,T>(A actor, S src, T dst)
            => new FlowId(hash(actor), hash(src), hash(dst));

        public static IDbTargets etl(ProjectId id)
            => AppDb.DbProjects(id);

        public static IDbTargets etl(ProjectId id, string scope)
            => AppDb.DbProjects(id).Targets(scope);

        public static FS.FilePath flow(ProjectId id)
            => etl(id).Path(FS.file(string.Format("{0}.build.flows", id), FS.Csv));

        public static FS.FilePath table<T>(ProjectId project)
            where T : struct
                => etl(project).Path(FS.file(string.Format("{0}.{1}", project, TableId.identify<T>()),FS.Csv));

        public static FS.FilePath table<T>(ProjectId project, string scope)
            where T : struct
                => etl(project,scope).Path(FS.file(string.Format("{0}.{1}", project, TableId.identify<T>()),FS.Csv));

        [Parser]
        public static Outcome parse(string src, out Tool dst)
        {
            ToolId id = text.trim(src);
            dst = id;
            return true;
        }

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
                parse(reader.Next(), out dst.Tool).Require();
                DataParser.parse(reader.Next(), out dst.SourceName).Require();
                DataParser.parse(reader.Next(), out dst.TargetName).Require();
                DataParser.parse(reader.Next(), out dst.SourcePath).Require();
                DataParser.parse(reader.Next(), out dst.TargetPath).Require();
            }
            return new(WsCatalog.load(id), buffer);
        }
    }
}
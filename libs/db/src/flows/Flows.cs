//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [ApiHost]
    public class Flows
    {
        static AppDb AppDb => AppDb.Service;

        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline)]
        public static FlowId identify<A,S,T>(A actor, S src, T dst)
            => new FlowId(hash(actor), hash(src), hash(dst));

        public static string format<S,T>(IFlow<S,T> flow)
            => $"{flow.Source} -> {flow.Target}";

        public static IDbTargets etl(ProjectId id)
            => AppDb.Service.DbProjects(id);

        [MethodImpl(Inline)]
        public static FileFlow flow(in CmdFlow src)
            => new FileFlow(flow(src.Tool, src.SourcePath.ToUri(), src.TargetPath.ToUri()));

        public static FS.FilePath flow(ProjectId id)
            => AppDb.DbProjects(id).Path(FS.file(string.Format("{0}.build.flows", id), FS.Csv));

        public static FS.FilePath table<T>(ProjectId project)
            where T : struct
                => AppDb.DbProjects(project).Path(FS.file(string.Format("{0}.{1}", project, TableId.identify<T>()),FS.Csv));

        public static FS.FilePath table<T>(ProjectId project, string scope)
            where T : struct
                => AppDb.DbProjects(project).Targets(scope).Path(FS.file(string.Format("{0}.{1}", project, TableId.identify<T>()),FS.Csv));

        [MethodImpl(Inline)]
        public static Relation<K,S,T> relation<K,S,T>(K kind, S src, T dst)
            where K : unmanaged
            where S : unmanaged
            where T : unmanaged
                => new Relation<K,S,T>(kind, src, dst);


        [Parser]
        public static Outcome parse(string src, out Tool dst)
        {
            ToolId id = text.trim(src);
            dst = id;
            return true;
        }

        // [MethodImpl(Inline)]
        // public static FileFlow flow(in CmdFlow src)
        //     => new FileFlow(WsCmdFlows.flow(src.Tool, src.SourcePath.ToUri(), src.TargetPath.ToUri()));

        [MethodImpl(Inline)]
        public static DataFlow<Actor,S,T> flow<S,T>(Tool tool, S src, T dst)
            => new DataFlow<Actor,S,T>(tool,src,dst);


    }
}
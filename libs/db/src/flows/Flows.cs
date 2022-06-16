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

        public static FS.FilePath flow(IWsProject src)
            => AppDb.DbProjects(src).Path(FS.file(string.Format("{0}.build.flows", src.Id), FS.Csv));

        public static FS.FilePath flow(ProjectId src)
            => AppDb.DbProjects(src).Path(FS.file(string.Format("{0}.build.flows", src), FS.Csv));

        public static FS.FilePath table<T>(ProjectId src)
            where T : struct
                => AppDb.DbProjects(src).Path(FS.file(string.Format("{0}.{1}", src, TableId.identify<T>()),FS.Csv));

        public static FS.FilePath table<T>(ProjectId src, string scope)
            where T : struct
                => AppDb.DbProjects(src).Targets(scope).Path(FS.file(string.Format("{0}.{1}", src, TableId.identify<T>()),FS.Csv));

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

        [MethodImpl(Inline)]
        public static DataFlow<Actor,S,T> flow<S,T>(Tool tool, S src, T dst)
            => new DataFlow<Actor,S,T>(tool,src,dst);

        public static WsDataFlows load(IWsProject src)
        {
            var path = Flows.flow(src);
            var lines = path.ReadLines(TextEncodingKind.Asci,true);
            var buffer = alloc<CmdFlow>(lines.Length - 1);
            var reader = lines.Reader();
            reader.Next(out _);
            var i = 0u;
            while(reader.Next(out var line))
            {
                var parts = text.trim(text.split(line,Chars.Pipe));
                Require.equal(parts.Length,CmdFlow.FieldCount);
                var cells = parts.Reader();
                ref var dst = ref seek(buffer,i++);
                Flows.parse(cells.Next(), out dst.Tool).Require();
                DataParser.parse(cells.Next(), out dst.SourceName).Require();
                DataParser.parse(cells.Next(), out dst.TargetName).Require();
                DataParser.parse(cells.Next(), out dst.SourcePath).Require();
                DataParser.parse(cells.Next(), out dst.TargetPath).Require();
            }
            return new(WsCatalog.load(src), buffer);
        }

    }
}
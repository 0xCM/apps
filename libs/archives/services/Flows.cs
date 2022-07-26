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
            => new FlowId(Algs.hash(actor), Algs.hash(src), Algs.hash(dst));

        [MethodImpl(Inline), Op]
        public static FileFlowContext context(IWsProject src)
            => new FileFlowContext(src, load(src));

        [MethodImpl(Inline), Op]
        public static DataFlow<Actor,S,T> flow<S,T>(Tool tool, S src, T dst)
            => new DataFlow<Actor,S,T>(FlowId.identify(tool,src,dst), tool,src,dst);

        [MethodImpl(Inline), Op]
        public static FileFlow flow(in CmdFlow src)
            => new FileFlow(flow(src.Tool, src.SourcePath.ToUri(), src.TargetPath.ToUri()));

        public static FS.FilePath path(IWsProject src)
            => src.BuildOut() + FS.file($"{src.Id}.build.flows",FileKind.Csv);

        public static FS.FilePath table<T>(ProjectId src)
            where T : struct
                => AppDb.EtlTargets(src).Path(FS.file(string.Format("{0}.{1}", src, TableId.identify<T>()),FS.Csv));

        public static FS.FilePath table<T>(ProjectId src, string scope)
            where T : struct
                => AppDb.EtlTargets(src).Targets(scope).Path(FS.file(string.Format("{0}.{1}", src, TableId.identify<T>()),FS.Csv));

        [Parser]
        public static Outcome parse(string src, out Tool dst)
        {
            dst = text.trim(src);
            return true;
        }

        public static DataFlowCatalog load(IWsProject src)
        {
            var path = Flows.path(src);
            var lines = path.ReadLines(TextEncodingKind.Asci,true);
            var buffer = sys.alloc<CmdFlow>(lines.Length - 1);
            var reader = lines.Storage.Reader();
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
            return new(FileCatalog.load(src.ProjectFiles().Storage.ToSortedSpan()), buffer);
        }
    }
}
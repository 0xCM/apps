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

        public static WsDataFlows load(IWsProject src)
        {
            var path = Flows.path(src);
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
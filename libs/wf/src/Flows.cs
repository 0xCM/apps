//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public interface IFlowContext
    {


    }

    public interface IFlowContext<C> : IFlowContext
        where C : IFlowContext<C>
    {


    }

    public abstract class FlowContext<C>
        where C : FlowContext<C>
    {


    }

    public class FlowCatalogs
    {
        static Outcome parse(string src, out Tool dst)
        {
            dst = text.trim(src);
            return true;
        }

        public static DataFlowCatalog load(IProjectWorkspace src)
        {
            var path = BuildContext.path(src);
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
                parse(cells.Next(), out dst.Tool).Require();
                DataParser.parse(cells.Next(), out dst.SourceName).Require();
                DataParser.parse(cells.Next(), out dst.TargetName).Require();
                DataParser.parse(cells.Next(), out dst.SourcePath).Require();
                DataParser.parse(cells.Next(), out dst.TargetPath).Require();
            }
            return new(FileCatalog.load(src.ProjectFiles().Storage.ToSortedSpan()), buffer);
        }

    }

    public class FlowContext
    {
        [MethodImpl(Inline), Op]
        public static FileFlowContext create(IProjectWorkspace src)
            => new FileFlowContext(src, FlowCatalogs.load(src));
    }

    public class EtlContext
    {
        static AppDb AppDb => AppDb.Service;

        public static FS.FilePath table<T>(ProjectId src)
            where T : struct
                => AppDb.EtlTargets(src).Path(FS.file(string.Format("{0}.{1}", src, TableId.identify<T>()),FS.Csv));

        public static FS.FilePath table<T>(ProjectId src, string scope)
            where T : struct
                => AppDb.EtlTargets(src).Targets(scope).Path(FS.file(string.Format("{0}.{1}", src, TableId.identify<T>()),FS.Csv));
    }

    public class BuildContext
    {
        public static FS.FilePath path(IProjectWorkspace src)
            => src.BuildOut() + FS.file($"{src.ProjectId}.build.flows",FileKind.Csv);
    }
}
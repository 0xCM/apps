//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class WsApi : AppService<WsApi>
    {
        public static WsContext context(IProjectWs project)
            => new WsContext(project, flows(project));

        [MethodImpl(Inline)]
        public static WsDataFlow flow(in ToolCmdFlow src)
        {
            var flow = DataFlows.flow(src.TargetName, src.SourcePath.ToUri(), src.TargetPath.ToUri());
            return new WsDataFlow(DataFlows.identify(flow), flow);
        }

        public static WsDataFlows flows(IProjectWs ws)
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
                Tools.parse(reader.Next(), out dst.Tool).Require();
                DataParser.parse(reader.Next(), out dst.SourceName).Require();
                DataParser.parse(reader.Next(), out dst.TargetName).Require();
                DataParser.parse(reader.Next(), out dst.SourcePath).Require();
                DataParser.parse(reader.Next(), out dst.TargetPath).Require();
            }
            return new (FileCatalog.load(ws), buffer);
        }
    }
}
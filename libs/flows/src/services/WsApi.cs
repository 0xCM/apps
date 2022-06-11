//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class WsApi : AppService<WsApi>
    {
        static AppDb AppDb => GlobalSvc.Instance.AppDb;

        public static IProjectWs project(FS.FolderPath root, ProjectId id)
            => ProjectWs.create(root, id);

        public static WsContext context(IProjectWs project)
            => new WsContext(project, flows(project.Project));

        public static FS.FilePath flow(ProjectId project, ScriptId script)
            => data(project).Path(Tables.filename<ToolCmdFlow>(script));

        public static FS.FilePath flow(ProjectId id)
            => data(id).Path(FS.file(string.Format("{0}.build.flows", id), FS.Csv));

        public static DbTargets data(ProjectId id)
            => AppDb.ProjectData(id);

        public static DbTargets data(ProjectId id, string scope)
            => AppDb.ProjectData(id).Targets(scope);

        public static FS.FilePath table<T>(ProjectId project)
            where T : struct
                => data(project).Path(FS.file(string.Format("{0}.{1}", project, TableId.identify<T>()),FS.Csv));

        public static FS.FilePath table<T>(ProjectId project, string scope)
            where T : struct
                => data(project,scope).Path(FS.file(string.Format("{0}.{1}", project, TableId.identify<T>()),FS.Csv));

        public static FS.FilePath path(ProjectId project, string suffix, FileKind kind)
            => data(project).Path(FS.file(string.Format("{0}.{1}", project, suffix), kind.Ext()));

        public static WsDataFlow flow(in ToolCmdFlow src)
        {
            var flow = DataFlows.flow(src.TargetName, src.SourcePath.ToUri(), src.TargetPath.ToUri());
            return new WsDataFlow(DataFlows.identify(flow), flow);
        }

        public static WsDataFlows flows(ProjectId id)
        {
            var path = flow(id);
            var lines = path.ReadLines(TextEncodingKind.Asci,true);
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
            return new(FileCatalog.load(id), buffer);
        }
    }
}
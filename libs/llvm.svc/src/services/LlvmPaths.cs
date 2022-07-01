//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static ApiGranules;

    using G = ApiGranules;

    public class LlvmPaths : WfSvc<LlvmPaths>
    {
        const string Base = llvm + Slash;

        const string tables = Base + G.tables;

        const string records = Base + G.records;

        const string tools = Base + G.tools;

        const string logs = Base + G.logs;

        const string queries = Base + G.queries;

        const string files = Base + G.files;

        const string project = "llvm.data";

        public IDbTargets LogTargets()
            => AppDb.DbOut(logs);

        public FS.FilePath DbTable<T>()
            where T : struct
                => Tables().Table<T>();

        public FS.FilePath DbTable(string id)
            => Tables().Path(FS.file(id, FS.Csv));

        public IDbSources Dev()
            => AppDb.DevProjects().Sources(project);

        public IDbTargets Tables()
            => AppDb.DbOut(tables);

        public IDbTargets RecordImports()
            => AppDb.DbOut(records);

        public IDbTargets ToolImports()
            => AppDb.DbOut(tools);

        public IDbTargets QueryOut()
            => AppDb.DbOut(queries);

        public FS.FilePath QueryOut(FS.FileName file)
            => QueryOut().Path(file);

        public FS.FilePath ImportMap(string id)
            => RecordImports().Path(id, FileKind.Map);

        public IDbSources DevSources()
            => Dev().Sources(sources);

        public IDbSources DevSources(string scope)
            => DevSources().Sources(scope);

        public FS.FilePath DevSource(string scope, string name)
            => DevSources(scope).Path(name, FileKind.Txt);

        public FS.FilePath TableGenHeader(LlvmTargetName target, string kind)
            => LlvmSources("include").Path($"{target}.{kind}", FileKind.H);

        public FS.Files TableGenHeaders(LlvmTargetName target)
            => LlvmSources("include").Files(FileKind.H).Where(f => f.FileName.StartsWith($"{target}."));

        public IDbSources DevViews()
            => Dev().Sources(views);

        public IDbSources DevViews(string scope)
            => DevViews().Sources(scope);

        public IDbSources DevSettings()
            => Dev().Sources(settings);

        public FS.FilePath DevSettings(string name, FS.FileExt ext)
            => DevSettings().Path(FS.file(name,ext));

        public IDbSources LlvmSourceView()
            => DevViews(llvm);

        public FS.FolderPath LlvmRoot
            => Env.LlvmRoot;

        public IDbSources LlvmSources()
            => AppDb.DbIn(llvm);

        public IDbSources LlvmSources(string scope)
            => AppDb.DbIn(llvm).Sources(scope);

        public IDbSources RecordSources()
            => LlvmSources("records");

        public IDbSources HelpSouces()
            => LlvmSources("docs/help");

        public IDbSources SourceSettings()
            => LlvmSources("settings");

        public FS.FilePath RecordSource(string id)
            => RecordSources().Path(id, FileKind.Txt);

        public IDbTargets FileTargets()
            => AppDb.DbOut(files);

        public FS.FilePath File(string name, FileKind kind)
            => FileTargets().Path(name, kind);

        public FS.Files Lists()
            => Tables().Files(FileKind.Csv).Where(f => f.FileName.StartsWith("llvm.lists."));

        public Index<string> ListNames()
            => Lists().Map(x => x.FileName.WithoutExtension.Format().Remove("llvm.lists."));

        public FS.FilePath ListImportPath(string id)
            => DbTable(string.Format("llvm.lists.{0}", id));

        public IDbTargets CodeGen()
            => AppDb.CgRoot().Targets("cg.llvm/src");
    }
}
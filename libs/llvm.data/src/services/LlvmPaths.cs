//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    public class LlvmPaths : WfSvc<LlvmPaths>
    {
        const string tables = "llvm/tables";

        const string records = "llvm/records";

        const string tools = "llvm/tools";

        const string logs = "llvm/logs";

        const string queries = "llvm/queries";

        const string files = "llvm/files";

        const string project = "llvm.data";

        public IDbTargets LogTargets()
            => AppDb.DbTargets(logs);

        public FS.FilePath DbTable<T>()
            where T : struct
                => Tables().Table<T>();

        public FS.FilePath DbTable(string id)
            => Tables().Path(FS.file(id, FS.Csv));

        public IDbSources Dev()
            => AppDb.Dev().Sources(project);

        public IDbTargets Tables()
            => AppDb.DbTargets(tables);

        public IDbTargets RecordImports()
            => AppDb.DbTargets(records);

        public IDbTargets ToolImports()
            => AppDb.DbTargets(tools);

        public IDbTargets QueryOut()
            => AppDb.DbTargets(queries);

        public FS.FilePath QueryOut(FS.FileName file)
            => QueryOut().Path(file);

        public FS.FilePath ImportMap(string id)
            => RecordImports().Path(id, FileKind.Map);

        public IDbSources DevSources()
            => Dev().Sources("sources");

        public IDbSources DevSources(string scope)
            => DevSources().Sources(scope);

        public FS.FilePath DevSource(string scope, string name)
            => DevSources(scope).Path(name, FileKind.Txt);

        public FS.Files TableGenHeaders()
            => DevSources("headers").Files(FS.H);

        public IDbSources DevViews()
            => Dev().Sources("views");

        public IDbSources DevViews(string scope)
            => DevViews().Sources(scope);

        public IDbSources DevSettings()
            => Dev().Sources("settings");

        public FS.FilePath DevSettings(string name, FS.FileExt ext)
            => DevSettings().Path(FS.file(name,ext));

        public IDbSources LlvmSourceView()
            => DevViews("llvm");

        public FS.FolderPath LlvmRoot
            => Env.LlvmRoot;

        public IDbTargets FileTargets()
            => AppDb.DbTargets(files);

        public FS.FilePath File(string id, FileKind kind)
            => FileTargets().Path(id,kind);

        public FS.Files Lists()
            => Tables().Files(FileKind.Csv).Where(f => f.FileName.StartsWith("llvm.lists."));

        public Index<string> ListNames()
            => Lists().Map(x => x.FileName.WithoutExtension.Format().Remove("llvm.lists."));

        public FS.FilePath ListImportPath(string id)
            => DbTable(string.Format("llvm.lists.{0}", id));

        public IDbTargets CodeGen()
            => AppDb.CodeGen().Targets("codegen.llvm/src");
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    public class LlvmPaths : AppService<LlvmPaths>
    {
        IProjectWs LlvmData;

        new IProjectDb Db;

        protected override void OnInit()
        {
            LlvmData = Ws.Project("llvm.data");
            Db = Ws.ProjectDb();
        }

        public FS.FolderPath DataHome()
            => LlvmData.Home();

        public FS.FolderPath Tables()
            => Db.Subdir("llvm") + FS.folder("tables");

        public FS.FolderPath RecordImports()
            => Db.Subdir("llvm") + FS.folder("records");

        public FS.FolderPath ToolImports()
            => Db.Subdir("llvm") + FS.folder("tools");

        public FS.FolderPath Queries()
            => Db.Subdir("llvm") + FS.folder("queries");

        public FS.FilePath Query(FS.FileName file)
            => Db.Subdir("llvm") + FS.folder("queries") + file;

        public FS.FilePath ImportMap(string id)
            => RecordImports() + FS.file(id, FS.ext("map"));

        public FS.FolderPath ToolSourceDocs()
            => DataSourceDir("tools");

        public FS.FolderPath Sources()
            => DataHome() + FS.folder("sources");

        public FS.FolderPath Views()
            => DataHome() + FS.folder("views");

        public FS.FolderPath Settings()
            => DataHome() + FS.folder("settings");

        public FS.FilePath Settings(string name, FS.FileExt ext)
            => Settings() + FS.file(name,ext);

        public FS.Files TableGenHeaders()
            => DataSourceDir("headers").Files(FS.H);

        public FS.FolderPath View(string id)
            => Views() + FS.folder(id);

        public FS.FolderPath LlvmSourceView()
            => View("llvm");

        public FS.FolderPath LlvmRoot
            => Env.LlvmRoot;

        public FS.FilePath File(string id, FS.FileExt ext)
            => Db.Subdir("llvm") + FS.folder("files") + FS.file(id,ext);

        public FS.FilePath Table<T>()
            where T : struct
                => Db.Subdir("llvm") + FS.folder("tables") + Z0.Tables.filename<T>();

        public FS.FilePath Table(string id)
            => Db.Subdir("llvm") + FS.folder("tables") + FS.file(id, FS.Csv);

        public FS.FilePath Table<T>(string id)
            where T : struct
                => Db.Subdir("llvm") + FS.folder("tables") + FS.file(id,FS.Csv);

        public FS.Files Lists()
            => Tables().Files(FS.Csv).Where(f => f.FileName.StartsWith("llvm.lists."));

        public FS.FolderPath DataSourceDir(string scope)
            => Sources() + FS.folder(scope);

        public FS.FilePath DataSourcePath(string scope, string name)
            => DataSourceDir(scope) + FS.file(name, FS.Txt);

        public Index<string> ListNames()
            => Lists().Map(x => x.FileName.WithoutExtension.Format().Remove("llvm.lists."));

        public FS.FilePath ListImportPath(string id)
            => Table(string.Format("llvm.lists.{0}", id));

        public FS.FolderPath CodeGen()
            => Env.ZDev + FS.folder("codegen/codegen.llvm/src");
    }
}
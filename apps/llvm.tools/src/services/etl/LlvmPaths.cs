//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    public class LlvmPaths : WsService<LlvmPaths>
    {
        IProjectWs LlvmData;

        protected override void Initialized()
        {
            LlvmData = Ws.Project("llvm.data");
        }

        public FS.FolderPath DataHome()
            => LlvmData.Home();

        public FS.FolderPath Imports()
            => DataHome() + FS.folder("imports");

        public FS.FolderPath ToolSourceDocs()
            => DataSourceDir("tools");

        public FS.FolderPath Sources()
            => LlvmData.Subdir("sources");

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

        public FS.FolderPath Tables()
            => Imports() + FS.folder("tables");

        public FS.FolderPath LlvmRoot
            => Env.LlvmRoot;

        public FS.FolderPath TmpDir()
            => DataHome() + FS.folder(".tmp");

        public FS.FilePath TmpFile(string id, FS.FileExt ext)
            => TmpDir() + FS.file(id,ext);

        public FS.FolderPath Tables(string scope)
            => Tables() + FS.folder(scope);

        public FS.FilePath Table<T>()
            where T : struct
                => Tables() + Z0.Tables.filename<T>();

        public FS.FilePath Table(string id)
            => Tables() + FS.file(id, FS.Csv);

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

        public FS.FolderPath RecordImports()
            => Imports() + FS.folder("records");

        public FS.FilePath RecordImport(string id, FS.FileExt ext)
            =>  RecordImports() + FS.file(id, ext);

        public FS.FilePath ImportMap(string id)
            => RecordImports() + FS.file(id, FS.ext("map"));

        public FS.FolderPath CodeGen()
            => Env.ZDev + FS.folder("generated/src/llvm");

        public FS.FilePath CodeGenPath(string id, FS.FileExt ext)
            => CodeGen() + FS.file(id,ext);

        public FS.FilePath StringTablePath(string id, FS.FileExt ext)
            => CodeGen() + FS.folder("stringtables") + FS.file(id,ext);
    }
}
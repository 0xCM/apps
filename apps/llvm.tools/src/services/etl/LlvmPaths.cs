//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static WsAtoms;

    public class LlvmPaths : WsService<LlvmPaths>
    {
        IProjectWs LlvmData;

        protected override void Initialized()
        {
            LlvmData = Ws.Project("llvm.data");
        }

        public FS.FolderPath Views()
            => LlvmData.Home() + FS.folder("views");

        public FS.FolderPath Out()
            => LlvmData.Out();

        public FS.FolderPath Out(string subdir)
            => Out() + FS.folder(subdir);

        public FS.Files TableGenHeaders()
            => Out("headers").Files(FS.H);

        public FS.FolderPath View(string id)
            => Views() + FS.folder(id);

        public FS.FolderPath LlvmSourceView()
            => View("llvm");

        public FS.FolderPath Tables()
            => LlvmData.Tables();

        public FS.FolderPath LlvmRoot
            => Env.LlvmRoot;

        public FS.FolderPath TmpDir()
            => LlvmData.Home() + FS.folder(".tmp");

        public FS.FilePath TmpFile(string id, FS.FileExt ext)
            => TmpDir() + FS.file(id,ext);

        public FS.FolderPath Tables(string scope)
            => Tables() + FS.folder(scope);

        public FS.FilePath Table<T>()
            where T : struct
                => Tables() + Z0.Tables.filename<T>();

        public FS.FilePath Table(string id)
            => Tables() + FS.file(id, FS.Csv);

        public FS.FolderPath Docs()
            => LlvmData.Subdir("docs");

        public FS.FolderPath Docs(string scope)
            => Docs() + FS.folder(scope);

        public FS.FolderPath ListImports()
            => Tables("lists");

        public FS.Files Lists()
            => Tables().Files(FS.Csv).Where(f => f.FileName.StartsWith("llvm.lists."));

        public FS.FilePath ListImportPath(string name)
            => Tables() + FS.file(name, FS.Csv);

        public FS.FilePath DataSourcePath(string name)
            => LlvmData.OutDir() + FS.file(name, FS.Txt);

        public FS.FolderPath RecordImports()
            => LlvmData.Subdir("records");

        public FS.FilePath RecordImport(string id, FS.FileExt ext)
            =>  RecordImports() + FS.file(id, ext);

        public FS.FilePath ImportMap(string id)
            => RecordImports() + FS.file(id, FS.ext("map"));

        public FS.FolderPath CodeGen()
            => Env.ZDev + FS.folder("generated/src/llvm");

        public FS.FolderPath ListSources()
            => LlvmData.OutDir() + FS.folder(lists);

        public FS.Files ListSourceFiles()
            => ListSources().Files(FS.List);

        public FS.FilePath CodeGenPath(string id, FS.FileExt ext)
            => CodeGen() + FS.file(id,ext);

        public FS.FilePath StringTablePath(string id, FS.FileExt ext)
            => CodeGen() + FS.folder("stringtables") + FS.file(id,ext);
    }
}
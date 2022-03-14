//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class AppDb : AppService<AppDb>
    {
        FS.FolderPath Root;

        protected override void Initialized()
        {
            Root = ProjectDb.Root;
        }

        public FS.FolderPath Api()
            => Root + FS.folder("api");

        public FS.FolderPath Api(string scope)
            => Api() + FS.folder(scope);

        public FS.FilePath ApiPath(string name, FileKind kind)
            => Api() + file(name,kind);

        public FS.FilePath ApiPath(string scope, string name, FileKind kind)
            => Api(scope) + file(name, kind);

        public FS.FolderPath Logs()
            => Root + FS.folder("logs");

        public FS.FolderPath Logs(string scope)
            => Logs() + FS.folder(scope);

        public FS.FilePath Log(string name, FileKind kind)
            => Logs() + file(name, kind);

        public FS.FilePath Log(string scope, string name, FileKind kind)
            => Logs(scope) + file(name, kind);

        public FS.FolderPath Xed()
            => Root + FS.folder("xed");

        public FS.FolderPath Xed(string scope)
            => Xed() + FS.folder(scope);

        public FS.FilePath XedTable<T>()
            where T : struct
                => Xed() + Tables.filename<T>();

        public FS.FilePath XedTable<T>(string scope)
            where T : struct
                => Xed(scope) + Tables.filename<T>();

        public FS.FilePath XedTable<T>(string scope, string suffix)
            where T : struct
                => Xed(scope) + Tables.filename<T>().ChangeExtension(FS.ext(string.Format("{0}.{1}", suffix, FS.Csv)));

        public FS.FilePath XedPath(string name, FileKind kind)
            => Xed() + FS.file(name, kind.Ext());

        public FS.FolderPath CgStage()
            => Root + FS.folder("cgstage");

        public FS.FolderPath CgStage(string scope)
            => CgStage() + FS.folder(scope);

        public FS.FilePath CgStagePath(string name, FileKind kind)
            => CgStage() + file(name,kind);

        public FS.FilePath CgStagePath(string scope, string name, FileKind kind)
            => CgStage(scope) + file(name,kind);

        public FS.FilePath ApiEnumListPath()
            => ApiPath("api.enums.types", FileKind.List);

        static FS.FileName file(string name, FileKind kind)
            => FS.file(name, kind.Ext());
    }
}
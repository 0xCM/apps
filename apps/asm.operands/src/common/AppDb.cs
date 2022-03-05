//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

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

        public FS.FilePath ApiPath(string name, FS.FileExt ext)
            => Api() + FS.file(name, ext);

        public FS.FilePath ApiPath(string name, FileKind kind)
            => ApiPath(name, kind.Ext());

        public FS.FilePath ApiPath(string scope, string name, FS.FileExt ext)
            => Api(scope) + FS.file(name,ext);

        public FS.FilePath ApiPath(string scope, string name, FileKind kind)
            => ApiPath(scope,name, kind.Ext());

        public FS.FolderPath Xed()
            => Root + FS.folder("xed");

        public FS.FilePath XedTable<T>()
            where T : struct
                => Xed() + Tables.filename<T>();

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
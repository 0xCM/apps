//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ScriptArchive : IRootedArchive
    {
        public readonly FS.FolderPath Root {get;}

        public ScriptArchive(FS.FolderPath root)
        {
            Root = root;
        }

        FS.FileExt Ext => FS.Cmd;

        public FS.FilePath Script(string id)
            => Root + FS.file(id, Ext);

        public FS.FilePath Script(string dir, string id)
            => ScriptDir(dir) + FS.file(id,Ext);

        public ReadOnlySpan<FS.FilePath> Scripts()
            => Root.Files(Ext, true);

        public FS.FolderPath ScriptDir(string id)
            => Root + FS.folder(id);

        public ReadOnlySpan<FS.FilePath> Scripts(string dir)
            => ScriptDir(dir).Files(Ext);

        public static implicit operator ScriptArchive(FS.FolderPath root)
            => new ScriptArchive(root);
    }
}
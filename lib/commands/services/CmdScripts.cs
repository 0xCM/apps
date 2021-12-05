//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct CmdScripts : IFileArchive
    {
        public FS.FolderPath Root {get;}

        [MethodImpl(Inline)]
        public CmdScripts(FS.FolderPath root)
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

        public static implicit operator CmdScripts(FS.FolderPath root)
            => new CmdScripts(root);
    }
}
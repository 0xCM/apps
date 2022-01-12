//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static EnvFolders;

    public readonly struct CodeGenArchive : IFileArchive
    {
        public FS.FolderPath Root {get;}

        [MethodImpl(Inline)]
        public CodeGenArchive(FS.FolderPath root)
        {
            Root = root;
        }

        [MethodImpl(Inline)]
        public static implicit operator CodeGenArchive(FS.FolderPath root)
            => new CodeGenArchive(root);

        public FS.FolderPath Input()
            => Root + FS.folder(input);

        public FS.FolderPath Output()
            => Root + FS.folder(output);
        public FS.FolderPath InputDir(string subject)
            => Input() + FS.folder(subject);

        public FS.FolderPath OutputDir(string subject)
            => Output() + FS.folder(subject);

        public FS.FilePath InputPath(FS.FileName file)
            => Input() + file;

        public FS.FilePath OutputPath(FS.FileName file)
            => Output() + file;

        public FS.FilePath InputPath(string subject, FS.FileName file)
            => InputDir(subject) + file;

        public FS.FilePath OutputPath(string subject, FS.FileName file)
            => OutputDir(subject) + file;
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct TableArchive : IFileArchive
    {
        [MethodImpl(Inline)]
        public static TableArchive create(FS.FolderPath root)
            => new TableArchive(root);

        public FS.FolderPath Root {get;}

        public TableArchive(FS.FolderPath root)
        {
            Root = root;
        }

        public FS.FolderPath Dir(Subject scope)
            => Root + FS.folder(scope.Format());

        public FS.FilePath Path(Subject scope, TableId id)
            => Dir(scope) + Name(id);

        public FS.FilePath Path(TableId id)
            => Root + Name(id);

        public FS.FilePath Path<T>()
            where T : struct
                => Root + Name<T>();

        public FS.FilePath Path<T>(Subject scope)
            where T : struct
                => Dir(scope) + Name<T>();

        public FS.FileName Name<T>()
            where T : struct
                => FS.file(Tables.identify<T>().Format(), FS.Csv);

        public FS.FileName Name(TableId id)
            => FS.file(id.Format(), FS.Csv);

        public FS.FileName Name(TableId id, string suffix)
            => FS.file(string.Format("{0}.{1}", id, suffix), FS.Csv);
    }
}
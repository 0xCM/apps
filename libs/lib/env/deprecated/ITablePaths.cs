//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public interface ITablePaths
    {
        FS.FileExt DefaultTableExt
             => FS.Csv;

        string TableId<T>()
            where T : struct
                => Z0.TableId.identify<T>().Identifier.Format();

        FS.FolderName TableFolder<T>()
            where T : struct
                => FS.folder(TableId<T>());

        FS.FileName TableFile<T>()
            where T : struct
                => FS.file(TableId<T>(), DefaultTableExt);

        FS.FileName TableFile<T>(string suffix)
            where T : struct
                => FS.file(string.Format("{0}.{1}", TableId<T>(), suffix), DefaultTableExt);

        FS.FileName TableFile<T>(string prefix, string suffix)
            where T : struct
                => FS.file(string.Format("{0}.{1}.{2}",prefix, TableId<T>(), suffix), DefaultTableExt);

        FS.FileName TableFile(TableId id)
            => FS.file(id.Format(), DefaultTableExt);

        FS.FileName TableName(string id)
            => FS.file(id, FS.Csv);
    }
}
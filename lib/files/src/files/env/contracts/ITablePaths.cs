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

        string TableId(Type t)
            => Z0.TableId.identify(t).Identifier.Format();

        string TableId<T>()
            where T : struct
                => Z0.TableId.identify<T>().Identifier.Format();

        FS.FolderName TableFolder<T>()
            where T : struct
                => FS.folder(TableId<T>());

        FS.FileName TableFile<T>()
            where T : struct
                => FS.file(TableId<T>(), DefaultTableExt);

        FS.FileName TableFile<T>(string subject)
            where T : struct
                => FS.file(string.Format("{0}.{1}", TableId<T>(), subject), DefaultTableExt);

        FS.FolderName TableFolder(Type t)
            => FS.folder(TableId(t));

        FS.FileName TableFile<T>(ApiHostUri host, FS.FileExt? ext = null)
            where T : struct
                => FS.file(string.Format("{0}.{1}.{2}", TableId<T>(), host.Part.Format(), host.HostName), ext ?? DefaultTableExt);

        FS.FileName TableFile<T>(PartId part, FS.FileExt? ext = null)
            where T : struct
                => FS.file(string.Format("{0}.{1}", TableId<T>(), part.Format()), ext ?? DefaultTableExt);

        FS.FilePath TablePath<T>(FS.FolderPath dir)
            where T : struct
                => dir + FS.file(Z0.TableId.identify<T>().Format(), DefaultTableExt);

        FS.FileName TableFile(TableId id)
            => FS.file(id.Format(), DefaultTableExt);

        FS.FileName TableName(string id)
            => FS.file(id, FS.Csv);

        FS.FileName TableFile(string id)
            => FS.file(id, FS.Csv);

        FS.FileName TableFile(TableId id, string suffix)
            => FS.file(string.Format("{0}.{1}", id, suffix), DefaultTableExt);
    }
}
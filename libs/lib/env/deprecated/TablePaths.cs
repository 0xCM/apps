//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static EnvFolders;

    partial interface IEnvPaths
    {
        FS.FolderPath TableRoot(FS.FolderPath root)
            => root + FS.folder(tables);

        FS.FolderPath TableDir(string subject)
            => Env.Db + FS.folder(tables) + FS.folder(subject);

        FS.FolderPath TableDir(FS.FolderName subject)
            => Env.Db + FS.folder(tables) + subject;

        FS.FolderPath TableDir(Type t)
            => t.Tag<RecordAttribute>().MapValueOrElse(a => TableDir(a.TableId), () => TableDir(t.Name));

        FS.FolderPath TableDir<T>()
            where T : struct
                => TableDir(typeof(T));

        FS.FilePath Table(FS.FolderPath dir, string subject, PartId part)
            => dir + FS.file(string.Format(RP.SlotDot2, subject, part.Format()), DefaultTableExt);

        FS.FilePath Table<T>(FS.FolderName subject)
            where T : struct
                => TableDir(subject) + FS.file(TableId<T>(), DefaultTableExt);

        FS.FilePath Table<T>(FS.FolderPath dir)
            where T : struct
                => dir + FS.file(TableId<T>(), DefaultTableExt);

        FS.FilePath Table<S>(FS.FolderPath dir, S subject)
            => dir + FS.file(subject.ToString(), DefaultTableExt);

        FS.FilePath IndexTable(string id)
            => IndexRoot() + FS.file(id, DefaultTableExt);

        FS.FilePath IndexTable(Type t)
            => t.Tag<RecordAttribute>().MapValueOrElse(a => IndexTable(a.TableId), () => IndexTable(t.Name));

        FS.FilePath IndexTable<T>()
            where T : struct
                => IndexTable(typeof(T));

        FS.FolderPath AppTableRoot
            => AppLogRoot() + FS.folder(tables);

        FS.FolderPath AppTableDir<T>()
            where T : struct
                => AppTableRoot + TableFolder<T>();

        FS.FilePath AppTablePath<T>(FS.FileExt? ext = null)
            where T : struct
        {
            var id = TableId<T>();
            var dir = AppTableDir<T>();
            return dir + FS.file(id, ext ?? FS.Csv);
        }
    }
}
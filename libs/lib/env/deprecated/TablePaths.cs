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
            => dir + FS.file(string.Format(RpOps.SlotDot2, subject, part.Format()), DefaultTableExt);

        FS.FilePath Table<T>(FS.FolderName subject)
            where T : struct
                => TableDir(subject) + FS.file(TableId<T>(), DefaultTableExt);

        FS.FilePath Table<T>(FS.FolderPath dir)
            where T : struct
                => dir + FS.file(TableId<T>(), DefaultTableExt);

        FS.FilePath Table<S>(FS.FolderPath dir, S subject)
            => dir + FS.file(subject.ToString(), DefaultTableExt);

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
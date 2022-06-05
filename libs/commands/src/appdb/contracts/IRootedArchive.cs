//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public interface IRootedArchive
    {
        FS.FolderPath Root {get;}

        /// <summary>
        /// Returns all files provided by the source
        /// </summary>
        FS.Files Files()
            => Root.Files(true);

        /// <summary>
        /// Returns all source-provided files of specified kind
        /// </summary>
        /// <param name="kind">The kind</param>
        FS.Files Files(FileKind kind)
            => Root.Files(kind.Ext(), true);

        FS.FileName File(string name, FileKind kind)
            => FS.file(name, kind.Ext());

        FS.FileName File(string @class, string name, FileKind kind)
            => FS.file(string.Format("{0}.{1}", @class, name), kind.Ext());

        FS.FilePath Path(string name, FileKind kind)
            => Root + File(name, kind);

        FS.FilePath Path(FS.FileName file)
            => Root + file;

        FS.FilePath Table<T>()
            where T : struct
                => Root + Tables.filename<T>();

        FS.FilePath Table<T>(string prefix)
            where T : struct
                => Root + Tables.filename<T>(prefix);
    }

    public interface IRootedArchive<T> : IRootedArchive
        where T : IRootedArchive<T>
    {


    }

    public interface ISourceArchive : IRootedArchive
    {

    }

    public interface ISourceArchive<T> : ISourceArchive
        where T : ISourceArchive<T>
    {

    }

    public interface ITargetArchive : IRootedArchive
    {
        void Delete()
        {
            Root.Delete();
        }

        void Clear()
        {
            Root.Clear();
        }

    }

    public interface ITargetArchive<T> : ITargetArchive
        where T : ITargetArchive<T>
    {
        new T Delete()
        {
            Root.Delete();
            return (T)this;
        }

        new T Clear()
        {
            Root.Clear();
            return (T)this;
        }

        void ITargetArchive.Clear()
            => Clear();

        void ITargetArchive.Delete()
            => Delete();
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
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
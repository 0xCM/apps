//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IDbTargets : IRootedArchive
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

    public interface IDbTargets<T> : IDbTargets
        where T : IDbTargets<T>
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

        void IDbTargets.Clear()
            => Clear();

        void IDbTargets.Delete()
            => Delete();
    }
}
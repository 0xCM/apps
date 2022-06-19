//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static FS;

    public interface IFsEntry : ITextual
    {
        PathPart Name {get;}

        string ITextual.Format()
            => Name.Format();
    }

    public interface IFsEntry<F> : IFsEntry
        where F : struct, IFsEntry<F>
    {

    }

    public interface IFsEntry<F,K>
        where F : struct, IFsEntry<F,K>
        where K : unmanaged
    {
        K Kind {get;}
    }
}
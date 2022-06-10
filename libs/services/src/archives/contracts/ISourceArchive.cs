//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ISourceArchive : IRootedArchive
    {

    }

    public interface ISourceArchive<T> : ISourceArchive
        where T : ISourceArchive<T>
    {

    }


}
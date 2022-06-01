//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [Free]
    public interface IBytes<F> : IByteSeq
        where F : IBytes<F>, new()
    {

    }
}
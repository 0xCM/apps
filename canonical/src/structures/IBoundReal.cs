//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IBoundReal<S> :  IRealNumber<S>
        where S : IBoundReal<S>, new()
    {

    }

}
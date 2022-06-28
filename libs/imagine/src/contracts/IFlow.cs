//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IFlow
    {
        string Format();
    }

    public interface IFlow<S,T> : IFlow, IArrow<S,T>
    {

    }
}
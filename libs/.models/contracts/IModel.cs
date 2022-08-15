//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Contracts
{
    public interface IModel
    {
        string ToString();

        string Format()
            => ToString();
    }

    public interface IModel<M> : IModel
        where M : IModel<M>, new()
    {

    }
}
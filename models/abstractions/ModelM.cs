//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Abstractions
{
    public abstract record class Model<M> : IModel<M>
        where M : Model<M>, new()
    {


    }

}
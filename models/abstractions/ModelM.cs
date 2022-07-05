//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Models
{

    public abstract record class Model<M> : Model, IModel<M>
        where M : Model<M>, new()
    {


    }

}
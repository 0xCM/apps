//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Models
{
    public abstract record class Component<C> : Model<C>, IComponent<C>
        where C : Component<C>, new()
    {


    }

}
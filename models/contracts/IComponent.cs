//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Models
{
    public interface IComponent : IModel
    {
        string Name {get;}

    }

    public interface IComponent<C> : IComponent
        where C : IComponent<C>, new()
    {

    }
}
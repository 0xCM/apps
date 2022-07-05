//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Models
{
    public abstract record class Component<C> : Model<C>, IComponent<C>
        where C : Component<C>, new()
    {
        public string Name;

        string IComponent.Name
            => Name;

        protected Component(string name)
        {
            Name = name;
        }

        protected Component()
        {
            Name = EmptyString;
        }
    }
}
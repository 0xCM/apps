//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Abstractions
{
    public abstract record class Entity<E> : Model<E>, IEntity<E>
        where E : Entity<E>, new()
    {
        public string Name;

        string IEntity.Name
            => Name;

        protected Entity(string name)
        {
            Name = name;
        }

        protected Entity()
        {
            Name = EmptyString;
        }
    }
}
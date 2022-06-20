//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct Actor : IActor, IEquatable<Actor>
    {
        public Identifier Name {get;}

        [MethodImpl(Inline)]
        public Actor(Identifier name)
        {
            Name = name;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => core.hash(Name.Text);
        }

        public string Format()
            => Name;

        public override string ToString()
            => Format();

        public bool Equals(Actor src)
            => Name.Equals(src.Name);

        public override bool Equals(object src)
            => src is Actor a && Equals(a);

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public static implicit operator Actor(Identifier name)
            => new Actor(name);
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct Actor : IActor, IEquatable<Actor>
    {
        public string Name {get;}

        [MethodImpl(Inline)]
        public Actor(string name)
        {
            Name = name;
        }

        public uint Hash
        {
            [MethodImpl(Inline)]
            get => (uint)Name.GetHashCode();
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
            => (int)Hash;

        [MethodImpl(Inline)]
        public static implicit operator Actor(string name)
            => new Actor(name);
    }
}
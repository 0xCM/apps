//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Actor]
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
            get => alg.hash.marvin(Name.Text);
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

        [MethodImpl(Inline)]
        public static implicit operator Actor(Tool tool)
            => new Actor(tool.Name);

        [MethodImpl(Inline)]
        public static implicit operator Actor(ToolId tool)
            => new Actor(tool.Format());
    }
}
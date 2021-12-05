//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct Domain
    {
        public Label Name {get;}

        [MethodImpl(Inline)]
        public Domain(Label name)
        {
            Name = name;
        }

        public string Format()
            => Name.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Domain(string name)
            => new Domain(name);

        [MethodImpl(Inline)]
        public static implicit operator Domain(Label name)
            => new Domain(name);

        [MethodImpl(Inline)]
        public static explicit operator Label(Domain src)
            => src.Name;
    }
}
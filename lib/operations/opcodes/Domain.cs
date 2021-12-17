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
        public text31 Name {get;}

        [MethodImpl(Inline)]
        public Domain(text31 name)
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
    }
}
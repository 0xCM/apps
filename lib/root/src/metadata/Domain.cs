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
        public uint Kind {get;}

        [MethodImpl(Inline)]
        public Domain(uint id)
        {
            Kind = id;
        }

        public string Format()
            => Kind.ToString();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Domain(uint id)
            => new Domain(id);

        [MethodImpl(Inline)]
        public static explicit operator uint(Domain src)
            => src.Kind;
    }

}
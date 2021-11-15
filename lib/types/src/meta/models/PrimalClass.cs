//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Types
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct PrimalClass : IIsomorhphic<PrimalClass,PrimalKind>
    {
        public PrimalKind Kind {get;}

        public PrimalClass(PrimalKind kind)
        {
            Kind = kind;
        }

        public string Format()
            => Kind.ToString().ToLower();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator PrimalClass(PrimalKind src)
            => new PrimalClass(src);

        [MethodImpl(Inline)]
        public static implicit operator PrimalKind(PrimalClass src)
            => src.Kind;
    }
}
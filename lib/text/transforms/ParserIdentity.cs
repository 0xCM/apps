//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct ParserIdentity : ITransformerIdentity
    {
        public Name Source => "string";

        public Name Target {get;}

        [MethodImpl(Inline)]
        public ParserIdentity(Name dst)
        {
            Target = dst;
        }

        public string Format()
            => string.Format("{0} -> {1}", Source, Target);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator TransformerIdentity(ParserIdentity src)
            => new TransformerIdentity(src.Source, src.Target);
    }
}
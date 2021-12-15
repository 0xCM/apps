//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct TransformerIdentity : ITransformerIdentity
    {
        public Name Source {get;}

        public Name Target {get;}

        [MethodImpl(Inline)]
        public TransformerIdentity(Name src, Name dst)
        {
            Source = src;
            Target = dst;
        }

        public string Format()
            => string.Format("{0} -> {1}", Source, Target);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator TransformerIdentity((string src, string dst) x)
            => new TransformerIdentity(x.src, x.dst);
    }
}
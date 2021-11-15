//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Types
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct Domain
    {
        public ushort Id {get;}

        [MethodImpl(Inline)]
        public Domain(ushort id)
        {
            Id = id;
        }

        public string Format()
            => Id.ToString();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Domain(ushort id)
            => new Domain(id);

        [MethodImpl(Inline)]
        public static explicit operator uint(Domain src)
            => src.Id;
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ops
{
    using System.Runtime.CompilerServices;


    using static Root;

    using api = OpCodes;

    public readonly struct OpCode<K>
        where K : unmanaged
    {
        public Domain Domain {get;}

        public text31 Name {get;}

        internal readonly K Data;

        [MethodImpl(Inline)]
        public OpCode(Domain domain, text31 name, K data)
        {
            Domain = domain;
            Name = name;
            Data = data;
        }

        public Hex32 Code
        {
            [MethodImpl(Inline)]
            get => api.code(this);
        }

        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator OpCode(OpCode<K> src)
            => api.untype(src);
    }
}
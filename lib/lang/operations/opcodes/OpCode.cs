//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ops
{
    using System.Runtime.CompilerServices;

    using static Root;

    using api = OpCodes;

    public readonly struct OpCode
    {
        public Domain Domain {get;}

        public text31 Name {get;}

        internal readonly ulong Data;

        [MethodImpl(Inline)]
        public OpCode(Domain domain, text31 name, ulong data)
        {
            Domain = domain;
            Data = data;
            Name = name;
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
    }
}
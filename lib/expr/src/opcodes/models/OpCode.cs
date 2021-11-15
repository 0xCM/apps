//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Expr
{
    using System.Runtime.CompilerServices;

    using Types;

    using static Root;

    using api = OpCodes;

    public readonly struct OpCode
    {
        public readonly Label Name;

        internal readonly ulong Data;

        [MethodImpl(Inline)]
        public OpCode(Label name, ulong data)
        {
            Data = data;
            Name = name;
        }

        public Domain Domain
        {
            [MethodImpl(Inline)]
            get => api.domain(this);
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
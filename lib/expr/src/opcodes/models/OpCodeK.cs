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

    public readonly struct OpCode<K>
        where K : unmanaged
    {
        public readonly Label Name;

        internal readonly K Data;

        [MethodImpl(Inline)]
        public OpCode(Label name, K data)
        {
            Name = name;
            Data = data;
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

        [MethodImpl(Inline)]
        public static implicit operator OpCode(OpCode<K> src)
            => api.untype(src);
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using api = ApiSigs;

    public class ApiOperationSig : ITextual
    {
        public Name Name {get;}

        public ApiOperandSig Return {get;}

        public Index<ApiOperandSig> Operands {get;}

        [MethodImpl(Inline)]
        public ApiOperationSig(Name name, ApiOperandSig @return, ApiOperandSig[] operands)
        {
            Name = name;
            Return = @return;
            Operands = operands;
        }

        public uint OperandCount
        {
            [MethodImpl(Inline)]
            get => (uint)Operands.Length;
        }

        public bool HasVoidReturn
        {
            [MethodImpl(Inline)]
            get => Return.IsVoid;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsNonEmpty;
        }
        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();

        public static ApiOperationSig Empty
        {
            [MethodImpl(Inline)]
            get => new ApiOperationSig(Name.Empty, ApiOperandSig.Empty, Index<ApiOperandSig>.Empty);
        }
    }
}
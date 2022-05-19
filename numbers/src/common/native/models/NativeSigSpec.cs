//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct NativeSigSpec
    {
        public readonly string Scope;

        public readonly string Name;

        public readonly NativeType ReturnType;

        public readonly Index<NativeOperandSpec> Operands;

        [MethodImpl(Inline)]
        public NativeSigSpec(string scope, string name, NativeType ret, params NativeOperandSpec[] ops)
        {
            Scope = scope;
            Name = name;
            ReturnType = ret;
            Operands = ops;
        }

        public ref NativeOperandSpec this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref Operands[i];
        }

        public ref NativeOperandSpec this[int i]
        {
            [MethodImpl(Inline)]
            get => ref Operands[i];
        }

        public string Format()
            => NativeSigs.format(this);

        public string Format(SigFormatStyle style)
            => NativeSigs.format(this, style);

        public override string ToString()
            => Format();

    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static NativeOpMods;

    public readonly struct NativeOperandSpec
    {
        public readonly string Name;

        public readonly NativeType Type;

        public readonly NativeOpMod Mod;

        [MethodImpl(Inline)]
        public NativeOperandSpec(string name, NativeType type, NativeOpMod mod = default)
        {
            Name = name;
            Type = type;
            Mod = mod;
        }

        [MethodImpl(Inline)]
        NativeOperandSpec Modify(NativeOpMod mod)
            => new NativeOperandSpec(Name, Type, mod);

        [MethodImpl(Inline)]
        public NativeOperandSpec ModPointer()
            => Modify(Pointer | Mod);

        [MethodImpl(Inline)]
        public NativeOperandSpec ModOut()
            => Modify(Out | Mod);

        [MethodImpl(Inline)]
        public NativeOperandSpec ModRef()
            => Modify(Ref | Mod);

        [MethodImpl(Inline)]
        public NativeOperandSpec ModIn()
            => Modify(In | Mod);

        [MethodImpl(Inline)]
        public NativeOperandSpec ModConst()
            => Modify(Const | Mod);

        public string Format()
            => NativeRender.format(this);

        public string Format(SigFormatStyle style)
            => NativeRender.format(this, style);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator NativeOperandSpec((string name, NativeType type) src)
            => new NativeOperandSpec(src.name, src.type);

        [MethodImpl(Inline)]
        public static implicit operator NativeOperandSpec((string name, NativeType type, NativeOpMod mod) src)
            => new NativeOperandSpec(src.name, src.type, src.mod);
    }
}


//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct NativeOperandSpec
    {
        [MethodImpl(Inline)]
        public static NativeOperandSpec define(string name, NativeType type)
            => new NativeOperandSpec(name,type);

        [MethodImpl(Inline)]
        public static NativeOperandSpec define(string name, NativeType type, OpMod mod)
            => new NativeOperandSpec(name,type, mod);

        public readonly string Name;

        public readonly NativeType Type;

        public readonly OpMod Mod;

        [MethodImpl(Inline)]
        public NativeOperandSpec(string name, NativeType type, OpMod mod = default)
        {
            Name = name;
            Type = type;
            Mod = mod;
        }

        [MethodImpl(Inline)]
        public NativeOperandSpec Modify(OpMod mod)
            => new NativeOperandSpec(Name, Type, mod);

        [MethodImpl(Inline)]
        public static implicit operator NativeOperandSpec((string name, NativeType type) src)
            => new NativeOperandSpec(src.name, src.type);

        [MethodImpl(Inline)]
        public static implicit operator NativeOperandSpec((string name, NativeType type, OpMod mod) src)
            => new NativeOperandSpec(src.name, src.type, src.mod);
    }
}


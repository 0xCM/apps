//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static NativeOpMods;

    partial class NativeTypes
    {
        [MethodImpl(Inline)]
        public static NativeOperandSpec op(string name, NativeType type)
            => new NativeOperandSpec(name,type);

        [MethodImpl(Inline)]
        public static NativeOperandSpec op(string name, NativeType type, NativeOpMod mod)
            => new NativeOperandSpec(name,type, mod);

        [MethodImpl(Inline), Op]
        public static NativeOperandSpec ptr(string name, NativeType type)
            => op(name,type, Pointer);

        [MethodImpl(Inline), Op]
        public static NativeOperandSpec @const(string name, NativeType type)
            => op(name,type, Const);

        [MethodImpl(Inline), Op]
        public static NativeOperandSpec @constptr(string name, NativeType type)
            => op(name,type, Const | Pointer);

        [MethodImpl(Inline), Op]
        public static NativeOperandSpec @ref(string name, NativeType type)
            => op(name,type, Ref);

        [MethodImpl(Inline), Op]
        public static NativeOperandSpec @in(string name, NativeType type)
            => op(name,type, NativeOpMods.In);

        [MethodImpl(Inline), Op]
        public static NativeOperandSpec @out(string name, NativeType type)
            => op(name,type, NativeOpMods.Out);
    }
}
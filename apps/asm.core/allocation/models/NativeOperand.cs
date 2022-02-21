//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public readonly struct NativeOperand
    {
        public const uint StorageSize = 12;

        public readonly Label Name;

        public readonly NativeType Type;

        public readonly OpMod Mod;

        [MethodImpl(Inline)]
        public NativeOperand(Label name, NativeType type, OpMod mod = default)
        {
            Name = name;
            Type = type;
            Mod = mod;
        }
    }
}


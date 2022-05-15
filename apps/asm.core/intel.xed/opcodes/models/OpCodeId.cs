//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static core;

    using FW = XedModels.OpCodeId.FieldWidth;

    partial struct XedModels
    {
        [StructLayout(StructLayout,Size=4)]
        public readonly record struct OpCodeId : IComparable<OpCodeId>
        {
            public uint Data
            {
                [MethodImpl(Inline)]
                get => u32(this);
            }

            public int CompareTo(OpCodeId src)
                => Data.CompareTo(src.Data);

            public Hash32 Hash
            {
                [MethodImpl(Inline)]
                get => Data;
            }

            public override int GetHashCode()
                => Hash;

            [MethodImpl(Inline)]
            public bool Equals(OpCodeId src)
                => Data == src.Data;

            [MethodImpl(Inline)]
            public static implicit operator uint(OpCodeId src)
                => src.Data;

            [MethodImpl(Inline)]
            public static implicit operator OpCodeId(uint src)
                => @as<uint,OpCodeId>(src);

            public static OpCodeId Empty => default;

            public enum FieldName : byte
            {
                Rep = 0,

                Rex = 1,

                Lock = 2,

                Mod = 3,

                Hex8 = 4,

                Class = 5,
            }

            public enum FieldWidth : byte
            {
                Rep = RepIndicator.Width,

                Rex = BitIndicator.Width,

                Lock = LockIndicator.Width,

                Mod = ModIndicator.Width,

                Hex8 = Z0.Hex8.Width,

                Class = InstClass.Width,
            }

            public enum FieldOffset : byte
            {
                Rep = 0,

                Rex = FW.Rep + Rep,

                Lock = FW.Rex + Rex,

                Mod = FW.Lock + Lock,

                Byte = FW.Mod + Mod,

                Hex8 = FW.Hex8 + Byte,
            }
        }
    }
}
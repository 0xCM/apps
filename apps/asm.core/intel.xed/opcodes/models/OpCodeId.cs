//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using FW = XedModels.OpCodeId.FieldWidth;
    using FO = XedModels.OpCodeId.FieldOffset;
    using FK = XedModels.OpCodeId.FieldKind;

    using static XedRules;
    using static core;

    partial struct XedModels
    {
        public record struct OpCodeId : IComparable<OpCodeId>
        {
            public readonly uint PatternId;

            uint Data;

            [MethodImpl(Inline)]
            internal OpCodeId(ushort pid, uint data)
            {
                PatternId = pid;
                Data = data;
            }

            public InstClass Class
            {
                [MethodImpl(Inline)]
                get => Extract<InstClass>(FK.Class);
            }

            public Hex8 Byte
            {
                [MethodImpl(Inline)]
                get => Extract<Hex8>(FK.Byte);
            }

            public uint2 Lock
            {
                [MethodImpl(Inline)]
                get => Extract<uint2>(FK.Lock);
            }

            public ModIndicator Mod
            {
                [MethodImpl(Inline)]
                get => Extract<ModIndicator>(FK.Mod);
            }

            public int CompareTo(OpCodeId src)
                => Data.CompareTo(src.Data);

            [MethodImpl(Inline)]
            public static implicit operator uint(OpCodeId src)
                => src.Data;

            public static OpCodeId Empty => default;

            [MethodImpl(Inline)]
            public T Extract<T>(FieldKind field)
                where T : unmanaged
                    => core.@as<uint,T>(BitfieldMechanics.extract(Data, skip(Offsets, (byte)field), skip(Widths, (byte)field)));

            public enum FieldKind : byte
            {
                Rep,

                Rex,

                Lock,

                Mod,

                Byte,

                Class,
            }

            public enum FieldWidth : byte
            {
                Rep = RepIndicator.Width,

                Rex = RexBit.Width,

                Lock = LockIndicator.Width,

                Mod = ModIndicator.Width,

                Byte = Hex8.Width,

                Class = InstClass.Width,
            }

            public enum FieldOffset : byte
            {
                Rep = 0,

                Rex = FW.Rep + Rep,

                Lock = FW.Rex + Rex,

                Mod = FW.Lock + Lock,

                Byte = FW.Mod + Mod,

                Class = FW.Byte + Byte,
            }

            const byte FieldCount = 6;

            public static ReadOnlySpan<byte> Widths => new byte[FieldCount]
            {
                (byte)FW.Rep,
                (byte)FW.Rex,
                (byte)FW.Lock,
                (byte)FW.Mod,
                (byte)FW.Byte,
                (byte)FW.Class,
            };

            public static ReadOnlySpan<byte> Offsets => new byte[FieldCount]
            {
                (byte)FO.Rep,
                (byte)FO.Rex,
                (byte)FO.Lock,
                (byte)FO.Mod,
                (byte)FO.Byte,
                (byte)FO.Class,
            };
        }
    }
}
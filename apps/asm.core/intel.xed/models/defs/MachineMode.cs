//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels.ModeClass;
    using static XedModels.ModeKind;
    using static XedModels.Addressing;

    partial struct XedModels
    {
        /// <summary>
        /// Represents the data defined by the xed_state_s structure
        /// </summary>
        /// <remarks>
        /// Comments from XED:
        /// Encapsulates machine modes for decoder/encoder requests.
        /// It specifies the machine operating mode as a xed_machine_mode_enum_t
        /// for decoding and encoding. The machine mode corresponds to the default
        /// data operand width for that mode. For all modes other than the 64b long
        /// mode (<see cref="LONG_64"/>), a default addressing width, and a
        /// stack addressing width must be supplied of type <see cref="Addressing"/>.
        /// </remaks>
        public readonly struct MachineMode : IComparable<MachineMode>, IEquatable<MachineMode>
        {
            public static Addressing addressing(ModeClass src)
                => addressing(kind(src));

            public static Addressing addressing(ModeKind src)
            {
                var dst = Addressing.None;
                switch(src)
                {
                    case LONG_64:
                        dst = w64b;
                    break;
                    case REAL_16:
                    case REAL_32:
                        dst = w32b;
                    break;
                    case LEGACY_32:
                    case LONG_COMPAT_32:
                        dst = w32b;
                    break;
                    case LEGACY_16:
                    case LONG_COMPAT_16:
                        dst = w16b;
                    break;
                }
                return dst;
            }

            public static ModeKind kind(ModeClass src)
            {
                var dst = ModeKind.None;
                switch(src)
                {
                    case Mode16:
                        dst = ModeKind.LONG_COMPAT_16;
                    break;
                    case ModeClass.Default:
                    case Not64:
                    case Mode32:
                        dst = ModeKind.LONG_COMPAT_32;
                    break;
                    case Mode64:
                        dst = ModeKind.LONG_64;
                    break;
                }
                return dst;
            }

            public readonly ModeClass Class;

            [MethodImpl(Inline)]
            public MachineMode(ModeClass mode)
            {
                Class = mode;
            }

            public ModeKind Kind
                => kind(Class);

            public Addressing Addressing
                => addressing(Class);

            [MethodImpl(Inline)]
            public int CompareTo(MachineMode src)
                => XedRules.cmp(Class, src.Class);

            [MethodImpl(Inline)]
            public bool Equals(MachineMode src)
                => Class == src.Class;

            public override int GetHashCode()
                => (byte)Class;

            public override bool Equals(object src)
                => src is MachineMode x && Equals(x);

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator MachineMode(ModeClass src)
                => new MachineMode(src);

            [MethodImpl(Inline)]
            public static implicit operator ModeClass(MachineMode src)
                => src.Class;

            [MethodImpl(Inline)]
            public static explicit operator byte(MachineMode src)
                => (byte)src.Class;

            [MethodImpl(Inline)]
            public static explicit operator MachineMode(byte src)
                => new MachineMode((ModeClass)src);

            [MethodImpl(Inline)]
            public static explicit operator MachineMode(uint3 src)
                => new MachineMode((ModeClass)(byte)src);

            [MethodImpl(Inline)]
            public static explicit operator uint3(MachineMode src)
                => (uint3)(byte)src.Class;

            [MethodImpl(Inline)]
            public static bool operator==(MachineMode a, MachineMode b)
                => a.Equals(b);

            [MethodImpl(Inline)]
            public static bool operator!=(MachineMode a, MachineMode b)
                => !a.Equals(b);

            public static MachineMode Default => new MachineMode(ModeClass.Default);
        }
    }
}
//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        public readonly struct MachineMode : IComparable<MachineMode>, IEquatable<MachineMode>
        {
            public readonly ModeKind Kind;

            [MethodImpl(Inline)]
            public MachineMode(ModeKind mode)
            {
                Kind = mode;
            }

            [MethodImpl(Inline)]
            public int CompareTo(MachineMode src)
                => XedRules.cmp(Kind, src.Kind);

            [MethodImpl(Inline)]
            public bool Equals(MachineMode src)
                => Kind == src.Kind;

            public override int GetHashCode()
                => (byte)Kind;

            public override bool Equals(object src)
                => src is MachineMode x && Equals(x);

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator MachineMode(ModeKind src)
                => new MachineMode(src);

            [MethodImpl(Inline)]
            public static implicit operator ModeKind(MachineMode src)
                => src.Kind;

            [MethodImpl(Inline)]
            public static explicit operator byte(MachineMode src)
                => (byte)src.Kind;

            [MethodImpl(Inline)]
            public static explicit operator MachineMode(byte src)
                => new MachineMode((ModeKind)src);

            [MethodImpl(Inline)]
            public static bool operator==(MachineMode a, MachineMode b)
                => a.Equals(b);

            [MethodImpl(Inline)]
            public static bool operator!=(MachineMode a, MachineMode b)
                => !a.Equals(b);
        }
    }
}
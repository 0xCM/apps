//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    [StructLayout(LayoutKind.Sequential, Size=2)]
    public readonly struct AsmOcToken : IAsmOpCodeToken, IComparable<AsmOcToken>, IEquatable<AsmOcToken>
    {
        public byte Value {get;}

        public AsmOcTokenKind Kind {get;}

        [MethodImpl(Inline)]
        public AsmOcToken(AsmOcTokenKind kind, byte value)
        {
            Value = value;
            Kind = kind;
        }

        [MethodImpl(Inline)]
        public AsmOcToken(ushort src)
        {
            Value = (byte)src;
            Kind = (AsmOcTokenKind)(src >> 8);
        }

        [MethodImpl(Inline)]
        public int CompareTo(AsmOcToken src)
        {
            var result = ((byte)Kind).CompareTo((byte)src.Kind);
            if(result == 0)
                result = Value.CompareTo(src.Value);
            return result;
        }

        [MethodImpl(Inline)]
        public bool Equals(AsmOcToken src)
            => Kind == src.Kind && Value == src.Value;

        public override bool Equals(object src)
            => src is AsmOcToken x && Equals(x);

        public uint Hash
        {
            [MethodImpl(Inline)]
            get => (ushort)this;
        }

        public override int GetHashCode()
            => (int)Hash;
        public string Format()
            => string.Format("{0}[{1}]", Kind, Value);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator ushort(AsmOcToken src)
            => core.bw16(src);

        [MethodImpl(Inline)]
        public static implicit operator AsmOcToken(ushort src)
            => new AsmOcToken(src);
    }
}
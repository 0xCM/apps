//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct BitfieldVar
    {
        readonly text7 BitPattern;

        readonly byte Width;

        byte Value;

        bit Assigned;

        [MethodImpl(Inline)]
        public BitfieldVar(string pattern)
        {
            BitPattern = pattern;
            Width = (byte)pattern.Length;;
            Value = 0;
            Assigned = 0;
        }

        [MethodImpl(Inline)]
        public void Clear()
        {
            Assigned = false;
            Value = 0;
        }

        public bool Defined
        {
            [MethodImpl(Inline)]
            get => Assigned;
        }

        [MethodImpl(Inline)]
        public void Assign(byte value)
        {
            Value = value;
            Assigned = 1;
        }

        [MethodImpl(Inline)]
        public byte Assignment()
            => Value;

        public string Format(bool specifier)
        {
            if(Assigned)
                return (specifier ? "0b" : EmptyString) + Value.FormatBits(BitFormat.limited(Width));
            else
                return BitPattern.Format();
        }

        public string Format()
            => Format(true);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator BitfieldVar(string pattern)
            => new BitfieldVar(pattern);
    }
}
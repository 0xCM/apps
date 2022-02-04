//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static AsmPrefixCodes;

    /// <summary>
    /// Operand size override
    /// </summary>
    public readonly struct OpszPrefix : IAsmPrefix<OpszPrefix>, IAsmByte<OpszPrefix>
    {
        public SizeOverrideCode Code {get;}

        [MethodImpl(Inline)]
        public OpszPrefix(SizeOverrideCode code)
        {
            Code = code;
        }

        [MethodImpl(Inline)]
        public byte Value()
            => (byte)Code;

        public byte Encoded
        {
            [MethodImpl(Inline)]
            get => (byte)Code;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Code == 0;
        }

        public string Format()
            => AsmBytes.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator SizeOverrides(OpszPrefix src)
            =>new SizeOverrides(src.Code !=0, false);

        public static OpszPrefix Empty => default;
    }
}
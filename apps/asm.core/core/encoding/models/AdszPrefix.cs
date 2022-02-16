//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static AsmPrefixCodes;

    /// <summary>
    /// Address size override
    /// </summary>
    public readonly struct AdszPrefix : IAsmPrefix<SizeOverrideCode>, IAsmByte<AdszPrefix>
    {
        public SizeOverrideCode Code {get;}

        [MethodImpl(Inline)]
        public AdszPrefix(SizeOverrideCode code)
        {
            Code = code;
        }

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
            => AsmRender.asmbyte(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator SizeOverrides(AdszPrefix src)
            => new SizeOverrides(false, src.Code !=0);

        public static AdszPrefix Empty => default;
    }
}
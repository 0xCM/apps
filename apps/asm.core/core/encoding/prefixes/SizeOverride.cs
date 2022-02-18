//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;
    using static AsmPrefixCodes;
    using static AsmPrefixCodes.SizeOverrideCode;

    public readonly struct SizeOverride
    {
        public readonly SizeOverrideCode Code;

        [MethodImpl(Inline)]
        public SizeOverride(SizeOverrideCode code)
        {
            Code = code;
        }

        public byte Value()
            => (byte)Code;

        public string Format()
            => Code switch  {
                OPSZ => "66",
                ADSZ => "67",
                _ => "00",
            };

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator SizeOverride(SizeOverrideCode src)
            => new SizeOverride(src);

        [MethodImpl(Inline)]
        public static implicit operator SizeOverrideCode(SizeOverride src)
            => src.Code;
    }

}
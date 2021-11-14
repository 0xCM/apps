//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Runtime.CompilerServices;

    using static Root;
    using static AsmPrefixCodes;

    /// <summary>
    /// Address size override
    /// </summary>
    public readonly struct AdszPrefix : IAsmPrefix<SizeOverrideCode>
    {
        public SizeOverrideCode Code {get;}

        [MethodImpl(Inline)]
        public AdszPrefix(SizeOverrideCode code)
        {
            Code = code;
        }

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

        [MethodImpl(Inline)]
        public static implicit operator SizeOverrides(AdszPrefix src)
            => new SizeOverrides(false, src.Code !=0);

        public static AdszPrefix Empty => default;
    }
}
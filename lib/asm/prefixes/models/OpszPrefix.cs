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
    /// Operand size override
    /// </summary>
    public readonly struct OpszPrefix : IAsmPrefix<OpszPrefix>
    {
        public SizeOverrideCode Code {get;}

        [MethodImpl(Inline)]
        public OpszPrefix(SizeOverrideCode code)
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
        public static implicit operator SizeOverrides(OpszPrefix src)
            =>new SizeOverrides(src.Code !=0, false);

        public static OpszPrefix Empty => default;
    }
}
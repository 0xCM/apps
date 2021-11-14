//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static AsmPrefixCodes;

    public struct EscapePrefix : IAsmPrefix<EscapeCode>
    {
        EscapeCode _Code;

        [MethodImpl(Inline)]
        public EscapePrefix(EscapeCode code)
            => _Code = code;

        public byte Encoded
        {
            [MethodImpl(Inline)]
            get => (byte)_Code;
        }

        [MethodImpl(Inline)]
        public EscapeCode Code()
            => _Code;

        [MethodImpl(Inline)]
        public void Code(EscapeCode src)
            => _Code = src;

        [MethodImpl(Inline)]
        public static implicit operator EscapePrefix(EscapeCode src)
            => new EscapePrefix(src);

        [MethodImpl(Inline)]
        public static implicit operator EscapeCode(EscapePrefix src)
            => src._Code;

        [MethodImpl(Inline)]
        public static implicit operator byte(EscapePrefix src)
            => (byte)src._Code;
    }
}
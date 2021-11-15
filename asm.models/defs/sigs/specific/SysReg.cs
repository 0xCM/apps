//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Runtime.CompilerServices;

    using static Root;

    using K = AsmSigTokenKind;

    partial class AsmSigs
    {
        public readonly struct SysReg
        {
            public SysRegToken Token {get;}

            [MethodImpl(Inline)]
            public SysReg(SysRegToken token)
            {
                Token = token;
            }

            public K Kind => K.SysReg;

            [MethodImpl(Inline)]
            public static implicit operator SysReg(SysRegToken src)
                => new SysReg(src);

            [MethodImpl(Inline)]
            public static implicit operator SysRegToken(SysReg src)
                => src.Token;

            [MethodImpl(Inline)]
            public static implicit operator AsmSigToken(SysReg src)
                => token(src.Kind, src);
        }
    }
}
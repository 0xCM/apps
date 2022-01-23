//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Machines
{
    using System.Runtime.CompilerServices;

    using static Root;

    using Asm;

    public readonly struct X86Cmd
    {
        public AsmHexCode Encoding {get;}

        [MethodImpl(Inline)]
        public X86Cmd(AsmHexCode encoding)
        {
            Encoding = encoding;
        }
    }
}
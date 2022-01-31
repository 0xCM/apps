//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly struct JmpRel32
    {
        readonly byte OpCode;

        public readonly Disp32 Disp;

        [MethodImpl(Inline)]
        public JmpRel32(Disp32 disp)
        {
            OpCode = AsmRel.JmpRel32OpCode;
            Disp = disp;
        }

        public AsmHexCode Encoding
        {
            [MethodImpl(Inline)]
            get => AsmHexCode.load(bytes(this));
        }
    }
}
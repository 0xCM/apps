//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly struct JmpRel8
    {
        readonly byte OpCode;

        public readonly Disp8 Disp;

        [MethodImpl(Inline)]
        public JmpRel8(Disp8 disp)
        {
            OpCode = AsmRel.JmpRel8OpCode;
            Disp = disp;
        }

        public AsmHexCode Encoding
        {
            [MethodImpl(Inline)]
            get => AsmHexCode.load(bytes(this));
        }
    }
}
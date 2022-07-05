//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct JmpStub
    {
        readonly byte OpCode;

        readonly int DispData;

        readonly byte SizeData;

        public readonly MemoryAddress Source;

        public readonly MemoryAddress Target;

        [MethodImpl(Inline)]
        internal JmpStub(byte opcode, int disp, byte size, MemoryAddress src, MemoryAddress dst)
        {
            OpCode = opcode;
            DispData = disp;
            SizeData = size;
            Source = src;
            Target = dst;
        }

        // [MethodImpl(Inline)]
        // public JmpStub(MemoryAddress src, MemoryAddress dst, bool rel32 = true)
        // {
        //     OpCode = rel32 ? JmpRel32.OpCode : JmpRel8.InstSize;
        //     DispData = rel32 ? (int)AsmRel.disp32((src,  JmpRel32.InstSize),dst) : (sbyte)AsmRel.disp8((src,JmpRel8.InstSize) ,dst);
        //     SizeData = rel32 ? JmpRel32.InstSize : JmpRel8.InstSize;
        //     Source = src;
        //     Target = dst;
        // }

        public Disp32 Disp
        {
            [MethodImpl(Inline)]
            get => DispData;
        }

        public ByteSize Size
        {
            [MethodImpl(Inline)]
            get => SizeData;
        }

        public AsmHexCode Encoding
        {
            [MethodImpl(Inline)]
            get => JmpRel32.encode((Source, JmpRel32.InstSize), Target);
        }
    }
}
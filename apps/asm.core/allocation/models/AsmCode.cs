//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct AsmCode
    {
        public readonly SourceText Asm;

        public readonly MemoryAddress IP;

        public readonly AsmHexRef Encoded;

        [MethodImpl(Inline)]
        public AsmCode(SourceText asm, MemoryAddress loc, AsmHexRef code)
        {
            IP = loc;
            Asm = asm;
            Encoded = code;
        }

        public byte EncodingSize
        {
            [MethodImpl(Inline)]
            get => Encoded.Size;
        }

        public ReadOnlySpan<byte> Encoding
        {
            [MethodImpl(Inline)]
            get => Encoded.View;
        }

        public string Format()
        {
            var dst = text.buffer();
            dst.AppendFormat("{0,-8}", IP);
            dst.AppendFormat("{0,-80}", Asm);
            dst.AppendFormat("# {0}", Encoded.Format());
            return dst.Emit();
        }


        public override string ToString()
            => Format();

        public static AsmCode Empty => default;
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct AsmSpec
    {
        internal static string format(in AsmSpec src)
        {
            var dst = text.buffer();
            ref readonly var ops = ref src.Operands;
            var count = ops.OpCount;
            dst.Append(src.Mnemonic.Format(MnemonicCase.Lowercase));
            if(count != 0)
            {
                dst.Append(Chars.Space);
                dst.Append(src.Operands.Format());
            }
            return dst.Emit();
        }

        public AsmMnemonic Mnemonic;

        public AsmOpCode OpCode;

        public AsmOperands Operands;

        public static AsmSpec Empty => default;

        public string Format()
            => format(this);

        public override string ToString()
            => Format();
    }
}
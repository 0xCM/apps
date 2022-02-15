//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct AsmOperands
    {
        public byte OpCount;

        public AsmOperand Op0;

        public AsmOperand Op1;

        public AsmOperand Op2;

        public AsmOperand Op3;

        public string Format()
        {
            var dst = EmptyString;
            switch(OpCount)
            {
                case 0:
                break;
                case 1:
                   dst = string.Format("{0}", Op0);
                break;
                case 2:
                    dst = string.Format("{0}, {1}", Op0, Op1);
                break;
                case 3:
                    dst = string.Format("{0}, {1}, {2}", Op0, Op1, Op2);
                break;
                case 4:
                    dst = string.Format("{0}, {1}, {2}, {3}", Op0, Op1, Op2, Op3);
                break;
            }
            return dst;
        }

        public override string ToString()
            => Format();

        public static AsmOperands Empty => default;
    }
}
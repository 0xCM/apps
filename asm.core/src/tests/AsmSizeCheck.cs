//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct AsmSizeCheck : IAsmCheck<AsmSizeCheck,NativeSize,BitWidth>
    {
        public NativeSize Input;

        public ushort Expect;

        public ushort Actual;

        public bit Passed
        {
            [MethodImpl(Inline)]
            get => Expect == Actual;
        }

        public string Format()
        {
            const string Pattern = "{0} | Input={1,-16} | Expect={2,-16} | Actual={3,-16} | {4}";
            return string.Format(Pattern, nameof(AsmSizeCheck),
                Input, Expect, Actual, Passed ? "Pass" : "Fail");
        }

        public override string ToString()
            => Format();

        NativeSize IAsmCheck<AsmSizeCheck, NativeSize, BitWidth>.Input
            => Input;

        BitWidth IAsmCheck<AsmSizeCheck, NativeSize, BitWidth>.Expect
            => Expect;

        BitWidth IAsmCheck<AsmSizeCheck, NativeSize, BitWidth>.Actual
            => Actual;
    }
}
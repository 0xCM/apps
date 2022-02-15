//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using Operands;

    [ApiHost]
    public readonly struct AsmSpecs
    {
        const NumericKind Closure = UnsignedInts;


        // and r32, imm32 | 81 /4 id
        [MethodImpl(Inline), Op]
        public static AsmSpec and(r32 a, imm32 b)
            => asm.spec("and", AsmOpCode.Empty, a, b);
   }
}
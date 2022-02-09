//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial struct AsmRegs
    {
        /// <summary>
        /// Defines a query source over a specified operand sequence
        /// </summary>
        /// <param name="src"></param>
        [Op]
        public static AsmRegQuery query(ReadOnlySpan<RegOp> src)
            => new AsmRegQuery(src);
    }
}

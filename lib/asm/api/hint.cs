//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static AsmPrefixCodes;

    partial struct asm
    {
        [MethodImpl(Inline), Op]
        public static BranchHintPrefix hint(bit taken)
            => taken ? BranchHintCode.BT : BranchHintCode.BNT;
    }
}
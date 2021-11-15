//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System.Runtime.CompilerServices;

    using static Root;

    [ApiComplete]
    public readonly struct Strings
    {
        public static MemoryStrings<ushort> OpCodes
        {
            [MethodImpl(Inline)]
            get => strings.memory<ushort>(stringtables.Instruction.Offsets, stringtables.Instruction.Data);
        }
    }
}
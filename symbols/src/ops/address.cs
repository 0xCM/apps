//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Symbolic
    {
        [MethodImpl(Inline), Op]
        public static SymAddress address(uint selector, MemoryAddress address)
            => new SymAddress(selector, address);

        [MethodImpl(Inline), Op]
        public static SymAddress address(MemoryAddress address)
            => new SymAddress(0, address);
    }
}
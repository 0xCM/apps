//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class Symbolic
    {
        [MethodImpl(Inline), Op]
        public static LocatedSymbol located(MemoryAddress location, Label name)
            => new LocatedSymbol(address(location),name);

        [MethodImpl(Inline), Op]
        public static LocatedSymbol located(uint selector, MemoryAddress location, Label name)
            => new LocatedSymbol(address(selector,location), name);

        [MethodImpl(Inline), Op]
        public static LocatedSymbol located(SymAddress location, Label name)
            => new LocatedSymbol(location, name);
    }
}
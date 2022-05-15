//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct strings
    {
        [MethodImpl(Inline), Op]
        public static STRes table(uint entries, uint chars, MemoryAddress charbase, MemoryAddress offsetbase, MemoryStrings strings)
            => new STRes(entries,chars,charbase,offsetbase,strings);

        [MethodImpl(Inline), Op]
        public static STRes<K> table<K>(uint entries, uint chars, MemoryAddress charbase, MemoryAddress offsetbase, MemoryStrings strings)
            where K : unmanaged
                => new STRes<K>(entries,chars,charbase,offsetbase,strings);
    }
}
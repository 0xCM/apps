//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Literals
    {
        [MethodImpl(Inline), Op]
        public static LiteralProvider provider(string name, Type def)
            => new LiteralProvider(name, def);

        [MethodImpl(Inline), Op]
        public static LiteralProvider provider(Type def)
            => new LiteralProvider(def.Name, def);
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedDisasm
    {
        [MethodImpl(Inline)]
        public static DisasmBlock block(TextLine[] src)
            => new DisasmBlock(src);
    }
}
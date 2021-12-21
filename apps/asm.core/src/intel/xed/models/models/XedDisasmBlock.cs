//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    public struct XedDisasmBlock
    {
        public Index<TextLine> Lines;

        [MethodImpl(Inline)]
        public XedDisasmBlock(TextLine[] src)
        {
            Lines = src;
        }

        [MethodImpl(Inline)]
        public static implicit operator XedDisasmBlock(TextLine[] src)
            => new XedDisasmBlock(src);
    }
}
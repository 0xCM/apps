//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class IntelIntrinsics
    {
        public struct Operation
        {
            public const string ElementName = "operation";

            public List<TextLine> Content;

            [MethodImpl(Inline)]
            public Operation(List<TextLine> src)
            {
                Content = src;
            }
        }
    }
}
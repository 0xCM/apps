//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedModels;

    public partial class XedDisasm
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public struct XDis
        {
            public AsmHexCode Encoded;

            public MemoryAddress IP;

            public CategoryKind Category;

            public ExtensionKind Extension;

            public asci64 Asm;
        }
    }
}
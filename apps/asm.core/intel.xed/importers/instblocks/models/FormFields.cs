//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class XedImport
    {
        [StructLayout(LayoutKind.Sequential,Pack=1), Record(TableId)]
        public struct FormFields
        {
            const string TableId = "xed.instblocks.fields";

            [Render(6)]
            public uint Seq;

            [Render(12)]
            public uint MinLine;

            [Render(12)]
            public uint MaxLine;

            [Render(12)]
            public uint MinChar;

            [Render(12)]
            public uint MaxChar;

            [Render(8)]
            public uint Lines;

            [Render(64)]
            public InstForm Form;

            [Render(1)]
            public BitVector64<BlockField> Fields;

            public static FormFields Empty => default;
        }
    }
}
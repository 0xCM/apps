//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class XedImport
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public struct FormFields
        {
            public InstForm Form;

            public BitVector64<BlockField> Fields;

            public LineNumber MinLine;

            public LineNumber MaxLine;

            public string Format()
                => string.Format("{0,-64}: {1}", Form, Fields);

            public override string ToString()
                => Format();

            public static FormFields Empty => default;
        }
    }
}
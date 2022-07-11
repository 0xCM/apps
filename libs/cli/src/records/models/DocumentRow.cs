//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct CliRows
    {
        [Record(TableId), StructLayout(LayoutKind.Sequential)]
        public struct DocumentRow
        {
            const string TableId = "documents";

            [Render(12)]
            public CliBlobIndex Name;

            [Render(12)]
            public GuidIndex HashAlgorithm;

            [Render(12)]
            public CliBlobIndex Hash;

            [Render(12)]
            public GuidIndex Language;
        }
    }
}
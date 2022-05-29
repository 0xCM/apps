//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct CliRows
    {
        [Record(TableId), StructLayout(LayoutKind.Sequential)]
        public struct DocumentRow : ICliRecord<DocumentRow>
        {
            public const string TableId = "cli.metadata.document";

            public CliBlobIndex Name;

            public GuidIndex HashAlgorithm;

            public CliBlobIndex Hash;

            public GuidIndex Language;
        }
    }
}
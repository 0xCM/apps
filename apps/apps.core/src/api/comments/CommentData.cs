//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class ApiCommentDataset
    {
        public readonly SortedLookup<FS.FilePath,TargetXml> TargetXmlLookup;

        public readonly SortedLookup<FS.FilePath,TargetComments> TargetCommentLookup;

        public readonly SortedLookup<FS.FilePath,Index<ApiComment>> CsvRowLookup;

        public readonly Index<TargetComments> Comments;

        public readonly Index<TargetXml> Xml;
    }
}
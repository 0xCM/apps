//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ApiComments
    {
        public partial class CommentDataset
        {
            public readonly SortedLookup<FS.FilePath,TargetXml> TargetXmlLookup;

            public readonly SortedLookup<FS.FilePath,TargetComments> TargetCommentLookup;

            public readonly SortedLookup<FS.FilePath,Index<ApiComment>> CsvRowLookup;

            public readonly Index<TargetComments> Comments;

            public readonly Index<TargetXml> Xml;

            public FS.Files XmlSources;

            public readonly FS.Files Sources;

            public CommentDataset(
                    Dictionary<FS.FilePath, Dictionary<string,string>> xml,
                    Dictionary<FS.FilePath, Dictionary<string,ApiComment>> comments,
                    Dictionary<FS.FilePath, List<ApiComment>> csvFormat,
                    FS.Files dlls
                    )
            {
                TargetXmlLookup = xml.Map(x => (x.Key, TargetXml.create(x.Key, x.Value))).ToDictionary();
                TargetCommentLookup = comments.Map(x => (x.Key, TargetComments.create(x.Key, x.Value))).ToDictionary();
                Comments = TargetCommentLookup.Values.ToArray();
                Xml = TargetXmlLookup.Values.ToArray();
                XmlSources = xml.Keys.Array().Sort();
                CsvRowLookup = csvFormat.Map(x => (x.Key, x.Value.Index())).ToDictionary();
                Sources = dlls;
            }

            public PartComments FindComments(FS.FolderPath dir, PartId part)
            {
                var dst = new PartComments();
                dst.Part = part;
                dst.CsvPath = CsvPath(dir,part);
                dst.XmlPath = XmlPath(dir,part);
                return dst;
            }

        }
    }
}
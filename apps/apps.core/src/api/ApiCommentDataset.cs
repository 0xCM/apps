//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ApiCommentDataset
    {
        public readonly Dictionary<FS.FilePath, Dictionary<string,string>> Xml;

        public readonly Dictionary<FS.FilePath, Dictionary<string,ApiComment>> Comments;

        public readonly Dictionary<FS.FilePath, List<string>> Csv;

        public ApiCommentDataset(
                Dictionary<FS.FilePath, Dictionary<string,string>> xml,
                Dictionary<FS.FilePath, Dictionary<string,ApiComment>> comments,
                Dictionary<FS.FilePath, List<string>> csv
                )
        {
            Xml = xml;
            Comments = comments;
            Csv = csv;
        }
    }
}
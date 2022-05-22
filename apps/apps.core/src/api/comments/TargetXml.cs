//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class ApiCommentDataset
    {
        public class TargetXml : Dictionary<string,string>
        {
            public static TargetXml create(FS.FilePath path, Dictionary<string,string> src)
                => new(path,src);

            public readonly FS.FilePath Path;

            public TargetXml(FS.FilePath path, Dictionary<string,string> src)
                : base(src)
            {
                Path = path;
            }
        }
    }
}
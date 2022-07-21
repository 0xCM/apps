//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BuildSvc
    {
        public record class Solution
        {
            public const string TableId = "sln";

            public SlnFile Path;

            public IndexedSeq<SlnProject> Projects;
        }
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class MsBuild
    {
        [Record(TableId)]
        public struct Solution
        {
            public const string TableId = "sln";

            public SlnFile Path;

            public IndexedSeq<SlnProject> Projects;
        }
    }
}
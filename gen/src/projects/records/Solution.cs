//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId)]
    public struct Solution : IRecord<Solution>
    {
        public const string TableId = "sln";

        public SlnFile Path;

        public IndexedSeq<SlnProject> Projects;
    }
}
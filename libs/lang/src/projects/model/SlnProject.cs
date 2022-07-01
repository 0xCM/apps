//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class MsProjects
    {
        [Record(TableId)]
        public struct SlnProject
        {
            public const string TableId = "sln.project";

            public FS.FilePath Path;

            public NameOld ProjectName;

            public Guid ProjectGuid;

            public Index<Guid> Dependencies;

            public Index<SlnProjectConfig> Configurations;
        }
    }
}
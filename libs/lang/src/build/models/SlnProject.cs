//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BuildSvc
    {
        public record class SlnProject
        {
            public FS.FilePath Path;

            public string ProjectName;

            public Guid ProjectGuid;

            public Seq<Guid> Dependencies;

            public Seq<SlnProjectConfig> Configurations;
        }
    }
}
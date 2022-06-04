//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    [Record(TableId)]
    public struct SlnProject : IRecord<SlnProject>
    {
        public const string TableId = "sln.project";

        public FS.FilePath Path;

        public Name ProjectName;

        public Guid ProjectGuid;

        public Index<Guid> Dependencies;

        public Index<SlnProjectConfig> Configurations;
    }
}
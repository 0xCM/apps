//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId)]
    public struct SlnProjectConfig : IRecord<SlnProjectConfig>
    {
        public const string TableId = "sln.project-config";

        public Identifier SimpleName;

        public Identifier Platform;

        public Identifier FullName;

        public bool Build;
    }
}
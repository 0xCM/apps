//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [LiteralProvider]
    public readonly struct DbNames
    {
        public const string DbSources = nameof(DbSources);

        public const string DbTargets = nameof(DbTargets);

        public const string DbProjects = nameof(DbProjects);

        public const string DbCapture = nameof(DbCapture);

        public const string Control = nameof(Control);

        public const string EnvConfig = nameof(EnvConfig);

        public const string CgRoot = nameof(CgRoot);

        public const string DevRoot = nameof(DevRoot);

        public const string Toolbase = nameof(Toolbase);
    }
}
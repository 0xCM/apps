//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [LiteralProvider]
    public readonly struct ArchiveNames
    {
        public const string DbSources = nameof(DbSources);

        public const string DbTargets = nameof(DbTargets);

        public const string DbProjects = nameof(DbProjects);

        public const string Capture = nameof(Capture);

        public const string Control = nameof(Control);

        public const string EnvConfig = nameof(EnvConfig);

        public const string CodeGen = nameof(CodeGen);

        public const string Dev = nameof(Dev);
    }
}
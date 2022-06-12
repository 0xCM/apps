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

        public const string ProjectEtl = nameof(ProjectEtl);

        public const string ProjectSrc = nameof(ProjectSrc);

        public const string Capture = nameof(Capture);

        public const string Control = nameof(Control);

        // public const string CodeGen = nameof(CodeGen);

        // public const string Dev = nameof(Dev);

        // public const string Deployments = nameof(Deployments);

        // public const string LlvmRoot = nameof(LlvmRoot);

        // public const string Toolbase = nameof(Toolbase);

        // public const string XedRoot = nameof(XedRoot);
    }
}
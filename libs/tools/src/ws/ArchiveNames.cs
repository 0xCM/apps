//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [LiteralProvider]
    public readonly struct ArchiveNames
    {
        public const string Capture = nameof(Capture);

        public const string Control = nameof(Control);

        public const string CodeGen = nameof(CodeGen);

        public const string Dev = nameof(Dev);

        public const string Deployments = nameof(Deployments);

        public const string ProjectData = nameof(ProjectData);

        public const string Projects = nameof(Projects);

        public const string LlvmRoot = nameof(LlvmRoot);

        public const string Sources = nameof(Sources);

        public const string Targets = nameof(Targets);

        public const string Toolbase = nameof(Toolbase);

        public const string XedRoot = nameof(XedRoot);
    }
}
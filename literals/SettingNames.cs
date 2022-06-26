//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ApiGranules;

    [LiteralProvider(env)]
    public readonly struct SettingNames
    {
        public const string LlvmVer = nameof(LlvmVer);

        public const string WinSdkVer = nameof(WinSdkVer);

        public const string DbRoot = nameof(DbRoot);

        public const string DbSources = nameof(DbSources);

        public const string DbTargets = nameof(DbTargets);

        public const string DbProjects = nameof(DbProjects);

        public const string DbCapture = nameof(DbCapture);

        public const string Control = nameof(Control);

        public const string EnvConfig = nameof(EnvConfig);

        public const string CgRoot = nameof(CgRoot);

        public const string LlvmRoot = nameof(LlvmRoot);

        public const string DevRoot = nameof(DevRoot);

        public const string Toolbase = nameof(Toolbase);

        public const string RepoDeps = nameof(RepoDeps);

        public const string Tools = nameof(Tools);

        public const string Views = nameof(Views);

        public const string Logs = nameof(Logs);

        public const string VsRoot = nameof(VsRoot);

        public const string LlvmDist = nameof(LlvmDist);

        public const string Msvc = nameof(Msvc);

        public const string WinSdk = nameof(WinSdk);

        public const string XedRoot = nameof(XedRoot);
    }
}
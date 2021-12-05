//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [LiteralProvider]
    public readonly struct ProjectScriptNames
    {
        public const string LlcBuild = "llc-build";

        public const string LlcBuildSse = "llc-build-sse";

        public const string LlcBuildSse2 = "llc-build-sse2";

        public const string LlcBuildSse3 = "llc-build-sse3";

        public const string LlcBuildSse41 = "llc-build-sse41";

        public const string LlcBuildSse42 = "llc-build-sse42";

        public const string LlcBuildAvx = "llc-build-avx";

        public const string LlcBuildAvx2 = "llc-build-avx2";

        public const string LlcBuildAvx512 = "llc-build-avx512";

        public const string CBuild = "c-build";

        public const string CRun = "c-run";

        public const string CppBuild = "cpp-build";

        public const string CppRun = "cpp-run";

        public const string McBuild = "mc-build";

        public const string MlBuild = "ml-build";

        public const string McHex = "mc-hex";

        public const string McDisasm = "mc-disasm";

        public const string DumpLayouts = "dump-layouts";

        public const string DumpAst = "dump-ast";

        public const string Build = "build";
    }
}
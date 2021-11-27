//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct CmdEnvCalcs
    {
        readonly CmdEnv Env;

        readonly string IncludeFlag;

        [MethodImpl(Inline)]
        public CmdEnvCalcs(CmdEnv env)
        {
            Env = env;
            IncludeFlag = "-I";
        }

        string IncludeOption(FS.FolderPath src)
            => string.Format("{0} \"{1}\"", IncludeFlag, src.Format());

        FS.FolderName X64Folder
            => FS.folder("x64");

        FS.FolderName WinSdkVerFolder
            => FS.folder(Env.Versions.WinSdk.Format());

        public FS.FolderPath WinSdkDir
            => Env.RootPaths.WinSdk + FS.folder(Env.Versions.WinSdk.A.ToString());

        public FS.FolderPath NetFxDir
            => Env.RootPaths.WinSdk + FS.folder("NETFXSDK");

        public FS.FolderPath WinSdkIncludeDir
            => WinSdkDir + FS.folder("include") + WinSdkVerFolder;

        public string WinSdkInclude
            => IncludeOption(WinSdkIncludeDir);

        public FS.FolderPath WinSdkShareIncludeDir
            => WinSdkIncludeDir + FS.folder("shared");

        public string WinSdkShareInclude
            => IncludeOption(WinSdkShareIncludeDir);

        public FS.FolderPath UcrtIncludeDir
            => WinSdkIncludeDir + FS.folder("ucrt");

        public string UcrtInclude
            => IncludeOption(UcrtIncludeDir);

        public FS.FolderPath UmIncludeDir
            => WinSdkIncludeDir + FS.folder("um");

        public string UmInclude
            => IncludeOption(UmIncludeDir);

        public FS.FolderPath WinRtIncludeDir
            => WinSdkIncludeDir + FS.folder("winrt");

        public string WinRtInclude
            => IncludeOption(WinRtIncludeDir);

        public FS.FolderPath CppWinRtIncludeDir
            => WinSdkIncludeDir + FS.folder("cppwinrt");

        public string CppWinRtInclude
            => IncludeOption(CppWinRtIncludeDir);

        public FS.FolderPath WinSdkBinDir
            => WinSdkDir + FS.folder("bin") + WinSdkVerFolder;

        public FS.FolderPath WinSdkDebuggerDir
            => WinSdkDir + FS.folder("debuggers") + X64Folder;

        public FS.FolderPath WinSdkToolDir
            => WinSdkDir + FS.folder("tools") + X64Folder;

        public FS.FolderPath WinSdkLibDir
            => WinSdkDir + FS.folder("lib") + WinSdkVerFolder;

        public FS.FolderPath UcrtLibDir
            => WinSdkLibDir + FS.folder("ucrt") + X64Folder;

        public FS.FolderPath UmLibDir
            => WinSdkLibDir + FS.folder("um") + X64Folder;
    }
}
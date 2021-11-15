//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    partial class DumpBin
    {
        public readonly struct Scripts
        {
            public static ToolScript DumpObj(FS.FolderPath SrcDir, FS.FileName SrcFile, FS.FolderPath DstDir)
            {
                const string ScriptId = "dump-obj";
                var result = Outcome.Success;
                return Cmd.toolscript(Toolspace.dumpbin, ScriptId, vars(SrcDir,SrcFile,DstDir));
            }

            public static ToolScript DumpDll(FS.FolderPath SrcDir, FS.FileName SrcFile, FS.FolderPath DstDir)
            {
                const string ScriptId = "dump-dll";
                var result = Outcome.Success;
                return Cmd.toolscript(Toolspace.dumpbin, ScriptId, vars(SrcDir,SrcFile,DstDir));
            }

            public static ToolScript DumpExe(FS.FolderPath SrcDir, FS.FileName SrcFile, FS.FolderPath DstDir)
            {
                const string ScriptId = "dump-exe";
                var result = Outcome.Success;
                return Cmd.toolscript(Toolspace.dumpbin, ScriptId, vars(SrcDir,SrcFile,DstDir));
            }

            public static ToolScript DumpLib(FS.FolderPath SrcDir, FS.FileName SrcFile, FS.FolderPath DstDir)
            {
                const string ScriptId = "dump-lib";
                var result = Outcome.Success;
                return Cmd.toolscript(Toolspace.dumpbin, ScriptId, vars(SrcDir,SrcFile,DstDir));
            }

            static CmdVars vars(FS.FolderPath SrcDir, FS.FileName SrcFile, FS.FolderPath DstDir)
                => Cmd.vars(
                    ("SrcDir", SrcDir.Format(PathSeparator.BS)),
                    ("SrcFile", SrcFile.Format()),
                    ("DstDir", DstDir.Format(PathSeparator.BS))
                    );
        }
    }
}
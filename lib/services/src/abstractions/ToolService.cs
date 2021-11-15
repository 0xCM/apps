//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public abstract class ToolService<T> : AppService<T>
        where T : ToolService<T>, new()
    {
        public virtual ToolId Id {get;}

        ScriptRunner ScriptRunner;

        CmdLineRunner CmdRunner;

        protected ToolService(ToolId id)
        {
            Id = id;
        }

        protected ToolService()
        {

        }

        protected override void OnInit()
        {
            base.OnInit();
            ScriptRunner = Wf.ScriptRunner();
            CmdRunner = Wf.CmdLineRunner();
        }

        void ReceiveCmdStatus(in string src)
        {

        }

        void ReceiveCmdError(in string src)
        {
            Error(src);
        }

        protected void DisplayResponse(ReadOnlySpan<TextLine> src)
        {
            var count = src.Length;
            if(count == 0)
                Warn("No response to parse");

            for(var i=0; i<count; i++)
            {
                if(CmdResponse.parse(skip(src,i).Content, out var response))
                    Write(response);
            }
        }

        protected Outcome Run(CmdLine cmd, CmdVars vars, out ReadOnlySpan<TextLine> response)
            => ScriptRunner.RunCmd(cmd, vars, ReceiveCmdStatus, ReceiveCmdError, out response);

        protected Outcome Run(ToolScript spec, out ReadOnlySpan<TextLine> response)
            => ScriptRunner.RunCmd(spec, ReceiveCmdStatus, ReceiveCmdError, out response);

        protected Outcome RunWinCmd(string spec, out ReadOnlySpan<TextLine> response)
            => CmdRunner.Run(WinCmd.cmd(spec), out response);

        protected Outcome RunScript(FS.FilePath src, out ReadOnlySpan<TextLine> response)
        {
            var result = Outcome.Success;

            void OnError(Exception e)
            {
                result = e;
                Error(e);
            }

            var cmd = Cmd.cmdline(src.Format(PathSeparator.BS));
            response = ScriptRunner.RunCmd(cmd, OnError);
            return result;
        }

        protected FS.FolderPath Home
            => Db.DevWs() + FS.folder("tools") + FS.folder(Id.Format());

        public FS.FolderPath OutDir
            => Paths.ToolOutDir(Id);

        public FS.FilePath Script(FS.FolderPath dir, FS.FileName name)
            => dir + name;

        public FS.FilePath Output(FS.FileName name)
            => OutDir + name;

        public virtual FS.FilePath ToolPath()
            => FS.path(string.Format("{0}.{1}", Id.Format(), FS.Exe));

        protected static string format(FS.FilePath src)
            => src.Format(PathSeparator.BS);

        protected static FS.FilePath input(FS.FolderPath dir, FS.FileName name)
            => dir + name;

        protected static FS.FilePath output(FS.FolderPath dir, FS.FileName name)
            => dir + name;

        protected static FS.FileName file(Identifier src, FS.FileExt ext)
            => FS.file(src.Format(), ext);

        protected static FS.FileName binfile(Identifier src)
            => file(src, FS.Bin);

        protected FS.FileName ToolFile(Identifier id,  Identifier discriminator, FS.FileExt ext)
            => FS.file(string.Format("{0}.{1}.{2}", id, Id, discriminator), ext);
    }
}
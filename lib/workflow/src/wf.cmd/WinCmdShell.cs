//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class WinCmdShell : Interpreter<WinCmdShell>
    {
        protected override FS.FilePath ExePath
            => FS.file("cmd", FS.Exe).ToPath();

        // public override void SubmitStop()
        //     => exit();

        // public void exit()
        //     => Submit(nameof(exit));

        public void echo(string msg)
            => Submit(string.Format("{0} {1}", nameof(echo), msg));
    }
}
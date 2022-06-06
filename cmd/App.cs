//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    sealed class AppCmdShell : AppCmdShell<AppCmdShell>
    {
        public static void Main(params string[] args)
            => run(wf => GlobalCmd.commands(wf), args);
    }
}
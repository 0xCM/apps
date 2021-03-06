//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    sealed class App : AppCmdShell<App>
    {
        public static void Main(int a = 4, int b = 5)
            => run(wf => AppCmd.create(wf), sys.empty<string>());
    }
}
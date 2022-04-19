//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [CmdProvider]
    public abstract class AppCmdProvider<T> : AppService<T>, ICmdProvider
        where T : AppCmdProvider<T>, new()
    {
    }
}
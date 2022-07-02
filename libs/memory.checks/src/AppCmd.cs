//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ApiGranules;

    sealed class AppCmd : AppCmdService<AppCmd>
    {
        [CmdOp("mem/check")]
        void Hello()
        {

        }
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    sealed class AppCmd : AppCmdService<AppCmd>
    {

        [CmdOp("Ws/check")]
        void Hello()
        {

        }
    }
}
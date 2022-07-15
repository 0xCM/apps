//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    public class RuntimeCmd : AppCmdService<RuntimeCmd>
    {
        Runtime Runtime => Wf.Runtime();


        [CmdOp("runtime/emit/context")]
        void EmitContext()
            => Runtime.EmitContext(AppDb.apipack());

    }
}

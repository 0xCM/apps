//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class ProjectCmd
    {
        Runtime RuntimeServices => Wf.Runtime();

        [CmdOp("memory/dump")]
        void EmitDump()
            => RuntimeServices.EmitContext(timestamp());

    }
}
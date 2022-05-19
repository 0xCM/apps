//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    public sealed partial class CheckRunCmd : AppCmdService<CheckRunCmd,CmdShellState>
    {
        protected override void Initialized()
        {
            State.Init(Wf, Ws);
            CheckServices = Checkers.discover(Wf, ApiRuntimeCatalog.Components);
        }

        ConstLookup<Identifier,ICheckService> CheckServices;
    }
}
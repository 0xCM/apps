//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    public partial class GlobalCommands : AppCmdService<GlobalCommands,CmdShellState>
    {
        public GlobalCommands()
        {
        }

        protected override ICmdProvider[] CmdProviders(IWfRuntime wf)
            => array<ICmdProvider>(this, wf.XedCommands(), wf.ApiCommands(), wf.LlvmCommands(), wf.ProjectCommands());

        IntelXed Xed => Service(Wf.IntelXed);

        IntelSdm Sdm => Service(Wf.IntelSdm);

        [CmdOp("asm-gen-models")]
        protected Outcome GenAsmModels(CmdArgs args)
        {
            var dst = Service(Wf.Generators).CodeGenDir("asm.models");
            return true;
        }
    }
}
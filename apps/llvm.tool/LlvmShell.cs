//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    using clang;

    [Free]
    sealed class LlvmShell : WfApp<LlvmShell>, IToolCmdShell
    {
        IAppCmdService ToolService;

        IAppCmdService CmdService;

        protected override void Initialized()
        {
            CmdService = LlvmCmd.create(Wf);
        }

        void Select(string tool)
        {
            var result = SelectTool(tool);
            if(result.Fail)
                Error(result.Message);
            else
                Status(string.Format("Selected {0}", tool));
        }

        public Outcome SelectTool(ToolId tool)
        {
            var next = default(IAppCmdService);
            switch(tool)
            {
                case LlvmNames.Tools.clang_query:
                    next = ClangQuery.create(Wf).With(this);
                    break;
            }

            if(next != null)
            {
                ToolService?.Dispose();
                ToolService = next;
            }
            return ToolService != null ? true : (false, string.Format("Tool {0} unknown", tool));
        }

        protected override void Disposing()
        {
            ToolService?.Dispose();
            CmdService?.Dispose();
        }

        protected override void Run()
            => CmdService.Run();

        public static void Main(params string[] args)
        {
            using var wf = WfAppLoader.load();
            using var shell = create(wf);
            shell.Run();
        }
    }
}
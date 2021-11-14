//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    public abstract class LlvmTool<T> : AppCmdService<T, CmdShellState>
        where T : LlvmTool<T>,new()
    {
        protected ILlvmWorkspace LlvmWs;

        protected LlvmTool()
        {
            Id = typeof(T).Tag<ToolAttribute>().Require().Id;
            ToolPath = FS.FilePath.Empty;
            Initializer = () => {};
        }

        protected virtual Action Initializer {get;}

        protected override void Initialized()
        {
            LlvmWs = Wf.LlvmWs();
            ToolPath = LlvmWs.Bin() + FS.file(Id.Format(), FS.Exe);

            if(ToolPath.Exists)
                Status(string.Format("Initialized {0} deployed to {1}", Id, ToolPath.ToUri()));
            else
                Error(string.Format("The {0} tool does not exist at {1}", Id, ToolPath.ToUri()));

            Initializer();
        }

        protected override string PromptTitle
            => Id;

        /// <summary>
        /// The tool id
        /// </summary>
        public ToolId Id {get;}

        /// <summary>
        /// The tool path
        /// </summary>
        public FS.FilePath ToolPath {get; private set;}
    }
}
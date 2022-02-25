//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    partial class ProjectDataServices
    {
        public void CollectMc(WsContext context)
        {
            var result = Outcome.Success;
            var project = context.Project;
            var syntax = CollectAsmSyntax(context);
            var encodings = CollectAsmEncodings(context);
            var instructions = CollectMcInstructions(context);
        }
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Tools
{
    using static Root;

    [ApiHost]
    public sealed partial class Robocopy : AppService<Robocopy>
    {
        public ToolId Id => Toolspace.nasm;
    }
}
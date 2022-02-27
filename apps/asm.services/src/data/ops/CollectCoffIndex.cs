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
        public CoffSymIndex CollectCoffIndex(WsContext context)
            => Coff.Collect(context);
    }
}
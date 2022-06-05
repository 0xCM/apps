//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;
    using static core;

    partial class AsmChecks
    {

        [CmdOp("heaps/check")]
        void CheckHeaps()
        {
            var src = CodeFiles.PartFiles(PartId.Assets);
            var hex = src.Hex.ReadLines();
        }
    }
}
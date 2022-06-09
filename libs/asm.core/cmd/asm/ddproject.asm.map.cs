//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    partial class AsmCoreCmd
    {

        [CmdOp("project/asm/map")]
        void CreateCodeMap()
        {
            using var dst = Alloc.create();
            var src = Project();
            var map = MapAsmCode(src, dst);
            var count = map.EntryCount;
            for(var i=0; i<count; i++)
            {

            }
        }


        AsmCodeMap MapAsmCode(IProjectWs src, Alloc dst)
            => AsmObjects.MapAsm(src, dst);

    }
}
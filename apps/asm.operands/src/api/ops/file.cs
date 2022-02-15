//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial struct asm
    {
        [MethodImpl(Inline), Op]
        public static AsmFileSpec file(Identifier name, AsmComment[] comments, params AsmBlockSpec[] blocks)
            => new AsmFileSpec(name, comments, blocks);

        [MethodImpl(Inline), Op]
        public static AsmFileSpec file(Identifier name, params AsmBlockSpec[] blocks)
            => new AsmFileSpec(name, sys.empty<AsmComment>(), blocks);
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct AsmFiles
    {
        public static AsmFileSpec specify(Identifier name, AsmComment[] comments, params AsmBlockSpec[] blocks)
            => new AsmFileSpec(name, comments, blocks);

        public static AsmFileSpec specify(Identifier name, params AsmBlockSpec[] blocks)
            => new AsmFileSpec(name, sys.empty<AsmComment>(), blocks);
    }
}
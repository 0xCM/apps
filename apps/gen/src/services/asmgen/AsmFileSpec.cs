//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct AsmFileSpec
    {
        public Identifier Name {get;}

        public bool IntelSyntax {get;}

        public Index<AsmComment> HeaderComments {get;}

        public Index<AsmBlockSpec> Blocks {get;}

        [MethodImpl(Inline)]
        public AsmFileSpec(Identifier name, AsmComment[] comments, AsmBlockSpec[] blocks)
        {
            Name = name;
            IntelSyntax = true;
            HeaderComments = comments;
            Blocks = blocks;
        }
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class AsmSigs
    {
        public readonly struct Rel32: IAsmRel<Rel32>
        {
            public RelToken Kind => RelToken.rel32;

            public string Name => "rel32";

            public string Format()
                => Name;

            public override string ToString()
                => Format();
        }
    }
}
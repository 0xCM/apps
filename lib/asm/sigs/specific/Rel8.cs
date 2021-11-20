//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class AsmSigs
    {
        public readonly struct Rel8 : IAsmRel<Rel8>
        {
            public RelToken Kind => RelToken.rel8;

            public string Name => "rel8";

            public string Format()
                => Name;

            public override string ToString()
                => Format();
        }
    }
}
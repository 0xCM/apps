//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct AsmDocInstructions
    {
        public FS.FileUri Source {get;}


        readonly Index<AsmDocInstruction> Data;

        [MethodImpl(Inline)]
        public AsmDocInstructions(FS.FileUri src, AsmDocInstruction[] data)
        {
            Source = src;
            Data = data;
        }

        public ReadOnlySpan<AsmDocInstruction> View
        {
            [MethodImpl(Inline)]
            get => Data;
        }
    }
}
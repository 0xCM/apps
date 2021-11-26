//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using System.Runtime.InteropServices;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct AsmSyntaxDoc
    {
        readonly Index<AsmSyntaxRow> Data;

        public FS.FileUri Source {get;}

        public AsmSyntaxDoc(FS.FileUri src, AsmSyntaxRow[] rows)
        {
            Source = src;
            Data = rows;
        }

        public ReadOnlySpan<AsmSyntaxRow> Rows
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        public ref readonly AsmSyntaxRow this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public ref readonly AsmSyntaxRow this[int i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }
    }
}
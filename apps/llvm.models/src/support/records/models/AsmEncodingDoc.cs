//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using System.Runtime.InteropServices;
    using System.Runtime.CompilerServices;

    using Asm;

    using static Root;

    public readonly struct AsmEncodingDoc
    {
        readonly Index<AsmExprEncoding> Data;


        public FS.FileUri Source {get;}

        public AsmEncodingDoc(FS.FileUri src, AsmExprEncoding[] rows)
        {
            Source = src;
            Data = rows;
        }

        public ReadOnlySpan<AsmExprEncoding> ExprEncoding
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        public ref readonly AsmExprEncoding this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public ref readonly AsmExprEncoding this[int i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public static AsmEncodingDoc Empty
        {
            get => new AsmEncodingDoc(FS.FilePath.Empty, sys.empty<AsmExprEncoding>());
        }
    }
}
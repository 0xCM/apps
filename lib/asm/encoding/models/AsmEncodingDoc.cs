//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.InteropServices;
    using System.Runtime.CompilerServices;

    using Asm;

    using static Root;

    public readonly struct AsmEncodingDoc
    {
        readonly Index<AsmStatementEncoding> Data;


        public FS.FileUri Source {get;}

        public AsmEncodingDoc(FS.FileUri src, AsmStatementEncoding[] rows)
        {
            Source = src;
            Data = rows;
        }

        public uint StatmentCount
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public Span<AsmStatementEncoding> Statements
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public ref AsmStatementEncoding this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public ref AsmStatementEncoding this[int i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public static AsmEncodingDoc Empty
        {
            get => new AsmEncodingDoc(FS.FilePath.Empty, sys.empty<AsmStatementEncoding>());
        }
    }
}
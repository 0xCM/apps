//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.InteropServices;
    using System.Runtime.CompilerServices;

    using static XedModels;
    using static Root;

    using Asm;

    public struct XedDisasmBlock
    {
        public Index<TextLine> Lines;

        [MethodImpl(Inline)]
        public XedDisasmBlock(TextLine[] src)
        {
            Lines = src;
        }

        [MethodImpl(Inline)]
        public static implicit operator XedDisasmBlock(TextLine[] src)
            => new XedDisasmBlock(src);
    }

    public struct XedDisassembly
    {
        public AsmHexCode Encoded;

        public StatementDisasm Statement;

        public Index<Operand> Operands;

        public XedIForm IForm;

        public Index<Attribute> Attributes;

        public struct StatementDisasm
        {
            public LineNumber DocLine;

            public AsmStatement Asm;

            public Address32 Offset;

            public AsmHexCode Decoded;
        }

        public struct Attribute
        {
            public string Name;

            public string Value;
        }

        public struct Operand
        {
            public byte Index;

            public Index<Attribute> Attributes;
        }
    }
}
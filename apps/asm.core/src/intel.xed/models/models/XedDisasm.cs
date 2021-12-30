//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;
    using static core;
    using static XedModels;

    public readonly struct XedDisasm
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1), Record(TableId)]
        public struct Instruction
        {
            public const string TableId = "xed.disasm.instruction";

            public IClass Class;

            public IFormType Form;

            public Index<Facet<string>> Props;
        }

        public readonly struct FileBlocks
        {
            public FS.FilePath Source {get;}

            public Index<Block> Blocks {get;}

            public FileBlocks(FS.FilePath src, Block[] blocks)
            {
                Source = src;
                Blocks = blocks;
            }
        }

        /// <summary>
        /// Represents the content of a verbose xed instruction disassembly
        /// </summary>
        public readonly struct Block
        {
            public Index<TextLine> Lines {get;}

            [MethodImpl(Inline)]
            public Block(TextLine[] src)
            {
                Lines = src;
            }

            public bool IsValid
            {
                [MethodImpl(Inline)]
                get => Lines.Count >= 3;
            }

            public bool IsEmtpy
            {
                [MethodImpl(Inline)]
                get => Lines.IsEmpty;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Lines.IsEmpty;
            }

            public uint OperandCount
            {
                [MethodImpl(Inline)]
                get => Lines.Count - 3;
            }

            public ReadOnlySpan<TextLine> Operands
            {
                [MethodImpl(Inline)]
                get => slice(Lines.View,1,OperandCount);
            }

            public ref readonly TextLine Instruction
            {
                [MethodImpl(Inline)]
                get => ref Lines.First;
            }

            public ref readonly TextLine XDis
            {
                [MethodImpl(Inline)]
                get  => ref Lines.Last;
            }

            public ref readonly TextLine YDis
            {
                [MethodImpl(Inline)]
                get  => ref Lines[Lines.Count  - 2];
            }

            [MethodImpl(Inline)]
            public static implicit operator Block(TextLine[] src)
                => new Block(src);
        }
    }
}
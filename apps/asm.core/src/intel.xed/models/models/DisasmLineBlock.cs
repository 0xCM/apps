//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial struct XedModels
    {
        /// <summary>
        /// Represents the content of a verbose xed instruction disassembly
        /// </summary>
        public readonly struct DisasmLineBlock
        {
            public Index<TextLine> Lines {get;}

            [MethodImpl(Inline)]
            public DisasmLineBlock(TextLine[] src)
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
            public static implicit operator DisasmLineBlock(TextLine[] src)
                => new DisasmLineBlock(src);
        }
    }
}
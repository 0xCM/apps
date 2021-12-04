//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Defines header content in a text data file
    /// </summary>
    public readonly struct TextDocHeader
    {
        public Index<string> Labels {get;}

        [MethodImpl(Inline)]
        public TextDocHeader(string[] src)
            => Labels = src;

        public string Format(char? sep = null)
            => string.Join(sep ?? Chars.Pipe, Labels);

        public override string ToString()
            => Format();

        public uint CellCount
        {
            [MethodImpl(Inline)]
            get => Labels.Count;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Labels.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !Labels.IsEmpty;
        }

        public static TextDocHeader Empty
            => new TextDocHeader(sys.empty<string>());
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.InteropServices;

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct NasmListEntry : IRecord<NasmListEntry>
    {
        public const string TableId = "nasm.listing";

        public uint EntryNumber;

        public uint LineNumber;

        public Identifier Label;

        public MemoryAddress Offset;

        public BinaryCode Encoding;

        public TextBlock SourceText;
    }
}
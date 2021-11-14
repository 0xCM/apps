//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.InteropServices;

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct NasmEncoding : IRecord<NasmEncoding>
    {
        public const string TableId = "nasm.encoding";

        public uint LineNumber;

        public MemoryAddress Offset;

        public TextBlock SourceText;

        public BinaryCode Encoded;
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Runtime.InteropServices;

    /// <summary>
    /// Represents an asm statement together with its context and encoding
    /// </summary>
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct AssembledAsm : IRecord<AssembledAsm>
    {
        public const string TableId = "asm.assembled";

        public LineNumber SourceLine;

        public MemoryAddress Offset;

        public AsmExpr Statement;

        public BinaryCode Encoding;

        public TextBlock Bitstring;
    }
}
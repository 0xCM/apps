//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    /// <summary>
    /// Represents an asm statement together with its context and encoding
    /// </summary>
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct AssembledAsm
    {
        public const string TableId = "asm.assembled";

        public LineNumber SourceLine;

        public Hex64 Id;

        public MemoryAddress IP;

        public AsmExpr Asm;

        public BinaryCode Encoded;

        public TextBlock Bitstring;
    }
}
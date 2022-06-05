//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Z0.Asm;

    using static core;

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct ProcessAsmRecord : IComparable<ProcessAsmRecord>, IAsmHexProvider<ProcessAsmRecord>
    {
        const string TableId = "asm.global";

        public const byte FieldCount = 11;

        public const ushort RowPad = 680;

        public static Outcome parse(TextLine src, out ProcessAsmRecord dst)
        {
            const string ErrorPattern = "Error parsing {0} on line {1}";
            var parts = src.Split(Chars.Pipe).Map(x => x.Trim());
            var count = parts.Length;
            var outcome = Outcome.Success;
            if(count != ProcessAsmRecord.FieldCount)
            {
                dst = default;
                return (false, AppMsg.CsvDataMismatch.Format(ProcessAsmRecord.FieldCount, count, src.Content));
            }
            dst = default;
            var i=0u;

            outcome += DataParser.parse(skip(parts,i++), out dst.Sequence);
            if(outcome.Fail)
                return (false, string.Format(ErrorPattern, nameof(dst.Sequence), src.LineNumber));

            outcome += DataParser.parse(skip(parts,i++), out dst.GlobalOffset);
            if(outcome.Fail)
                return (false, string.Format(ErrorPattern, nameof(dst.GlobalOffset), src.LineNumber));

            outcome += DataParser.parse(skip(parts,i++), out dst.BlockAddress);
            if(outcome.Fail)
                return (false, string.Format(ErrorPattern, nameof(dst.BlockAddress), src.LineNumber));

            outcome += DataParser.parse(skip(parts,i++), out dst.IP);
            if(outcome.Fail)
                return (false, string.Format(ErrorPattern, nameof(dst.IP), src.LineNumber));

            outcome += DataParser.parse(skip(parts,i++), out dst.BlockOffset);
            if(outcome.Fail)
                return (false, string.Format(ErrorPattern, nameof(dst.BlockOffset), src.LineNumber));

            dst.Statement = text.trim(skip(parts,i++));

            outcome += AsmHexCode.asmhex(skip(parts,i++), out dst.Encoded);
            if(outcome.Fail)
                return (false, string.Format(ErrorPattern, nameof(dst.Encoded), src.LineNumber));

            outcome += AsmSigInfo.parse(skip(parts,i++), out dst.Sig);
            if(outcome.Fail)
                return (false, string.Format(ErrorPattern, nameof(dst.Sig), src.LineNumber));

            dst.OpCode = skip(parts, i++);

            var bitstring = skip(parts,i++);
            dst.Bitstring = AsmHexCode.bitstring(dst.Encoded);

            outcome += DataParser.parse(skip(parts,i++), out dst.OpUri);
            if(outcome.Fail)
                return (false, string.Format(ErrorPattern, nameof(dst.OpUri), src.LineNumber));

            return true;
        }

        /// <summary>
        /// A 0-based monotonic value that serves as a surrogate key
        /// </summary>
        [Render(12)]
        public uint Sequence;

        /// <summary>
        /// A 0-based 32-bit offset
        /// </summary>
        [Render(16)]
        public Address32 GlobalOffset;

        /// <summary>
        /// The IP block address
        /// </summary>
        [Render(16)]
        public MemoryAddress BlockAddress;

        /// <summary>
        /// The IP address
        /// </summary>
        [Render(16)]
        public MemoryAddress IP;

        /// <summary>
        /// The block-relative IP offset
        /// </summary>
        [Render(16)]
        public Address16 BlockOffset;

        [Render(42)]
        public AsmExpr Statement;

        [Render(32)]
        public AsmHexCode Encoded;

        [Render(42)]
		public AsmSigInfo Sig;

        [Render(32)]
        public TextBlock OpCode;

        [Render(128)]
        public string Bitstring;

        [Render(80)]
        public OpUri OpUri;

        [MethodImpl(Inline)]
        public ref readonly AsmHexCode AsmHex(out AsmHexCode hex)
        {
            hex = Encoded;
            return ref hex;
        }

        [MethodImpl(Inline)]
        public int CompareTo(ProcessAsmRecord src)
            => IP.CompareTo(src.IP);

        public override int GetHashCode()
            => (int)Sequence;

        public static ProcessAsmRecord Empty => default;
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [Record(TableId), StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct AsmEncodingInfo : IEquatable<AsmEncodingInfo>, IComparable<AsmEncodingInfo>
    {
        public const string TableId = "asm.encoding";

        [Op]
        public static string thumbprint(in AsmEncodingInfo src)
        {
            var bits = src.Encoded.ToBitString();
            var statement = string.Format("{0} # ({1})<{2}>[{3}] => {4}", src.Statement.FormatPadded(), src.Sig, src.OpCode, src.Encoded.Size, src.Encoded.Format());
            return string.Format("{0} => {1}", statement, bits);
        }


        /// <summary>
        /// The form used to produce the encoded bits from the statement
        /// </summary>
        public AsmFormInfo Form;

        /// <summary>
        /// The encoded statement
        /// </summary>
        public AsmExpr Statement;

        /// <summary>
        /// The encoded bytes
        /// </summary>
        public AsmHexCode Encoded;

        /// <summary>
        /// The encoded data represented as a bitstring
        /// </summary>
        public AsmBitstring Bits;

        [MethodImpl(Inline)]
        public AsmEncodingInfo(AsmFormInfo form, AsmExpr statement, AsmHexCode hex, AsmBitstring bits)
        {
            Form = form;
            Statement = statement;
            Encoded = hex;
            Bits = bits;
        }

        /// <summary>
        /// The signature to which the statement conforms
        /// </summary>
		public AsmSigInfo Sig
        {
            [MethodImpl(Inline)]
            get => Form.Sig;
        }

        /// <summary>
        /// The op code that deterimines the encoding
        /// </summary>
        public AsmOpCodeString OpCode
        {
            [MethodImpl(Inline)]
            get => Form.OpCode;
        }

        public int CompareTo(AsmEncodingInfo src)
            => Statement.CompareTo(src.Statement);

        public override int GetHashCode()
            => (int)Bits.Hash;

        [MethodImpl(Inline)]

        public bool Equals(AsmEncodingInfo src)
            => Bits.Equals(src.Bits);

        public override bool Equals(object src)
            => src is AsmEncodingInfo b && Equals(b);
    }
}
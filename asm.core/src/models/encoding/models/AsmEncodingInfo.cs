//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public class AsmEncodingInfo : IEquatable<AsmEncodingInfo>, IComparable<AsmEncodingInfo>
    {
        /// <summary>
        /// The form used to produce the encoded bits from the statement
        /// </summary>
        public AsmFormInfo Form {get;}

        /// <summary>
        /// The encoded statement
        /// </summary>
        public AsmExpr Statement {get;}

        /// <summary>
        /// The encoded bytes
        /// </summary>
        public AsmHexCode Encoded {get;}

        /// <summary>
        /// The encoded data represented as a bitstring
        /// </summary>
        public AsmBitstring Bits {get;}

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
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct AsmThumbprint : IDataTypeComparable<AsmThumbprint>
    {
        public AsmExpr Statement {get;}

        public AsmSigInfo Sig {get;}

        public AsmOpCodeString OpCode {get;}

        public AsmHexCode Encoded {get;}

        [MethodImpl(Inline), Op]
        public AsmThumbprint(AsmExpr statement, AsmSigInfo sig, AsmOpCodeString opcode, AsmHexCode encoded)
        {
            Statement = statement;
            Sig = sig;
            OpCode = opcode;
            Encoded = encoded;
        }

        public byte CodeSize
        {
            [MethodImpl(Inline)]
            get => Encoded.Size;
        }

        public int CompareTo(AsmThumbprint src)
            => cmp(this, src);

        public bool Equals(AsmThumbprint src)
            => eq(this, src);

        public override int GetHashCode()
            => Format().GetHashCode();
        public string Format()
            => AsmRender.format(this);

        public override string ToString()
            => Format();

        public static AsmThumbprint Empty
        {
            [MethodImpl(Inline)]
            get => new AsmThumbprint(AsmExpr.Empty, AsmSigInfo.Empty, AsmOpCodeString.Empty, AsmHexCode.Empty);
        }

        [Op]
        static int cmp(in AsmThumbprint a, in AsmThumbprint b)
            => AsmRender.format(a).CompareTo(AsmRender.format(b));

        [Op]
        static bool eq(in AsmThumbprint a, in AsmThumbprint b)
            => AsmRender.format(a).Equals(AsmRender.format(b));
    }
}
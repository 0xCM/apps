//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    /// <summary>
    /// Defines a signed 32-bit displacement
    /// </summary>
    [DataType(TypeSyntax.Disp32)]
    public readonly struct Disp32 : IDisplacement<Disp32,int>
    {
        [Parser]
        public static Outcome parse(string src, out Disp32 dst)
        {
            var result = Outcome.Success;
            dst = default;
            var i = text.index(src,HexFormatSpecs.PreSpec);
            var disp = 0u;
            if(i>=0)
            {
                result = HexParser.parse32u(src, out disp);
                if(result)
                    dst = disp;
            }
            else
            {
                result = DataParser.parse(src, out disp);
                if(result)
                    dst = disp;
            }
            return result;
        }

        public int Value {get;}

        [MethodImpl(Inline)]
        public Disp32(int value)
        {
            Value = value;
        }

        public NativeSize Size
            => NativeSizeCode.W32;

        public AsmOpKind OpKind
            => AsmOpKind.Disp32;

        public bool Positive
        {
            [MethodImpl(Inline)]
            get => Value > 0;
        }

        public bool Negative
        {
            [MethodImpl(Inline)]
            get => Value < 0;
        }

        public bool IsNonZero
        {
            [MethodImpl(Inline)]
            get => Value == 0;
        }

        public string Format()
            => Disp.format(this);

        public override string ToString()
            => Format();

        long IDisplacement.Value
            => Value;

        [MethodImpl(Inline)]
        public static implicit operator Disp32(uint src)
            => new Disp32((int)src);

        [MethodImpl(Inline)]
        public static implicit operator Disp32(int src)
            => new Disp32(src);

        [MethodImpl(Inline)]
        public static explicit operator uint(Disp32 src)
            => (uint)src.Value;

        [MethodImpl(Inline)]
        public static implicit operator int(Disp32 src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator Disp(Disp32 src)
            => new Disp(src.Value, src.Size);

        [MethodImpl(Inline)]
        public static explicit operator Disp32(long src)
            => new Disp32((int)src);

        public static Disp32 Empty
        {
            [MethodImpl(Inline)]
            get => new Disp32(0);
        }
    }
}
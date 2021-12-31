//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Defines a signed 64-bit displacement
    /// </summary>
    [DataType(TypeSyntax.Disp64)]
    public readonly struct Disp64 : IDisplacement<Disp64,long>
    {
        [Parser]
        public static Outcome parse(string src, out Disp64 dst)
        {
            var result = Outcome.Success;
            dst = default;
            var i = text.index(src,HexFormatSpecs.PreSpec);
            var disp = 0ul;
            if(i>=0)
            {
                result = HexParser.parse64u(src, out disp);
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

        public long Value {get;}

        [MethodImpl(Inline)]
        public Disp64(long value)
        {
            Value = value;
        }

        public byte StorageWidth
        {
            [MethodImpl(Inline)]
            get => 64;
        }

        public bool IsNonZero
        {
            [MethodImpl(Inline)]
            get => Value == 0;
        }

        public string Format()
            => AsmRender.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator ulong(Disp64 src)
            => (ulong)src.Value;

        [MethodImpl(Inline)]
        public static implicit operator long(Disp64 src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator Disp(Disp64 src)
            => new Disp(src.Value, src.StorageWidth);

        [MethodImpl(Inline)]
        public static implicit operator Disp64(ulong src)
            => new Disp64((long)src);

        [MethodImpl(Inline)]
        public static implicit operator Disp64(long src)
            => new Disp64((int)src);

        public static Disp64 Empty
        {
            [MethodImpl(Inline)]
            get => new Disp64(0);
        }
    }
}
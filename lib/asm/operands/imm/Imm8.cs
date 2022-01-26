//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Linq;

    using static Root;

    using W = W8;
    using I = imm8;

    using Asm;

    /// <summary>
    /// Defines an 8-bit immediate value
    /// </summary>
    [DataType(TypeSyntax.Imm8, Kind, Width, Width)]
    public readonly struct imm8 : IImm<I,byte>
    {
        [Op]
        public static Index<imm8R> refined(ParameterInfo param)
        {
            if(param.IsRefinedImmediate())
                return param.ParameterType.GetEnumValues().Cast<byte>().Array().ToImm8Values(ImmRefinementKind.Refined);
            else
                return sys.empty<imm8R>();
        }

        [Parser]
        public static Outcome parse(string src, out imm8 dst)
        {
            var result = Outcome.Success;
            dst = default;
            var i = text.index(src,HexFormatSpecs.PreSpec);
            var imm = z8;
            if(i>=0)
            {
                result = HexParser.parse8u(src, out imm);
                if(result)
                    dst = imm;
            }
            else
            {
                result = DataParser.parse(src, out imm);
                if(result)
                    dst = imm;
            }
            return result;
        }

        public const ImmKind Kind = ImmKind.Imm8;

        public const byte Width = 8;

        public byte Value {get;}

        [MethodImpl(Inline)]
        public imm8(byte src)
            => Value = src;

        public ImmKind ImmKind
            => Kind;

        public ImmBitWidth ImmWidth
            => (ImmBitWidth)Width;

        public AsmOpKind OpKind
            => AsmOpKind.Imm8;

        public uint Hash
        {
            [MethodImpl(Inline)]
            get => Value;
        }

        public string Format()
            => HexFormatter.format(w8, Value, HexPadStyle.Unpadded, prespec:true, @case:UpperCase);

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => (int)Hash;

        [MethodImpl(Inline)]
        public int CompareTo(I src)
            => Value == src.Value ? 0 : Value < src.Value ? -1 : 1;

        [MethodImpl(Inline)]
        public bool Equals(I src)
            => Value == src.Value;

        public override bool Equals(object src)
            => src is I x && Equals(x);

        [MethodImpl(Inline)]
        public Address8 ToAddress()
            => Value;

        [MethodImpl(Inline)]
        public static bool operator <(I a, I b)
            => a.Value < b.Value;

        [MethodImpl(Inline)]
        public static bool operator >(I a, I b)
            => a.Value > b.Value;

        [MethodImpl(Inline)]
        public static bool operator <=(I a, I b)
            => a.Value <= b.Value;

        [MethodImpl(Inline)]
        public static bool operator >=(I a, I b)
            => a.Value >= b.Value;

        [MethodImpl(Inline)]
        public static bool operator ==(I a, I b)
            => a.Value == b.Value;

        [MethodImpl(Inline)]
        public static bool operator !=(I a, I b)
            => a.Value != b.Value;

        [MethodImpl(Inline)]
        public static implicit operator byte(I src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator Imm<byte>(I src)
            => new Imm<byte>(src);

        [MethodImpl(Inline)]
        public static implicit operator I(byte src)
            => new I(src);

        [MethodImpl(Inline)]
        public static implicit operator Imm(I src)
            => new Imm(src.ImmKind, src.Value);

        public static W W => default;
    }
}
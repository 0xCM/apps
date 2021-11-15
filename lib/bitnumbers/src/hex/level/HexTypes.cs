//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct X00 : IHexType<X00>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X00 src) => Hex8Seq.x00;

        [MethodImpl(Inline)]
        public static implicit operator byte(X00 src) => 0x00;

        public Hex8Seq Value => Hex8Seq.x00;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X01 : IHexType<X01>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X01 src) => Hex8Seq.x01;

        [MethodImpl(Inline)]
        public static implicit operator byte(X01 src) => 0x01;

        public Hex8Seq Value => Hex8Seq.x01;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X02 : IHexType<X02>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X02 src) => Hex8Seq.x02;

        [MethodImpl(Inline)]
        public static implicit operator byte(X02 src) => 0x02;

        public Hex8Seq Value => Hex8Seq.x02;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X03 : IHexType<X03>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X03 src) => Hex8Seq.x03;

        [MethodImpl(Inline)]
        public static implicit operator byte(X03 src) => 0x03;

        public Hex8Seq Value => Hex8Seq.x03;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X04 : IHexType<X04>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X04 src) => Hex8Seq.x04;

        [MethodImpl(Inline)]
        public static implicit operator byte(X04 src) => 0x04;

        public Hex8Seq Value => Hex8Seq.x04;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X05 : IHexType<X05>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X05 src) => Hex8Seq.x05;

        [MethodImpl(Inline)]
        public static implicit operator byte(X05 src) => 0x05;

        public Hex8Seq Value => Hex8Seq.x05;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X06 : IHexType<X06>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X06 src) => Hex8Seq.x06;

        [MethodImpl(Inline)]
        public static implicit operator byte(X06 src) => 0x06;

        public Hex8Seq Value => Hex8Seq.x06;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X07 : IHexType<X07>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X07 src) => Hex8Seq.x07;

        [MethodImpl(Inline)]
        public static implicit operator byte(X07 src) => 0x07;

        public Hex8Seq Value => Hex8Seq.x07;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X08 : IHexType<X08>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X08 src) => Hex8Seq.x08;

        [MethodImpl(Inline)]
        public static implicit operator byte(X08 src) => 0x08;

        public Hex8Seq Value => Hex8Seq.x08;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X09 : IHexType<X09>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X09 src) => Hex8Seq.x09;

        [MethodImpl(Inline)]
        public static implicit operator byte(X09 src) => 0x09;

        public Hex8Seq Value => Hex8Seq.x09;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X0A : IHexType<X0A>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X0A src) => Hex8Seq.x0a;

        [MethodImpl(Inline)]
        public static implicit operator byte(X0A src) => 0x0a;

        public Hex8Seq Value => Hex8Seq.x0a;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X0B : IHexType<X0B>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X0B src) => Hex8Seq.x0b;

        [MethodImpl(Inline)]
        public static implicit operator byte(X0B src) => 0x0b;

        public Hex8Seq Value => Hex8Seq.x0b;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X0C : IHexType<X0C>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X0C src) => Hex8Seq.x0c;

        [MethodImpl(Inline)]
        public static implicit operator byte(X0C src) => 0x0c;

        public Hex8Seq Value => Hex8Seq.x0c;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X0D : IHexType<X0D>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X0D src) => Hex8Seq.x0d;

        [MethodImpl(Inline)]
        public static implicit operator byte(X0D src) => 0x0d;

        public Hex8Seq Value => Hex8Seq.x0d;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X0E : IHexType<X0E>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X0E src) => Hex8Seq.x0e;

        [MethodImpl(Inline)]
        public static implicit operator byte(X0E src) => 0x0e;

        public Hex8Seq Value => Hex8Seq.x0e;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X0F : IHexType<X0F>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X0F src) => Hex8Seq.x0f;

        [MethodImpl(Inline)]
        public static implicit operator byte(X0F src) => 0x0f;

        public Hex8Seq Value => Hex8Seq.x0f;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X10 : IHexType<X10>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X10 src) => Hex8Seq.x10;

        [MethodImpl(Inline)]
        public static implicit operator byte(X10 src) => 0x10;

        public Hex8Seq Value => Hex8Seq.x10;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X11 : IHexType<X11>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X11 src) => Hex8Seq.x11;

        [MethodImpl(Inline)]
        public static implicit operator byte(X11 src) => 0x11;

        public Hex8Seq Value => Hex8Seq.x11;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X12 : IHexType<X12>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X12 src) => Hex8Seq.x12;

        [MethodImpl(Inline)]
        public static implicit operator byte(X12 src) => 0x12;

        public Hex8Seq Value => Hex8Seq.x12;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X13 : IHexType<X13>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X13 src) => Hex8Seq.x13;

        [MethodImpl(Inline)]
        public static implicit operator byte(X13 src) => 0x13;

        public Hex8Seq Value => Hex8Seq.x13;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X14 : IHexType<X14>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X14 src) => Hex8Seq.x14;

        [MethodImpl(Inline)]
        public static implicit operator byte(X14 src) => 0x14;

        public Hex8Seq Value => Hex8Seq.x14;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X15 : IHexType<X15>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X15 src) => Hex8Seq.x15;

        [MethodImpl(Inline)]
        public static implicit operator byte(X15 src) => 0x15;

        public Hex8Seq Value => Hex8Seq.x15;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X16 : IHexType<X16>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X16 src) => Hex8Seq.x16;

        [MethodImpl(Inline)]
        public static implicit operator byte(X16 src) => 0x16;

        public Hex8Seq Value => Hex8Seq.x16;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X17 : IHexType<X17>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X17 src) => Hex8Seq.x17;

        [MethodImpl(Inline)]
        public static implicit operator byte(X17 src) => 0x17;

        public Hex8Seq Value => Hex8Seq.x17;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X18 : IHexType<X18>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X18 src) => Hex8Seq.x18;

        [MethodImpl(Inline)]
        public static implicit operator byte(X18 src) => 0x18;

        public Hex8Seq Value => Hex8Seq.x18;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X19 : IHexType<X19>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X19 src) => Hex8Seq.x19;

        [MethodImpl(Inline)]
        public static implicit operator byte(X19 src) => 0x19;

        public Hex8Seq Value => Hex8Seq.x19;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X1A : IHexType<X1A>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X1A src) => Hex8Seq.x1a;

        [MethodImpl(Inline)]
        public static implicit operator byte(X1A src) => 0x1a;

        public Hex8Seq Value => Hex8Seq.x1a;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X1B : IHexType<X1B>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X1B src) => Hex8Seq.x1b;

        [MethodImpl(Inline)]
        public static implicit operator byte(X1B src) => 0x1b;

        public Hex8Seq Value => Hex8Seq.x1b;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X1C : IHexType<X1C>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X1C src) => Hex8Seq.x1c;

        [MethodImpl(Inline)]
        public static implicit operator byte(X1C src) => 0x1c;

        public Hex8Seq Value => Hex8Seq.x1c;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X1D : IHexType<X1D>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X1D src) => Hex8Seq.x1d;

        [MethodImpl(Inline)]
        public static implicit operator byte(X1D src) => 0x1d;

        public Hex8Seq Value => Hex8Seq.x1d;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X1E : IHexType<X1E>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X1E src) => Hex8Seq.x1e;

        [MethodImpl(Inline)]
        public static implicit operator byte(X1E src) => 0x1e;

        public Hex8Seq Value => Hex8Seq.x1e;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X1F : IHexType<X1F>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X1F src) => Hex8Seq.x1f;

        [MethodImpl(Inline)]
        public static implicit operator byte(X1F src) => 0x1f;

        public Hex8Seq Value => Hex8Seq.x1f;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X20 : IHexType<X20>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X20 src) => Hex8Seq.x20;

        [MethodImpl(Inline)]
        public static implicit operator byte(X20 src) => 0x20;

        public Hex8Seq Value => Hex8Seq.x20;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X21 : IHexType<X21>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X21 src) => Hex8Seq.x21;

        [MethodImpl(Inline)]
        public static implicit operator byte(X21 src) => 0x21;

        public Hex8Seq Value => Hex8Seq.x21;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X22 : IHexType<X22>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X22 src) => Hex8Seq.x22;

        [MethodImpl(Inline)]
        public static implicit operator byte(X22 src) => 0x22;

        public Hex8Seq Value => Hex8Seq.x22;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X23 : IHexType<X23>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X23 src) => Hex8Seq.x23;

        [MethodImpl(Inline)]
        public static implicit operator byte(X23 src) => 0x23;

        public Hex8Seq Value => Hex8Seq.x23;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X24 : IHexType<X24>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X24 src) => Hex8Seq.x24;

        [MethodImpl(Inline)]
        public static implicit operator byte(X24 src) => 0x24;

        public Hex8Seq Value => Hex8Seq.x24;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X25 : IHexType<X25>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X25 src) => Hex8Seq.x25;

        [MethodImpl(Inline)]
        public static implicit operator byte(X25 src) => 0x25;

        public Hex8Seq Value => Hex8Seq.x25;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X26 : IHexType<X26>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X26 src) => Hex8Seq.x26;

        [MethodImpl(Inline)]
        public static implicit operator byte(X26 src) => 0x26;

        public Hex8Seq Value => Hex8Seq.x26;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X27 : IHexType<X27>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X27 src) => Hex8Seq.x27;

        [MethodImpl(Inline)]
        public static implicit operator byte(X27 src) => 0x27;

        public Hex8Seq Value => Hex8Seq.x27;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X28 : IHexType<X28>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X28 src) => Hex8Seq.x28;

        [MethodImpl(Inline)]
        public static implicit operator byte(X28 src) => 0x28;

        public Hex8Seq Value => Hex8Seq.x28;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X29 : IHexType<X29>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X29 src) => Hex8Seq.x29;

        [MethodImpl(Inline)]
        public static implicit operator byte(X29 src) => 0x29;

        public Hex8Seq Value => Hex8Seq.x29;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X2A : IHexType<X2A>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X2A src) => Hex8Seq.x2a;

        [MethodImpl(Inline)]
        public static implicit operator byte(X2A src) => 0x2a;

        public Hex8Seq Value => Hex8Seq.x2a;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X2B : IHexType<X2B>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X2B src) => Hex8Seq.x2b;

        [MethodImpl(Inline)]
        public static implicit operator byte(X2B src) => 0x2b;

        public Hex8Seq Value => Hex8Seq.x2b;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X2C : IHexType<X2C>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X2C src) => Hex8Seq.x2c;

        [MethodImpl(Inline)]
        public static implicit operator byte(X2C src) => 0x2c;

        public Hex8Seq Value => Hex8Seq.x2c;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X2D : IHexType<X2D>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X2D src) => Hex8Seq.x2d;

        [MethodImpl(Inline)]
        public static implicit operator byte(X2D src) => 0x2d;

        public Hex8Seq Value => Hex8Seq.x2d;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X2E : IHexType<X2E>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X2E src) => Hex8Seq.x2e;

        [MethodImpl(Inline)]
        public static implicit operator byte(X2E src) => 0x2e;

        public Hex8Seq Value => Hex8Seq.x2e;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X2F : IHexType<X2F>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X2F src) => Hex8Seq.x2f;

        [MethodImpl(Inline)]
        public static implicit operator byte(X2F src) => 0x2f;

        public Hex8Seq Value => Hex8Seq.x2f;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X30 : IHexType<X30>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X30 src) => Hex8Seq.x30;

        [MethodImpl(Inline)]
        public static implicit operator byte(X30 src) => 0x30;

        public Hex8Seq Value => Hex8Seq.x30;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X31 : IHexType<X31>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X31 src) => Hex8Seq.x31;

        [MethodImpl(Inline)]
        public static implicit operator byte(X31 src) => 0x31;

        public Hex8Seq Value => Hex8Seq.x31;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X32 : IHexType<X32>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X32 src) => Hex8Seq.x32;

        [MethodImpl(Inline)]
        public static implicit operator byte(X32 src) => 0x32;

        public Hex8Seq Value => Hex8Seq.x32;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X33 : IHexType<X33>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X33 src) => Hex8Seq.x33;

        [MethodImpl(Inline)]
        public static implicit operator byte(X33 src) => 0x33;

        public Hex8Seq Value => Hex8Seq.x33;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X34 : IHexType<X34>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X34 src) => Hex8Seq.x34;

        [MethodImpl(Inline)]
        public static implicit operator byte(X34 src) => 0x34;

        public Hex8Seq Value => Hex8Seq.x34;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X35 : IHexType<X35>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X35 src) => Hex8Seq.x35;

        [MethodImpl(Inline)]
        public static implicit operator byte(X35 src) => 0x35;

        public Hex8Seq Value => Hex8Seq.x35;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X36 : IHexType<X36>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X36 src) => Hex8Seq.x36;

        [MethodImpl(Inline)]
        public static implicit operator byte(X36 src) => 0x36;

        public Hex8Seq Value => Hex8Seq.x36;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X37 : IHexType<X37>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X37 src) => Hex8Seq.x37;

        [MethodImpl(Inline)]
        public static implicit operator byte(X37 src) => 0x37;

        public Hex8Seq Value => Hex8Seq.x37;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X38 : IHexType<X38>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X38 src) => Hex8Seq.x38;

        [MethodImpl(Inline)]
        public static implicit operator byte(X38 src) => 0x38;

        public Hex8Seq Value => Hex8Seq.x38;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X39 : IHexType<X39>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X39 src) => Hex8Seq.x39;

        [MethodImpl(Inline)]
        public static implicit operator byte(X39 src) => 0x39;

        public Hex8Seq Value => Hex8Seq.x39;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X3A : IHexType<X3A>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X3A src) => Hex8Seq.x3a;

        [MethodImpl(Inline)]
        public static implicit operator byte(X3A src) => 0x3a;

        public Hex8Seq Value => Hex8Seq.x3a;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X3B : IHexType<X3B>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X3B src) => Hex8Seq.x3b;

        [MethodImpl(Inline)]
        public static implicit operator byte(X3B src) => 0x3b;

        public Hex8Seq Value => Hex8Seq.x3b;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X3C : IHexType<X3C>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X3C src) => Hex8Seq.x3c;

        [MethodImpl(Inline)]
        public static implicit operator byte(X3C src) => 0x3c;

        public Hex8Seq Value => Hex8Seq.x3c;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X3D : IHexType<X3D>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X3D src) => Hex8Seq.x3d;

        [MethodImpl(Inline)]
        public static implicit operator byte(X3D src) => 0x3d;

        public Hex8Seq Value => Hex8Seq.x3d;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X3E : IHexType<X3E>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X3E src) => Hex8Seq.x3e;

        [MethodImpl(Inline)]
        public static implicit operator byte(X3E src) => 0x3e;

        public Hex8Seq Value => Hex8Seq.x3e;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X3F : IHexType<X3F>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X3F src) => Hex8Seq.x3f;

        [MethodImpl(Inline)]
        public static implicit operator byte(X3F src) => 0x3f;

        public Hex8Seq Value => Hex8Seq.x3f;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X40 : IHexType<X40>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X40 src) => Hex8Seq.x40;

        [MethodImpl(Inline)]
        public static implicit operator byte(X40 src) => 0x40;

        public Hex8Seq Value => Hex8Seq.x40;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X41 : IHexType<X41>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X41 src) => Hex8Seq.x41;

        [MethodImpl(Inline)]
        public static implicit operator byte(X41 src) => 0x41;

        public Hex8Seq Value => Hex8Seq.x41;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X42 : IHexType<X42>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X42 src) => Hex8Seq.x42;

        [MethodImpl(Inline)]
        public static implicit operator byte(X42 src) => 0x42;

        public Hex8Seq Value => Hex8Seq.x42;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X43 : IHexType<X43>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X43 src) => Hex8Seq.x43;

        [MethodImpl(Inline)]
        public static implicit operator byte(X43 src) => 0x43;

        public Hex8Seq Value => Hex8Seq.x43;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X44 : IHexType<X44>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X44 src) => Hex8Seq.x44;

        [MethodImpl(Inline)]
        public static implicit operator byte(X44 src) => 0x44;

        public Hex8Seq Value => Hex8Seq.x44;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X45 : IHexType<X45>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X45 src) => Hex8Seq.x45;

        [MethodImpl(Inline)]
        public static implicit operator byte(X45 src) => 0x45;

        public Hex8Seq Value => Hex8Seq.x45;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X46 : IHexType<X46>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X46 src) => Hex8Seq.x46;

        [MethodImpl(Inline)]
        public static implicit operator byte(X46 src) => 0x46;

        public Hex8Seq Value => Hex8Seq.x46;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X47 : IHexType<X47>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X47 src) => Hex8Seq.x47;

        [MethodImpl(Inline)]
        public static implicit operator byte(X47 src) => 0x47;

        public Hex8Seq Value => Hex8Seq.x47;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X48 : IHexType<X48>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X48 src) => Hex8Seq.x48;

        [MethodImpl(Inline)]
        public static implicit operator byte(X48 src) => 0x48;

        public Hex8Seq Value => Hex8Seq.x48;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X49 : IHexType<X49>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X49 src) => Hex8Seq.x49;

        [MethodImpl(Inline)]
        public static implicit operator byte(X49 src) => 0x49;

        public Hex8Seq Value => Hex8Seq.x49;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X4A : IHexType<X4A>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X4A src) => Hex8Seq.x4a;

        [MethodImpl(Inline)]
        public static implicit operator byte(X4A src) => 0x4a;

        public Hex8Seq Value => Hex8Seq.x4a;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X4B : IHexType<X4B>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X4B src) => Hex8Seq.x4b;

        [MethodImpl(Inline)]
        public static implicit operator byte(X4B src) => 0x4b;

        public Hex8Seq Value => Hex8Seq.x4b;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X4C : IHexType<X4C>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X4C src) => Hex8Seq.x4c;

        [MethodImpl(Inline)]
        public static implicit operator byte(X4C src) => 0x4c;

        public Hex8Seq Value => Hex8Seq.x4c;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X4D : IHexType<X4D>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X4D src) => Hex8Seq.x4d;

        [MethodImpl(Inline)]
        public static implicit operator byte(X4D src) => 0x4d;

        public Hex8Seq Value => Hex8Seq.x4d;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X4E : IHexType<X4E>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X4E src) => Hex8Seq.x4e;

        [MethodImpl(Inline)]
        public static implicit operator byte(X4E src) => 0x4e;

        public Hex8Seq Value => Hex8Seq.x4e;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X4F : IHexType<X4F>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X4F src) => Hex8Seq.x4f;

        [MethodImpl(Inline)]
        public static implicit operator byte(X4F src) => 0x4f;

        public Hex8Seq Value => Hex8Seq.x4f;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X50 : IHexType<X50>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X50 src) => Hex8Seq.x50;

        [MethodImpl(Inline)]
        public static implicit operator byte(X50 src) => 0x50;

        public Hex8Seq Value => Hex8Seq.x50;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X51 : IHexType<X51>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X51 src) => Hex8Seq.x51;

        [MethodImpl(Inline)]
        public static implicit operator byte(X51 src) => 0x51;

        public Hex8Seq Value => Hex8Seq.x51;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X52 : IHexType<X52>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X52 src) => Hex8Seq.x52;

        [MethodImpl(Inline)]
        public static implicit operator byte(X52 src) => 0x52;

        public Hex8Seq Value => Hex8Seq.x52;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X53 : IHexType<X53>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X53 src) => Hex8Seq.x53;

        [MethodImpl(Inline)]
        public static implicit operator byte(X53 src) => 0x53;

        public Hex8Seq Value => Hex8Seq.x53;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X54 : IHexType<X54>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X54 src) => Hex8Seq.x54;

        [MethodImpl(Inline)]
        public static implicit operator byte(X54 src) => 0x54;

        public Hex8Seq Value => Hex8Seq.x54;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X55 : IHexType<X55>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X55 src) => Hex8Seq.x55;

        [MethodImpl(Inline)]
        public static implicit operator byte(X55 src) => 0x55;

        public Hex8Seq Value => Hex8Seq.x55;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X56 : IHexType<X56>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X56 src) => Hex8Seq.x56;

        [MethodImpl(Inline)]
        public static implicit operator byte(X56 src) => 0x56;

        public Hex8Seq Value => Hex8Seq.x56;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X57 : IHexType<X57>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X57 src) => Hex8Seq.x57;

        [MethodImpl(Inline)]
        public static implicit operator byte(X57 src) => 0x57;

        public Hex8Seq Value => Hex8Seq.x57;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X58 : IHexType<X58>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X58 src) => Hex8Seq.x58;

        [MethodImpl(Inline)]
        public static implicit operator byte(X58 src) => 0x58;

        public Hex8Seq Value => Hex8Seq.x58;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X59 : IHexType<X59>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X59 src) => Hex8Seq.x59;

        [MethodImpl(Inline)]
        public static implicit operator byte(X59 src) => 0x59;

        public Hex8Seq Value => Hex8Seq.x59;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X5A : IHexType<X5A>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X5A src) => Hex8Seq.x5a;

        [MethodImpl(Inline)]
        public static implicit operator byte(X5A src) => 0x5a;

        public Hex8Seq Value => Hex8Seq.x5a;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X5B : IHexType<X5B>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X5B src) => Hex8Seq.x5b;

        [MethodImpl(Inline)]
        public static implicit operator byte(X5B src) => 0x5b;

        public Hex8Seq Value => Hex8Seq.x5b;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X5C : IHexType<X5C>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X5C src) => Hex8Seq.x5c;

        [MethodImpl(Inline)]
        public static implicit operator byte(X5C src) => 0x5c;

        public Hex8Seq Value => Hex8Seq.x5c;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X5D : IHexType<X5D>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X5D src) => Hex8Seq.x5d;

        [MethodImpl(Inline)]
        public static implicit operator byte(X5D src) => 0x5d;

        public Hex8Seq Value => Hex8Seq.x5d;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X5E : IHexType<X5E>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X5E src) => Hex8Seq.x5e;

        [MethodImpl(Inline)]
        public static implicit operator byte(X5E src) => 0x5e;

        public Hex8Seq Value => Hex8Seq.x5e;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X5F : IHexType<X5F>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X5F src) => Hex8Seq.x5f;

        [MethodImpl(Inline)]
        public static implicit operator byte(X5F src) => 0x5f;

        public Hex8Seq Value => Hex8Seq.x5f;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X60 : IHexType<X60>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X60 src) => Hex8Seq.x60;

        [MethodImpl(Inline)]
        public static implicit operator byte(X60 src) => 0x60;

        public Hex8Seq Value => Hex8Seq.x60;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X61 : IHexType<X61>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X61 src) => Hex8Seq.x61;

        [MethodImpl(Inline)]
        public static implicit operator byte(X61 src) => 0x61;

        public Hex8Seq Value => Hex8Seq.x61;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X62 : IHexType<X62>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X62 src) => Hex8Seq.x62;

        [MethodImpl(Inline)]
        public static implicit operator byte(X62 src) => 0x62;

        public Hex8Seq Value => Hex8Seq.x62;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X63 : IHexType<X63>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X63 src) => Hex8Seq.x63;

        [MethodImpl(Inline)]
        public static implicit operator byte(X63 src) => 0x63;

        public Hex8Seq Value => Hex8Seq.x63;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X64 : IHexType<X64>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X64 src) => Hex8Seq.x64;

        [MethodImpl(Inline)]
        public static implicit operator byte(X64 src) => 0x64;

        public Hex8Seq Value => Hex8Seq.x64;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X65 : IHexType<X65>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X65 src) => Hex8Seq.x65;

        [MethodImpl(Inline)]
        public static implicit operator byte(X65 src) => 0x65;

        public Hex8Seq Value => Hex8Seq.x65;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X66 : IHexType<X66>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X66 src) => Hex8Seq.x66;

        [MethodImpl(Inline)]
        public static implicit operator byte(X66 src) => 0x66;

        public Hex8Seq Value => Hex8Seq.x66;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X67 : IHexType<X67>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X67 src) => Hex8Seq.x67;

        [MethodImpl(Inline)]
        public static implicit operator byte(X67 src) => 0x67;

        public Hex8Seq Value => Hex8Seq.x67;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X68 : IHexType<X68>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X68 src) => Hex8Seq.x68;

        [MethodImpl(Inline)]
        public static implicit operator byte(X68 src) => 0x68;

        public Hex8Seq Value => Hex8Seq.x68;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X69 : IHexType<X69>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X69 src) => Hex8Seq.x69;

        [MethodImpl(Inline)]
        public static implicit operator byte(X69 src) => 0x69;

        public Hex8Seq Value => Hex8Seq.x69;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X6A : IHexType<X6A>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X6A src) => Hex8Seq.x6a;

        [MethodImpl(Inline)]
        public static implicit operator byte(X6A src) => 0x6a;

        public Hex8Seq Value => Hex8Seq.x6a;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X6B : IHexType<X6B>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X6B src) => Hex8Seq.x6b;

        [MethodImpl(Inline)]
        public static implicit operator byte(X6B src) => 0x6b;

        public Hex8Seq Value => Hex8Seq.x6b;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X6C : IHexType<X6C>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X6C src) => Hex8Seq.x6c;

        [MethodImpl(Inline)]
        public static implicit operator byte(X6C src) => 0x6c;

        public Hex8Seq Value => Hex8Seq.x6c;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X6D : IHexType<X6D>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X6D src) => Hex8Seq.x6d;

        [MethodImpl(Inline)]
        public static implicit operator byte(X6D src) => 0x6d;

        public Hex8Seq Value => Hex8Seq.x6d;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X6E : IHexType<X6E>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X6E src) => Hex8Seq.x6e;

        [MethodImpl(Inline)]
        public static implicit operator byte(X6E src) => 0x6e;

        public Hex8Seq Value => Hex8Seq.x6e;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X6F : IHexType<X6F>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X6F src) => Hex8Seq.x6f;

        [MethodImpl(Inline)]
        public static implicit operator byte(X6F src) => 0x6f;

        public Hex8Seq Value => Hex8Seq.x6f;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X70 : IHexType<X70>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X70 src) => Hex8Seq.x70;

        [MethodImpl(Inline)]
        public static implicit operator byte(X70 src) => 0x70;

        public Hex8Seq Value => Hex8Seq.x70;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X71 : IHexType<X71>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X71 src) => Hex8Seq.x71;

        [MethodImpl(Inline)]
        public static implicit operator byte(X71 src) => 0x71;

        public Hex8Seq Value => Hex8Seq.x71;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X72 : IHexType<X72>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X72 src) => Hex8Seq.x72;

        [MethodImpl(Inline)]
        public static implicit operator byte(X72 src) => 0x72;

        public Hex8Seq Value => Hex8Seq.x72;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X73 : IHexType<X73>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X73 src) => Hex8Seq.x73;

        [MethodImpl(Inline)]
        public static implicit operator byte(X73 src) => 0x73;

        public Hex8Seq Value => Hex8Seq.x73;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X74 : IHexType<X74>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X74 src) => Hex8Seq.x74;

        [MethodImpl(Inline)]
        public static implicit operator byte(X74 src) => 0x74;

        public Hex8Seq Value => Hex8Seq.x74;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X75 : IHexType<X75>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X75 src) => Hex8Seq.x75;

        [MethodImpl(Inline)]
        public static implicit operator byte(X75 src) => 0x75;

        public Hex8Seq Value => Hex8Seq.x75;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X76 : IHexType<X76>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X76 src) => Hex8Seq.x76;

        [MethodImpl(Inline)]
        public static implicit operator byte(X76 src) => 0x76;

        public Hex8Seq Value => Hex8Seq.x76;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X77 : IHexType<X77>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X77 src) => Hex8Seq.x77;

        [MethodImpl(Inline)]
        public static implicit operator byte(X77 src) => 0x77;

        public Hex8Seq Value => Hex8Seq.x77;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X78 : IHexType<X78>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X78 src) => Hex8Seq.x78;

        [MethodImpl(Inline)]
        public static implicit operator byte(X78 src) => 0x78;

        public Hex8Seq Value => Hex8Seq.x78;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X79 : IHexType<X79>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X79 src) => Hex8Seq.x79;

        [MethodImpl(Inline)]
        public static implicit operator byte(X79 src) => 0x79;

        public Hex8Seq Value => Hex8Seq.x79;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X7A : IHexType<X7A>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X7A src) => Hex8Seq.x7a;

        [MethodImpl(Inline)]
        public static implicit operator byte(X7A src) => 0x7a;

        public Hex8Seq Value => Hex8Seq.x7a;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X7B : IHexType<X7B>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X7B src) => Hex8Seq.x7b;

        [MethodImpl(Inline)]
        public static implicit operator byte(X7B src) => 0x7b;

        public Hex8Seq Value => Hex8Seq.x7b;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X7C : IHexType<X7C>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X7C src) => Hex8Seq.x7c;

        [MethodImpl(Inline)]
        public static implicit operator byte(X7C src) => 0x7c;

        public Hex8Seq Value => Hex8Seq.x7c;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X7D : IHexType<X7D>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X7D src) => Hex8Seq.x7d;

        [MethodImpl(Inline)]
        public static implicit operator byte(X7D src) => 0x7d;

        public Hex8Seq Value => Hex8Seq.x7d;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X7E : IHexType<X7E>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X7E src) => Hex8Seq.x7e;

        [MethodImpl(Inline)]
        public static implicit operator byte(X7E src) => 0x7e;

        public Hex8Seq Value => Hex8Seq.x7e;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X7F : IHexType<X7F>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X7F src) => Hex8Seq.x7f;

        [MethodImpl(Inline)]
        public static implicit operator byte(X7F src) => 0x7f;

        public Hex8Seq Value => Hex8Seq.x7f;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X80 : IHexType<X80>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X80 src) => Hex8Seq.x80;

        [MethodImpl(Inline)]
        public static implicit operator byte(X80 src) => 0x80;

        public Hex8Seq Value => Hex8Seq.x80;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X81 : IHexType<X81>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X81 src) => Hex8Seq.x81;

        [MethodImpl(Inline)]
        public static implicit operator byte(X81 src) => 0x81;

        public Hex8Seq Value => Hex8Seq.x81;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X82 : IHexType<X82>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X82 src) => Hex8Seq.x82;

        [MethodImpl(Inline)]
        public static implicit operator byte(X82 src) => 0x82;

        public Hex8Seq Value => Hex8Seq.x82;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X83 : IHexType<X83>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X83 src) => Hex8Seq.x83;

        [MethodImpl(Inline)]
        public static implicit operator byte(X83 src) => 0x83;

        public Hex8Seq Value => Hex8Seq.x83;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X84 : IHexType<X84>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X84 src) => Hex8Seq.x84;

        [MethodImpl(Inline)]
        public static implicit operator byte(X84 src) => 0x84;

        public Hex8Seq Value => Hex8Seq.x84;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X85 : IHexType<X85>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X85 src) => Hex8Seq.x85;

        [MethodImpl(Inline)]
        public static implicit operator byte(X85 src) => 0x85;

        public Hex8Seq Value => Hex8Seq.x85;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X86 : IHexType<X86>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X86 src) => Hex8Seq.x86;

        [MethodImpl(Inline)]
        public static implicit operator byte(X86 src) => 0x86;

        public Hex8Seq Value => Hex8Seq.x86;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X87 : IHexType<X87>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X87 src) => Hex8Seq.x87;

        [MethodImpl(Inline)]
        public static implicit operator byte(X87 src) => 0x87;

        public Hex8Seq Value => Hex8Seq.x87;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X88 : IHexType<X88>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X88 src) => Hex8Seq.x88;

        [MethodImpl(Inline)]
        public static implicit operator byte(X88 src) => 0x88;

        public Hex8Seq Value => Hex8Seq.x88;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X89 : IHexType<X89>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X89 src) => Hex8Seq.x89;

        [MethodImpl(Inline)]
        public static implicit operator byte(X89 src) => 0x89;

        public Hex8Seq Value => Hex8Seq.x89;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X8A : IHexType<X8A>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X8A src) => Hex8Seq.x8a;

        [MethodImpl(Inline)]
        public static implicit operator byte(X8A src) => 0x8a;

        public Hex8Seq Value => Hex8Seq.x8a;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X8B : IHexType<X8B>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X8B src) => Hex8Seq.x8b;

        [MethodImpl(Inline)]
        public static implicit operator byte(X8B src) => 0x8b;

        public Hex8Seq Value => Hex8Seq.x8b;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X8C : IHexType<X8C>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X8C src) => Hex8Seq.x8c;

        [MethodImpl(Inline)]
        public static implicit operator byte(X8C src) => 0x8c;

        public Hex8Seq Value => Hex8Seq.x8c;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X8D : IHexType<X8D>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X8D src) => Hex8Seq.x8d;

        [MethodImpl(Inline)]
        public static implicit operator byte(X8D src) => 0x8d;

        public Hex8Seq Value => Hex8Seq.x8d;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X8E : IHexType<X8E>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X8E src) => Hex8Seq.x8e;

        [MethodImpl(Inline)]
        public static implicit operator byte(X8E src) => 0x8e;

        public Hex8Seq Value => Hex8Seq.x8e;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X8F : IHexType<X8F>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X8F src) => Hex8Seq.x8f;

        [MethodImpl(Inline)]
        public static implicit operator byte(X8F src) => 0x8f;

        public Hex8Seq Value => Hex8Seq.x8f;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X90 : IHexType<X90>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X90 src) => Hex8Seq.x90;

        [MethodImpl(Inline)]
        public static implicit operator byte(X90 src) => 0x90;

        public Hex8Seq Value => Hex8Seq.x90;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X91 : IHexType<X91>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X91 src) => Hex8Seq.x91;

        [MethodImpl(Inline)]
        public static implicit operator byte(X91 src) => 0x91;

        public Hex8Seq Value => Hex8Seq.x91;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X92 : IHexType<X92>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X92 src) => Hex8Seq.x92;

        [MethodImpl(Inline)]
        public static implicit operator byte(X92 src) => 0x92;

        public Hex8Seq Value => Hex8Seq.x92;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X93 : IHexType<X93>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X93 src) => Hex8Seq.x93;

        [MethodImpl(Inline)]
        public static implicit operator byte(X93 src) => 0x93;

        public Hex8Seq Value => Hex8Seq.x93;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X94 : IHexType<X94>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X94 src) => Hex8Seq.x94;

        [MethodImpl(Inline)]
        public static implicit operator byte(X94 src) => 0x94;

        public Hex8Seq Value => Hex8Seq.x94;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X95 : IHexType<X95>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X95 src) => Hex8Seq.x95;

        [MethodImpl(Inline)]
        public static implicit operator byte(X95 src) => 0x95;

        public Hex8Seq Value => Hex8Seq.x95;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X96 : IHexType<X96>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X96 src) => Hex8Seq.x96;

        [MethodImpl(Inline)]
        public static implicit operator byte(X96 src) => 0x96;

        public Hex8Seq Value => Hex8Seq.x96;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X97 : IHexType<X97>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X97 src) => Hex8Seq.x97;

        [MethodImpl(Inline)]
        public static implicit operator byte(X97 src) => 0x97;

        public Hex8Seq Value => Hex8Seq.x97;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X98 : IHexType<X98>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X98 src) => Hex8Seq.x98;

        [MethodImpl(Inline)]
        public static implicit operator byte(X98 src) => 0x98;

        public Hex8Seq Value => Hex8Seq.x98;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X99 : IHexType<X99>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X99 src) => Hex8Seq.x99;

        [MethodImpl(Inline)]
        public static implicit operator byte(X99 src) => 0x99;

        public Hex8Seq Value => Hex8Seq.x99;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X9A : IHexType<X9A>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X9A src) => Hex8Seq.x9a;

        [MethodImpl(Inline)]
        public static implicit operator byte(X9A src) => 0x9a;

        public Hex8Seq Value => Hex8Seq.x9a;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X9B : IHexType<X9B>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X9B src) => Hex8Seq.x9b;

        [MethodImpl(Inline)]
        public static implicit operator byte(X9B src) => 0x9b;

        public Hex8Seq Value => Hex8Seq.x9b;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X9C : IHexType<X9C>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X9C src) => Hex8Seq.x9c;

        [MethodImpl(Inline)]
        public static implicit operator byte(X9C src) => 0x9c;

        public Hex8Seq Value => Hex8Seq.x9c;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X9D : IHexType<X9D>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X9D src) => Hex8Seq.x9d;

        [MethodImpl(Inline)]
        public static implicit operator byte(X9D src) => 0x9d;

        public Hex8Seq Value => Hex8Seq.x9d;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X9E : IHexType<X9E>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X9E src) => Hex8Seq.x9e;

        [MethodImpl(Inline)]
        public static implicit operator byte(X9E src) => 0x9e;

        public Hex8Seq Value => Hex8Seq.x9e;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct X9F : IHexType<X9F>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(X9F src) => Hex8Seq.x9f;

        [MethodImpl(Inline)]
        public static implicit operator byte(X9F src) => 0x9f;

        public Hex8Seq Value => Hex8Seq.x9f;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XA0 : IHexType<XA0>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XA0 src) => Hex8Seq.xa0;

        [MethodImpl(Inline)]
        public static implicit operator byte(XA0 src) => 0xa0;

        public Hex8Seq Value => Hex8Seq.xa0;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XA1 : IHexType<XA1>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XA1 src) => Hex8Seq.xa1;

        [MethodImpl(Inline)]
        public static implicit operator byte(XA1 src) => 0xa1;

        public Hex8Seq Value => Hex8Seq.xa1;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XA2 : IHexType<XA2>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XA2 src) => Hex8Seq.xa2;

        [MethodImpl(Inline)]
        public static implicit operator byte(XA2 src) => 0xa2;

        public Hex8Seq Value => Hex8Seq.xa2;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XA3 : IHexType<XA3>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XA3 src) => Hex8Seq.xa3;

        [MethodImpl(Inline)]
        public static implicit operator byte(XA3 src) => 0xa3;

        public Hex8Seq Value => Hex8Seq.xa3;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XA4 : IHexType<XA4>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XA4 src) => Hex8Seq.xa4;

        [MethodImpl(Inline)]
        public static implicit operator byte(XA4 src) => 0xa4;

        public Hex8Seq Value => Hex8Seq.xa4;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XA5 : IHexType<XA5>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XA5 src) => Hex8Seq.xa5;

        [MethodImpl(Inline)]
        public static implicit operator byte(XA5 src) => 0xa5;

        public Hex8Seq Value => Hex8Seq.xa5;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XA6 : IHexType<XA6>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XA6 src) => Hex8Seq.xa6;

        [MethodImpl(Inline)]
        public static implicit operator byte(XA6 src) => 0xa6;

        public Hex8Seq Value => Hex8Seq.xa6;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XA7 : IHexType<XA7>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XA7 src) => Hex8Seq.xa7;

        [MethodImpl(Inline)]
        public static implicit operator byte(XA7 src) => 0xa7;

        public Hex8Seq Value => Hex8Seq.xa7;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XA8 : IHexType<XA8>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XA8 src) => Hex8Seq.xa8;

        [MethodImpl(Inline)]
        public static implicit operator byte(XA8 src) => 0xa8;

        public Hex8Seq Value => Hex8Seq.xa8;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XA9 : IHexType<XA9>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XA9 src) => Hex8Seq.xa9;

        [MethodImpl(Inline)]
        public static implicit operator byte(XA9 src) => 0xa9;

        public Hex8Seq Value => Hex8Seq.xa9;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XAA : IHexType<XAA>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XAA src) => Hex8Seq.xaa;

        [MethodImpl(Inline)]
        public static implicit operator byte(XAA src) => 0xaa;

        public Hex8Seq Value => Hex8Seq.xaa;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XAB : IHexType<XAB>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XAB src) => Hex8Seq.xab;

        [MethodImpl(Inline)]
        public static implicit operator byte(XAB src) => 0xab;

        public Hex8Seq Value => Hex8Seq.xab;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XAC : IHexType<XAC>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XAC src) => Hex8Seq.xac;

        [MethodImpl(Inline)]
        public static implicit operator byte(XAC src) => 0xac;

        public Hex8Seq Value => Hex8Seq.xac;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XAD : IHexType<XAD>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XAD src) => Hex8Seq.xad;

        [MethodImpl(Inline)]
        public static implicit operator byte(XAD src) => 0xad;

        public Hex8Seq Value => Hex8Seq.xad;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XAE : IHexType<XAE>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XAE src) => Hex8Seq.xae;

        [MethodImpl(Inline)]
        public static implicit operator byte(XAE src) => 0xae;

        public Hex8Seq Value => Hex8Seq.xae;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XAF : IHexType<XAF>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XAF src) => Hex8Seq.xaf;

        [MethodImpl(Inline)]
        public static implicit operator byte(XAF src) => 0xaf;

        public Hex8Seq Value => Hex8Seq.xaf;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XB0 : IHexType<XB0>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XB0 src) => Hex8Seq.xb0;

        [MethodImpl(Inline)]
        public static implicit operator byte(XB0 src) => 0xb0;

        public Hex8Seq Value => Hex8Seq.xb0;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XB1 : IHexType<XB1>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XB1 src) => Hex8Seq.xb1;

        [MethodImpl(Inline)]
        public static implicit operator byte(XB1 src) => 0xb1;

        public Hex8Seq Value => Hex8Seq.xb1;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XB2 : IHexType<XB2>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XB2 src) => Hex8Seq.xb2;

        [MethodImpl(Inline)]
        public static implicit operator byte(XB2 src) => 0xb2;

        public Hex8Seq Value => Hex8Seq.xb2;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XB3 : IHexType<XB3>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XB3 src) => Hex8Seq.xb3;

        [MethodImpl(Inline)]
        public static implicit operator byte(XB3 src) => 0xb3;

        public Hex8Seq Value => Hex8Seq.xb3;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XB4 : IHexType<XB4>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XB4 src) => Hex8Seq.xb4;

        [MethodImpl(Inline)]
        public static implicit operator byte(XB4 src) => 0xb4;

        public Hex8Seq Value => Hex8Seq.xb4;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XB5 : IHexType<XB5>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XB5 src) => Hex8Seq.xb5;

        [MethodImpl(Inline)]
        public static implicit operator byte(XB5 src) => 0xb5;

        public Hex8Seq Value => Hex8Seq.xb5;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XB6 : IHexType<XB6>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XB6 src) => Hex8Seq.xb6;

        [MethodImpl(Inline)]
        public static implicit operator byte(XB6 src) => 0xb6;

        public Hex8Seq Value => Hex8Seq.xb6;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XB7 : IHexType<XB7>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XB7 src) => Hex8Seq.xb7;

        [MethodImpl(Inline)]
        public static implicit operator byte(XB7 src) => 0xb7;

        public Hex8Seq Value => Hex8Seq.xb7;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XB8 : IHexType<XB8>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XB8 src) => Hex8Seq.xb8;

        [MethodImpl(Inline)]
        public static implicit operator byte(XB8 src) => 0xb8;

        public Hex8Seq Value => Hex8Seq.xb8;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XB9 : IHexType<XB9>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XB9 src) => Hex8Seq.xb9;

        [MethodImpl(Inline)]
        public static implicit operator byte(XB9 src) => 0xb9;

        public Hex8Seq Value => Hex8Seq.xb9;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XBA : IHexType<XBA>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XBA src) => Hex8Seq.xba;

        [MethodImpl(Inline)]
        public static implicit operator byte(XBA src) => 0xba;

        public Hex8Seq Value => Hex8Seq.xba;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XBB : IHexType<XBB>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XBB src) => Hex8Seq.xbb;

        [MethodImpl(Inline)]
        public static implicit operator byte(XBB src) => 0xbb;

        public Hex8Seq Value => Hex8Seq.xbb;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XBC : IHexType<XBC>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XBC src) => Hex8Seq.xbc;

        [MethodImpl(Inline)]
        public static implicit operator byte(XBC src) => 0xbc;

        public Hex8Seq Value => Hex8Seq.xbc;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XBD : IHexType<XBD>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XBD src) => Hex8Seq.xbd;

        [MethodImpl(Inline)]
        public static implicit operator byte(XBD src) => 0xbd;

        public Hex8Seq Value => Hex8Seq.xbd;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XBE : IHexType<XBE>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XBE src) => Hex8Seq.xbe;

        [MethodImpl(Inline)]
        public static implicit operator byte(XBE src) => 0xbe;

        public Hex8Seq Value => Hex8Seq.xbe;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XBF : IHexType<XBF>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XBF src) => Hex8Seq.xbf;

        [MethodImpl(Inline)]
        public static implicit operator byte(XBF src) => 0xbf;

        public Hex8Seq Value => Hex8Seq.xbf;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XC0 : IHexType<XC0>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XC0 src) => Hex8Seq.xc0;

        [MethodImpl(Inline)]
        public static implicit operator byte(XC0 src) => 0xc0;

        public Hex8Seq Value => Hex8Seq.xc0;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XC1 : IHexType<XC1>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XC1 src) => Hex8Seq.xc1;

        [MethodImpl(Inline)]
        public static implicit operator byte(XC1 src) => 0xc1;

        public Hex8Seq Value => Hex8Seq.xc1;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XC2 : IHexType<XC2>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XC2 src) => Hex8Seq.xc2;

        [MethodImpl(Inline)]
        public static implicit operator byte(XC2 src) => 0xc2;

        public Hex8Seq Value => Hex8Seq.xc2;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XC3 : IHexType<XC3>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XC3 src) => Hex8Seq.xc3;

        [MethodImpl(Inline)]
        public static implicit operator byte(XC3 src) => 0xc3;

        public Hex8Seq Value => Hex8Seq.xc3;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XC4 : IHexType<XC4>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XC4 src) => Hex8Seq.xc4;

        [MethodImpl(Inline)]
        public static implicit operator byte(XC4 src) => 0xc4;

        public Hex8Seq Value => Hex8Seq.xc4;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XC5 : IHexType<XC5>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XC5 src) => Hex8Seq.xc5;

        [MethodImpl(Inline)]
        public static implicit operator byte(XC5 src) => 0xc5;

        public Hex8Seq Value => Hex8Seq.xc5;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XC6 : IHexType<XC6>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XC6 src) => Hex8Seq.xc6;

        [MethodImpl(Inline)]
        public static implicit operator byte(XC6 src) => 0xc6;

        public Hex8Seq Value => Hex8Seq.xc6;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XC7 : IHexType<XC7>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XC7 src) => Hex8Seq.xc7;

        [MethodImpl(Inline)]
        public static implicit operator byte(XC7 src) => 0xc7;

        public Hex8Seq Value => Hex8Seq.xc7;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XC8 : IHexType<XC8>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XC8 src) => Hex8Seq.xc8;

        [MethodImpl(Inline)]
        public static implicit operator byte(XC8 src) => 0xc8;

        public Hex8Seq Value => Hex8Seq.xc8;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XC9 : IHexType<XC9>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XC9 src) => Hex8Seq.xc9;

        [MethodImpl(Inline)]
        public static implicit operator byte(XC9 src) => 0xc9;

        public Hex8Seq Value => Hex8Seq.xc9;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XCA : IHexType<XCA>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XCA src) => Hex8Seq.xca;

        [MethodImpl(Inline)]
        public static implicit operator byte(XCA src) => 0xca;

        public Hex8Seq Value => Hex8Seq.xca;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XCB : IHexType<XCB>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XCB src) => Hex8Seq.xcb;

        [MethodImpl(Inline)]
        public static implicit operator byte(XCB src) => 0xcb;

        public Hex8Seq Value => Hex8Seq.xcb;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XCC : IHexType<XCC>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XCC src) => Hex8Seq.xcc;

        [MethodImpl(Inline)]
        public static implicit operator byte(XCC src) => 0xcc;

        public Hex8Seq Value => Hex8Seq.xcc;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XCD : IHexType<XCD>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XCD src) => Hex8Seq.xcd;

        [MethodImpl(Inline)]
        public static implicit operator byte(XCD src) => 0xcd;

        public Hex8Seq Value => Hex8Seq.xcd;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XCE : IHexType<XCE>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XCE src) => Hex8Seq.xce;

        [MethodImpl(Inline)]
        public static implicit operator byte(XCE src) => 0xce;

        public Hex8Seq Value => Hex8Seq.xce;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XCF : IHexType<XCF>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XCF src) => Hex8Seq.xcf;

        [MethodImpl(Inline)]
        public static implicit operator byte(XCF src) => 0xcf;

        public Hex8Seq Value => Hex8Seq.xcf;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XD0 : IHexType<XD0>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XD0 src) => Hex8Seq.xd0;

        [MethodImpl(Inline)]
        public static implicit operator byte(XD0 src) => 0xd0;

        public Hex8Seq Value => Hex8Seq.xd0;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XD1 : IHexType<XD1>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XD1 src) => Hex8Seq.xd1;

        [MethodImpl(Inline)]
        public static implicit operator byte(XD1 src) => 0xd1;

        public Hex8Seq Value => Hex8Seq.xd1;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XD2 : IHexType<XD2>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XD2 src) => Hex8Seq.xd2;

        [MethodImpl(Inline)]
        public static implicit operator byte(XD2 src) => 0xd2;

        public Hex8Seq Value => Hex8Seq.xd2;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XD3 : IHexType<XD3>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XD3 src) => Hex8Seq.xd3;

        [MethodImpl(Inline)]
        public static implicit operator byte(XD3 src) => 0xd3;

        public Hex8Seq Value => Hex8Seq.xd3;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XD4 : IHexType<XD4>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XD4 src) => Hex8Seq.xd4;

        [MethodImpl(Inline)]
        public static implicit operator byte(XD4 src) => 0xd4;

        public Hex8Seq Value => Hex8Seq.xd4;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XD5 : IHexType<XD5>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XD5 src) => Hex8Seq.xd5;

        [MethodImpl(Inline)]
        public static implicit operator byte(XD5 src) => 0xd5;

        public Hex8Seq Value => Hex8Seq.xd5;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XD6 : IHexType<XD6>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XD6 src) => Hex8Seq.xd6;

        [MethodImpl(Inline)]
        public static implicit operator byte(XD6 src) => 0xd6;

        public Hex8Seq Value => Hex8Seq.xd6;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XD7 : IHexType<XD7>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XD7 src) => Hex8Seq.xd7;

        [MethodImpl(Inline)]
        public static implicit operator byte(XD7 src) => 0xd7;

        public Hex8Seq Value => Hex8Seq.xd7;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XD8 : IHexType<XD8>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XD8 src) => Hex8Seq.xd8;

        [MethodImpl(Inline)]
        public static implicit operator byte(XD8 src) => 0xd8;

        public Hex8Seq Value => Hex8Seq.xd8;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XD9 : IHexType<XD9>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XD9 src) => Hex8Seq.xd9;

        [MethodImpl(Inline)]
        public static implicit operator byte(XD9 src) => 0xd9;

        public Hex8Seq Value => Hex8Seq.xd9;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XDA : IHexType<XDA>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XDA src) => Hex8Seq.xda;

        [MethodImpl(Inline)]
        public static implicit operator byte(XDA src) => 0xda;

        public Hex8Seq Value => Hex8Seq.xda;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XDB : IHexType<XDB>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XDB src) => Hex8Seq.xdb;

        [MethodImpl(Inline)]
        public static implicit operator byte(XDB src) => 0xdb;

        public Hex8Seq Value => Hex8Seq.xdb;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XDC : IHexType<XDC>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XDC src) => Hex8Seq.xdc;

        [MethodImpl(Inline)]
        public static implicit operator byte(XDC src) => 0xdc;

        public Hex8Seq Value => Hex8Seq.xdc;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XDD : IHexType<XDD>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XDD src) => Hex8Seq.xdd;

        [MethodImpl(Inline)]
        public static implicit operator byte(XDD src) => 0xdd;

        public Hex8Seq Value => Hex8Seq.xdd;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XDE : IHexType<XDE>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XDE src) => Hex8Seq.xde;

        [MethodImpl(Inline)]
        public static implicit operator byte(XDE src) => 0xde;

        public Hex8Seq Value => Hex8Seq.xde;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XDF : IHexType<XDF>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XDF src) => Hex8Seq.xdf;

        [MethodImpl(Inline)]
        public static implicit operator byte(XDF src) => 0xdf;

        public Hex8Seq Value => Hex8Seq.xdf;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XE0 : IHexType<XE0>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XE0 src) => Hex8Seq.xe0;

        [MethodImpl(Inline)]
        public static implicit operator byte(XE0 src) => 0xe0;

        public Hex8Seq Value => Hex8Seq.xe0;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XE1 : IHexType<XE1>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XE1 src) => Hex8Seq.xe1;

        [MethodImpl(Inline)]
        public static implicit operator byte(XE1 src) => 0xe1;

        public Hex8Seq Value => Hex8Seq.xe1;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XE2 : IHexType<XE2>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XE2 src) => Hex8Seq.xe2;

        [MethodImpl(Inline)]
        public static implicit operator byte(XE2 src) => 0xe2;

        public Hex8Seq Value => Hex8Seq.xe2;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XE3 : IHexType<XE3>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XE3 src) => Hex8Seq.xe3;

        [MethodImpl(Inline)]
        public static implicit operator byte(XE3 src) => 0xe3;

        public Hex8Seq Value => Hex8Seq.xe3;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XE4 : IHexType<XE4>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XE4 src) => Hex8Seq.xe4;

        [MethodImpl(Inline)]
        public static implicit operator byte(XE4 src) => 0xe4;

        public Hex8Seq Value => Hex8Seq.xe4;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XE5 : IHexType<XE5>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XE5 src) => Hex8Seq.xe5;

        [MethodImpl(Inline)]
        public static implicit operator byte(XE5 src) => 0xe5;

        public Hex8Seq Value => Hex8Seq.xe5;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XE6 : IHexType<XE6>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XE6 src) => Hex8Seq.xe6;

        [MethodImpl(Inline)]
        public static implicit operator byte(XE6 src) => 0xe6;

        public Hex8Seq Value => Hex8Seq.xe6;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XE7 : IHexType<XE7>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XE7 src) => Hex8Seq.xe7;

        [MethodImpl(Inline)]
        public static implicit operator byte(XE7 src) => 0xe7;

        public Hex8Seq Value => Hex8Seq.xe7;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XE8 : IHexType<XE8>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XE8 src) => Hex8Seq.xe8;

        [MethodImpl(Inline)]
        public static implicit operator byte(XE8 src) => 0xe8;

        public Hex8Seq Value => Hex8Seq.xe8;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XE9 : IHexType<XE9>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XE9 src) => Hex8Seq.xe9;

        [MethodImpl(Inline)]
        public static implicit operator byte(XE9 src) => 0xe9;

        public Hex8Seq Value => Hex8Seq.xe9;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XEA : IHexType<XEA>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XEA src) => Hex8Seq.xea;

        [MethodImpl(Inline)]
        public static implicit operator byte(XEA src) => 0xea;

        public Hex8Seq Value => Hex8Seq.xea;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XEB : IHexType<XEB>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XEB src) => Hex8Seq.xeb;

        [MethodImpl(Inline)]
        public static implicit operator byte(XEB src) => 0xeb;

        public Hex8Seq Value => Hex8Seq.xeb;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XEC : IHexType<XEC>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XEC src) => Hex8Seq.xec;

        [MethodImpl(Inline)]
        public static implicit operator byte(XEC src) => 0xec;

        public Hex8Seq Value => Hex8Seq.xec;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XED : IHexType<XED>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XED src) => Hex8Seq.xed;

        [MethodImpl(Inline)]
        public static implicit operator byte(XED src) => 0xed;

        public Hex8Seq Value => Hex8Seq.xed;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XEE : IHexType<XEE>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XEE src) => Hex8Seq.xee;

        [MethodImpl(Inline)]
        public static implicit operator byte(XEE src) => 0xee;

        public Hex8Seq Value => Hex8Seq.xee;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XEF : IHexType<XEF>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XEF src) => Hex8Seq.xef;

        [MethodImpl(Inline)]
        public static implicit operator byte(XEF src) => 0xef;

        public Hex8Seq Value => Hex8Seq.xef;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XF0 : IHexType<XF0>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XF0 src) => Hex8Seq.xf0;

        [MethodImpl(Inline)]
        public static implicit operator byte(XF0 src) => 0xf0;

        public Hex8Seq Value => Hex8Seq.xf0;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XF1 : IHexType<XF1>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XF1 src) => Hex8Seq.xf1;

        [MethodImpl(Inline)]
        public static implicit operator byte(XF1 src) => 0xf1;

        public Hex8Seq Value => Hex8Seq.xf1;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XF2 : IHexType<XF2>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XF2 src) => Hex8Seq.xf2;

        [MethodImpl(Inline)]
        public static implicit operator byte(XF2 src) => 0xf2;

        public Hex8Seq Value => Hex8Seq.xf2;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XF3 : IHexType<XF3>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XF3 src) => Hex8Seq.xf3;

        [MethodImpl(Inline)]
        public static implicit operator byte(XF3 src) => 0xf3;

        public Hex8Seq Value => Hex8Seq.xf3;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XF4 : IHexType<XF4>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XF4 src) => Hex8Seq.xf4;

        [MethodImpl(Inline)]
        public static implicit operator byte(XF4 src) => 0xf4;

        public Hex8Seq Value => Hex8Seq.xf4;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XF5 : IHexType<XF5>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XF5 src) => Hex8Seq.xf5;

        [MethodImpl(Inline)]
        public static implicit operator byte(XF5 src) => 0xf5;

        public Hex8Seq Value => Hex8Seq.xf5;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XF6 : IHexType<XF6>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XF6 src) => Hex8Seq.xf6;

        [MethodImpl(Inline)]
        public static implicit operator byte(XF6 src) => 0xf6;

        public Hex8Seq Value => Hex8Seq.xf6;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XF7 : IHexType<XF7>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XF7 src) => Hex8Seq.xf7;

        [MethodImpl(Inline)]
        public static implicit operator byte(XF7 src) => 0xf7;

        public Hex8Seq Value => Hex8Seq.xf7;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XF8 : IHexType<XF8>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XF8 src) => Hex8Seq.xf8;

        [MethodImpl(Inline)]
        public static implicit operator byte(XF8 src) => 0xf8;

        public Hex8Seq Value => Hex8Seq.xf8;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XF9 : IHexType<XF9>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XF9 src) => Hex8Seq.xf9;

        [MethodImpl(Inline)]
        public static implicit operator byte(XF9 src) => 0xf9;

        public Hex8Seq Value => Hex8Seq.xf9;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XFA : IHexType<XFA>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XFA src) => Hex8Seq.xfa;

        [MethodImpl(Inline)]
        public static implicit operator byte(XFA src) => 0xfa;

        public Hex8Seq Value => Hex8Seq.xfa;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XFB : IHexType<XFB>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XFB src) => Hex8Seq.xfb;

        [MethodImpl(Inline)]
        public static implicit operator byte(XFB src) => 0xfb;

        public Hex8Seq Value => Hex8Seq.xfb;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XFC : IHexType<XFC>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XFC src) => Hex8Seq.xfc;

        [MethodImpl(Inline)]
        public static implicit operator byte(XFC src) => 0xfc;

        public Hex8Seq Value => Hex8Seq.xfc;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XFD : IHexType<XFD>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XFD src) => Hex8Seq.xfd;

        [MethodImpl(Inline)]
        public static implicit operator byte(XFD src) => 0xfd;

        public Hex8Seq Value => Hex8Seq.xfd;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XFE : IHexType<XFE>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XFE src) => Hex8Seq.xfe;

        [MethodImpl(Inline)]
        public static implicit operator byte(XFE src) => 0xfe;

        public Hex8Seq Value => Hex8Seq.xfe;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }

    public readonly struct XFF : IHexType<XFF>, ITextual
    {
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(XFF src) => Hex8Seq.xff;

        [MethodImpl(Inline)]
        public static implicit operator byte(XFF src) => 0xff;

        public Hex8Seq Value => Hex8Seq.xff;

        public string Format() => $"{Value}";

        public override string ToString() => Format();
    }
}
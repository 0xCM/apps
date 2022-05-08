//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [DataWidth(4)]
        public readonly record struct WidthVar
        {
            public static bool parse(string src, out FieldKind field, out WidthVar v)
            {
                field = 0;
                v = Empty;
                var i = text.index(src,Chars.LBracket);
                var j = text.index(src,Chars.RBracket);
                if(i > 0 && j > i)
                {
                    XedParsers.parse(text.left(src,i), out field);
                    parse(text.inside(src,i,j), out v);
                }
                return field != 0 && v.IsNonEmpty;
            }

            public static bool parse(string src, out WidthVar dst)
            {
                const byte DK = (byte)Kind.Disp;
                const byte AD = (byte)Kind.MemDisp;
                const byte IM = (byte)Kind.Imm;
                dst = Empty;
                switch(src)
                {
                    case "d/8":
                        dst = new (DK,0);
                        break;
                    case "d/16":
                        dst = new (DK,1);
                        break;
                    case "d/32":
                        dst = new (DK,2);
                        break;
                    case "d/64":
                        dst = new (DK,3);
                        break;
                    case "a/8":
                        dst = new (AD,0);
                    break;
                    case "a/16":
                        dst = new (AD,1);
                    break;
                    case "a/32":
                        dst = new (AD,2);
                    break;
                    case "a/64":
                        dst = new (AD,3);
                    break;
                    case "i/8":
                        dst = new (IM,0);
                    break;
                    case "i/16":
                        dst = new (IM,1);
                    break;
                    case "i/32":
                        dst = new (IM,2);
                    break;
                    case "i/64":
                        dst = new (IM,3);
                    break;
                }

                return dst.IsNonEmpty;
            }

            readonly num4 Data;

            [MethodImpl(Inline)]
            WidthVar(num2 kind, num2 width)
            {
                Data = num.pack(kind,width);
            }

            [MethodImpl(Inline)]
            public WidthVar(Kind kind, Width width)
            {
                Data = num.pack((num2)(byte)kind, (num2)Pow2.log((byte)((byte)width/8)));
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Data == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Data != 0;
            }

            public Kind Sort
            {
                [MethodImpl(Inline)]
                get => (Kind)(byte)(num2)Data;
            }

            public Width Value
            {
                [MethodImpl(Inline)]
                get => (Width)(Pow2.pow(Data >> 2) *8);
            }

            public override int GetHashCode()
                => Data;

            [MethodImpl(Inline)]
            public bool Equals(WidthVar src)
                => Data == src.Data;

            public string Format()
            {
                var dst = EmptyString;
                switch(Sort)
                {
                    case Kind.Disp:
                        switch(Value)
                        {
                            case Width.W8:
                                dst = "d/8";
                            break;
                            case Width.W16:
                                dst = "d/16";
                            break;
                            case Width.W32:
                                dst = "d/32";
                            break;
                            case Width.W64:
                                dst = "d/64";
                            break;
                        }
                    break;
                    case Kind.MemDisp:
                        switch(Value)
                        {
                            case Width.W8:
                                dst = "a/8";
                            break;
                            case Width.W16:
                                dst = "a/16";
                            break;
                            case Width.W32:
                                dst = "a/32";
                            break;
                            case Width.W64:
                                dst = "a/64";
                            break;
                        }
                    break;
                    case Kind.Imm:
                        switch(Value)
                        {
                            case Width.W8:
                                dst = "i/8";
                            break;
                            case Width.W16:
                                dst = "i/16";
                            break;
                            case Width.W32:
                                dst = "i/32";
                            break;
                            case Width.W64:
                                dst = "i/64";
                            break;
                        }
                    break;
                }
                return dst;
            }

            public override string ToString()
                => Format();

            public static WidthVar Empty => default;


            [DataWidth(num2.Width)]
            public enum Kind : byte
            {
                None = 0,

                /// <summary>
                /// d/8, d/16, d/32, d/64
                /// </summary>
                Disp,

                /// <summary>
                /// a/8, a/16, a/32, a/64
                /// </summary>
                MemDisp,

                /// <summary>
                /// i/8, i/16, i/32, i/64
                /// </summary>
                Imm,
            }

            [DataWidth(num2.Width)]
            public enum Width : byte
            {
                W8 = 8,

                W16 = 16,

                W32 = 32,

                W64 = 64
            }
        }
    }
}
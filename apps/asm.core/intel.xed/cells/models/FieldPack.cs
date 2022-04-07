//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedPatterns;

    using K = XedRules.FieldDataType;


    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public struct FieldPack
        {
            public static FieldPack unpack(uint src)
            {
                var value = (ushort)src;
                var kind = (FieldDataType)(src >> 24);
                var field = (FieldKind)((src >> 16) & 0xFF);
                var dst = default(FieldPack);
                dst.Field = field;
                switch(kind)
                {
                    case K.Bit:
                        dst.Bit = (bit)value;
                    break;
                    case K.Byte:
                        dst.Byte = (byte)value;
                    break;
                    case K.Chip:
                        dst.Chip = (ChipCode)value;
                    break;
                    case K.InstClass:
                        dst.Class = (InstClass)value;
                    break;
                    case K.Reg:
                        dst.Reg = (Register)value;
                    break;
                    case K.Word:
                        dst.Word = (ushort)value;
                    break;
                }
                return dst;
            }

            public FieldKind Field;

            public bit Bit;

            public byte Byte;

            public ushort Word;

            public Register Reg;

            public BCastKind BCast;

            public ChipCode Chip;

            public InstClass Class;


            FieldDataType Kind()
            {
                var dst = K.Bit;
                if(Class.IsNonEmpty)
                    dst = K.InstClass;
                else if(Chip != 0)
                    dst = K.Chip;
                else if(BCast != 0)
                    dst = K.BCast;
                else if(Reg.IsNonEmpty)
                    dst = K.Reg;
                else if(Word !=0)
                    dst = K.Word;
                else if(Byte !=0)
                    dst = K.Byte;
                return dst;
            }

            ushort PackData()
            {
                var dst = z16;
                var kind = Kind();
                switch(kind)
                {
                    case K.Bit:
                        dst = (byte)Bit;
                    break;
                    case K.Byte:
                        dst = Byte;
                    break;
                    case K.Chip:
                        dst = (byte)Chip;
                    break;
                    case K.InstClass:
                        dst = (ushort)Class;
                    break;
                    case K.Reg:
                        dst = (ushort)Reg;
                    break;
                    case K.Word:
                        dst = Word;
                    break;
                }
                return dst;
            }

            public uint Pack()
                => Bitfields.join(PackData(), Bitfields.join((byte)Field, (byte)Kind()));

            public string Format()
            {
                var dst = EmptyString;
                switch(Kind())
                {
                    case K.Bit:
                        dst = Bit.ToString();
                    break;
                    case K.Byte:
                        dst = Byte.ToString();
                    break;
                    case K.Chip:
                        dst = XedRender.format(Chip);
                    break;
                    case K.InstClass:
                        dst = XedRender.format(Class);
                    break;
                    case K.Reg:
                        dst = XedRender.format(Reg);
                    break;
                    case K.Word:
                        dst = Word.ToString();
                    break;
                }
                return dst;
            }

            public override string ToString()
                => Format();
        }
    }
}
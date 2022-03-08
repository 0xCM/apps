//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules.FieldDataKind;

    using K = XedRules.FieldDataKind;

    partial class XedRules
    {
        [Op]
        public static FieldDataType datatype(FieldKind field)
            => datatype(datakind(field));

        [Op]
        public static FieldDataType datatype(FieldDataKind kind)
        {
            var dst = FieldDataType.Empty;
            var width = z16;
            switch(kind)
            {
                case B1:
                    width = 1;
                    break;

                case U2:
                case B2:
                    width = 2;
                    break;

                case X3:
                case U3:
                case B3:
                    width = 3;
                    break;

                case X4:
                case U4:
                case B4:
                    width = 4;
                    break;

                case U5:
                case B5:
                case Broadcast:
                    width = 5;
                    break;

                case B6:
                    width = 6;
                    break;

                case B7:
                    width = 7;
                    break;

                case InstClass:
                case X8:
                case K.Imm8:
                case U8:
                case B8:
                case K.Error:
                    width = 8;
                    break;

                case MemWidth:
                case Chip:
                case Reg:
                case U16:
                    width = 16;
                    break;

                case Disp:
                case U64:
                case K.Imm64:
                    width = 64;
                    break;

            }

            return new FieldDataType(kind,width);
        }
    }
}
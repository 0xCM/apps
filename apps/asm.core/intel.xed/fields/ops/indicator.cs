//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using K = XedModels.ElementKind;

    partial struct XedModels
    {
        public static NumericIndicator indicator(ElementType src)
        {
            var result = NumericIndicator.None;
            switch(src.Kind)
            {
                case K.BF16:
                case K.F16:
                case K.F32:
                case K.F64:
                case K.F80:
                    result = NumericIndicator.Float;
                    break;

                case K.I1:
                case K.I16:
                case K.I32:
                case K.I64:
                case K.I8:
                case K.INT:
                    result = NumericIndicator.Signed;
                    break;

                case K.U128:
                case K.U16:
                case K.U256:
                case K.U32:
                case K.U64:
                case K.U8:
                case K.UINT:
                    result = NumericIndicator.Unsigned;
                    break;
            }
            return result;
        }
    }
}
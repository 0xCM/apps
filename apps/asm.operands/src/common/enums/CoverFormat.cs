//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using M = EnumFormatMode;

    public readonly struct CoverFormat
    {
        public static string format<E>(CoverFormat<E> src)
            where E : unmanaged, Enum
        {
            var ez = (src.Mode & M.EmptyZero) != 0;
            var dst = EmptyString;
            if(ez && src.Source.Scalar == 0)
                dst = EmptyString;
            else
            {
                var kind = (M)((byte)src.Mode & 0b111);
                switch(kind)
                {
                    case M.Name:
                        dst = src.Source.Expr;
                    break;
                    case M.Identifier:
                        dst = src.Source.Name;
                    break;
                    case M.Scalar:
                        dst = src.Source.Scalar.ToString();
                    break;
                    default:
                        dst = src.Source.Expr;
                    break;
                }
            }
            return dst;
        }

        public static string format<E,T>(CoverFormat<E,T> src)
            where E : unmanaged, Enum
            where T : unmanaged
        {
            var ez = (src.Mode & M.EmptyZero) != 0;
            var dst = EmptyString;
            if(ez && core.bw64(src.Source.Scalar) == 0)
                dst = EmptyString;
            else
            {
                var kind = (M)((byte)src.Mode & 0b111);
                switch(kind)
                {
                    case M.Name:
                        dst = src.Source.Expr;
                    break;
                    case M.Identifier:
                        dst = src.Source.Name;
                    break;
                    case M.Scalar:
                        dst = src.Source.Scalar.ToString();
                    break;
                    default:
                        dst = src.Source.Expr;
                    break;
                }
            }
            return dst;
        }
    }
}
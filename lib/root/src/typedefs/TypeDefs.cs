//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static Root;

    [ApiHost]
    public readonly partial struct Typedefs
    {
        public static Utf16StringType<N> utf16<N>()
            where N : unmanaged, ITypeNat
                => default;

        public static Utf8StringType<N> utf8<N>()
            where N : unmanaged, ITypeNat
                => default;

        public static Utf8StringType<N> asci<N>()
            where N : unmanaged, ITypeNat
                => default;

        public static Utf16StringType utf16()
            => default;

        public static Utf8StringType utf8()
            => default;

        public static Utf8StringType asci()
            => default;

        public static UInt8Type uint8()
            => default;

        public static UInt16Type uint16()
            => default;

        public static UInt32Type uint32()
            => default;

        public static UInt64Type uint64()
            => default;

        public static Int8Type int8()
            => default;

        public static Int16Type int16()
            => default;

        public static Int32Type int32()
            => default;

        public static Int64Type int64()
            => default;

        public static Outcome parse(string src, out ITypeDef dst)
        {
            dst = TypeDef.Empty;
            var result = Outcome.Failure;
            var name = text.trim(src);
            var args = EmptyString;
            var i = text.index(name, Chars.Lt);
            var j = text.index(name, Chars.Gt);
            if(i>0 && j>0 && i<j)
            {
                name = text.left(name,i);
                args = text.inside(name,i,j);
            }
            else if(i > 0 || j > 0)
                return result;

            return result;
        }
    }
}
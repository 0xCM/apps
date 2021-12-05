//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using F = NumericFormats;

    using NK = ClrEnumCode;

    partial struct Enums
    {
        public static string format<E>(E src, Base2 n, int? digits = null)
            where E : unmanaged, Enum
                => ecode<E>() switch {
                    NK.U8 => F.format(e8u(src), n, digits),
                    NK.I8 => F.format(e8i(src), n, digits),
                    NK.I16 => F.format(e16i(src), n, digits),
                    NK.U16 => F.format(e16u(src), n, digits),
                    NK.I32 => F.Format(e32i(src), n, digits),
                    NK.U32 => F.Format(e32u(src), n, digits),
                    NK.I64 => F.Format(e64i(src), n, digits),
                    NK.U64 => F.Format(e64u(src), n, digits),
                    _ => src.ToString(),
                };

        public static string format<E>(E src, Base8 n)
            where E : unmanaged, Enum
                => ecode<E>() switch {
                    NK.U8 => F.format(e8u(src), n),
                    NK.I8 => F.format(e8i(src), n),
                    NK.I16 => F.Format(e16i(src), n),
                    NK.U16 => F.Format(e16u(src), n),
                    NK.I32 => F.Format(e32i(src), n),
                    NK.U32 => F.Format(e32u(src), n),
                    NK.I64 => F.Format(e64i(src), n),
                    NK.U64 => F.Format(e64u(src), n),
                    _ => src.ToString(),
                };

        public static string format<E>(E src, Base16 n, int? digits = null)
            where E : unmanaged, Enum
                => ecode<E>() switch {
                    NK.U8 => F.Format(e8u(src), n, digits),
                    NK.I8 => F.format(e8i(src), n, digits),
                    NK.I16 => F.Format(e16i(src), n, digits),
                    NK.U16 => F.Format(e16u(src), n, digits),
                    NK.I32 => F.Format(e32i(src), n, digits),
                    NK.U32 => F.Format(e32u(src), n, digits),
                    NK.I64 => F.Format(e64i(src), n, digits),
                    NK.U64 => F.Format(e64u(src), n, digits),
                    _ => src.ToString(),
                };

        public static string format<E>(E src, Base10 b, int? digits = null)
            where E : unmanaged, Enum
                => ecode<E>() switch {
                    NK.U8 => F.Format(e8u(src), b, digits),
                    NK.I8 => F.format(e8i(src), b, digits),
                    NK.I16 => F.Format(e16i(src), b, digits),
                    NK.U16 => F.Format(e16u(src), b, digits),
                    NK.I32 => F.Format(e32i(src), b, digits),
                    NK.U32 => F.Format(e32u(src), b, digits),
                    NK.I64 => F.Format(e64i(src), b, digits),
                    NK.U64 => F.Format(e64u(src), b, digits),
                    _ => src.ToString(),
                };

        public static string format<E>(E src, NumericBaseKind b, int? digits = null)
            where E : unmanaged, Enum
                => ecode<E>() switch {
                    NK.U8 => F.Format(e8u(src), b, digits),
                    NK.I8 => F.format(e8i(src), b, digits),
                    NK.I16 => F.Format(e16i(src), b, digits),
                    NK.U16 => F.Format(e16u(src), b, digits),
                    NK.I32 => F.Format(e32i(src), b, digits),
                    NK.U32 => F.Format(e32u(src), b, digits),
                    NK.I64 => F.Format(e64i(src), b, digits),
                    NK.U64 => F.Format(e64u(src), b, digits),
                    _ => src.ToString(),
                };
    }
}
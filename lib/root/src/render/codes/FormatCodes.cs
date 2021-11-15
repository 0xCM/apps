//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    [ApiHost]
    public readonly struct FormatCodes
    {
        const string OpenSlot = "{0:";

        const string CloseSlot = "}";

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static FormatCode<FormatCodeKind,C> define<C>(FormatCodeKind kind, C code)
            => (kind,code);

        [MethodImpl(Inline), Op]
        public static FormatCode<FormatCodeKind,char> define(FormatCodeKind kind, char code)
            => (kind,code);

        [MethodImpl(Inline), Op]
        public static FormatCode<FormatCodeKind,string> define(FormatCodeKind kind, string code)
            => (kind,code);

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static FormatCode<object> untyped<C>(in FormatCode<C> src)
            => new FormatCode<object>(src.Kind, src.Code);

        [Op, Closures(AllNumeric)]
        public static string slot<C>(C code)
            => string.Concat(OpenSlot, code.ToString() ?? "g",  CloseSlot);

        [Closures(AllNumeric)]
        public static string apply<T>(FormatCode def, T src)
            => string.Format(slot(def.Code), src);

        [Op, Closures(AllNumeric)]
        public static string format<C>(in FormatCode<C> src)
            => string.Format("{0}:{1}", src.Code, src.Kind);

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref FormatCode charcode<C>(in FormatCode<C> src)
            => ref Unsafe.As<FormatCode<C>, FormatCode>(ref Unsafe.AsRef(src));

        [MethodImpl(Inline)]
        public static FormatCode<K,C> define<K,C>(K kind, C code)
            where K : unmanaged
                => (kind,code);

        [MethodImpl(Inline)]
        public static FormatCode<C> knownkind<K,C>(FormatCode<K,C> src)
            where K : unmanaged
                => new FormatCode<C>(Unsafe.As<K,FormatCodeKind>(ref Unsafe.AsRef(src.Kind)), src.Code);

        public static string format<K,C>(FormatCode<K,C> src)
            where K : unmanaged
                => string.Format("{0}:{1}", src.Code, src.Kind);

        public static string apply<K,C,T>(FormatCode<K,C> def, T subject)
            where K : unmanaged
                => string.Format(def.Slot, subject);

        public static string apply<C,T>(FormatCode<C> def, T src)
            => string.Format(slot(def.Code), src);
    }
}
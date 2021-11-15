//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using static Root;
    using static cpu;
    using static Numeric;

    using NK = NumericKind;

    [ApiHost]
    public readonly struct Variant
    {
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static variant from<T>(T src)
            where T : unmanaged
                => from(store(force<T,ulong>(src), NumericKinds.kind<T>()));

        [MethodImpl(Inline), Op]
        public static variant define(ulong src, NumericKind dst)
            => from(store(src, dst));

        [MethodImpl(Inline), Op]
        public static variant convert(variant src, NumericKind dst)
            => from(src.Storage.WithElement(1,(ulong)dst));

        [MethodImpl(Inline)]
        public static NK kind(variant src)
            => (NK)vcell(src.Storage,1);

        [MethodImpl(Inline)]
        public static DataWidth width(variant src)
            => (DataWidth)src.DataWidth;

        [MethodImpl(Inline)]
        public static T extract<T>(variant src)
            where T : unmanaged
                => vcell(vector<T>(src), 0);

        [MethodImpl(Inline)]
        static Vector128<T> vector<T>(variant src)
            where T : unmanaged
                => core.generic<T>(src.Storage);

        [MethodImpl(Inline)]
        static variant from(Vector128<ulong> src)
            => new variant(src);

        [MethodImpl(Inline)]
        static Vector128<ulong> store(ulong value, NK kind)
            => cpu.vparts((ulong)value, (ulong)kind);

        [MethodImpl(Inline)]
        static Vector128<ulong> store(long value, NK kind)
            => cpu.vparts((ulong)value, (ulong)kind);

        [MethodImpl(Inline)]
        static Vector128<ulong> store(double value, NK kind)
            => Vector128.Create(value).WithElement(1, (double)kind).AsUInt64();

        [MethodImpl(Inline), Op]
        public static unsafe variant scalar(Enum src)
        {
            var kind = src.GetType().GetEnumUnderlyingType().NumericKind();
            var converted = (ulong)NumericBox.rebox(src,NumericKind.U64);
            return define(converted, kind);
        }

        [MethodImpl(Inline), Op]
        public static variant define(object src, Type dst)
            => define(src, dst.NumericKind());

        [MethodImpl(Inline), Op]
        public static variant define(object src, NumericKind dst)
        {
            switch(dst)
            {
                case NK.I8:
                    return define((sbyte)src);

                case NK.U8:
                    return define((byte)src);

                case NK.I16:
                    return define((short)src);

                case NK.U16:
                    return define((ushort)src);

                case NK.I32:
                    return define((int)src);

                case NK.U32:
                    return define((uint)src);

                case NK.I64:
                    return define((long)src);

                case NK.U64:
                    return define((ulong)src);

                case NK.F32:
                    return define((float)src);

                case NK.F64:
                    return define((double)src);
            }

            return default;
        }

        [MethodImpl(Inline), Op]
        public static variant define(sbyte src)
            => from(store(src, NK.I8));

        [MethodImpl(Inline), Op]
        public static variant define(byte src)
            => from(store(src, NK.U8));

        [MethodImpl(Inline), Op]
        public static variant define(short src)
            => from(store(src, NK.I16));

        [MethodImpl(Inline), Op]
        public static variant define(ushort src)
            => from(store(src, NK.U16));

        [MethodImpl(Inline), Op]
        public static variant define(int src)
            => from(store(src, NK.I32));

        [MethodImpl(Inline), Op]
        public static variant define(uint src)
            => from(store(src, NK.U32));

        [MethodImpl(Inline), Op]
        public static variant define(long src)
            => from(store(src, NK.I64));

        [MethodImpl(Inline), Op]
        public static variant define(ulong src)
            => from(store(src, NK.U64));

        [MethodImpl(Inline), Op]
        public static variant define(float src)
            => from(store(src, NK.F32));

        [MethodImpl(Inline), Op]
        public static variant define(double src)
            => from(store(src, NK.F64));
    }
}
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

    using NK = NumericKind;
    using api = Variant;

    public readonly struct variant : IVariant<variant>
    {
        public static variant integer(object src, byte width, bool signed)
            => api.integer(src,width,signed);

        [MethodImpl(Inline)]
        public static variant from<T>(T src)
            where T : unmanaged
                => api.from(src);

        internal readonly Vector128<ulong> Storage;

        [MethodImpl(Inline)]
        internal variant(Vector128<ulong> src)
            => Storage = src;

        [MethodImpl(Inline)]
        public variant(sbyte value)
            => Storage = Store(value, NK.I8, 8);

        [MethodImpl(Inline)]
        public variant(byte value)
            => Storage = Store(value, NK.U8, 8);

        [MethodImpl(Inline)]
        public variant(short value)
            => Storage = Store(value, NK.I16, 16);

        [MethodImpl(Inline)]
        public variant(ushort value)
            => Storage = Store(value, NK.U16, 16);

        [MethodImpl(Inline)]
        public variant(int value)
            => Storage = Store(value, NK.I32, 32);

        [MethodImpl(Inline)]
        public variant(uint value)
            => Storage = Store(value, NK.U32, 32);

        [MethodImpl(Inline)]
        public variant(long value)
            => Storage = Store(value, NK.I64, 64);

        [MethodImpl(Inline)]
        public variant(ulong value)
            => Storage = Store(value, NK.U64, 64);

        [MethodImpl(Inline)]
        public variant(float value)
            => Storage = Store(value, NK.F32, 32);

        [MethodImpl(Inline)]
        public variant(double value)
            => Storage = Store(value, NK.F64, 64);

        public NK CellKind
        {
            [MethodImpl(Inline)]
            get => (NK)cell<int>(2);
        }

        public int CellWidth
        {
            [MethodImpl(Inline)]
            get => cell<int>(3);
        }

        public int DataWidth
        {
            [MethodImpl(Inline)]
            get => CellWidth;
        }


        public override int GetHashCode()
            => Low64.GetHashCode();

        [MethodImpl(Inline)]
        public bool Equals(variant src)
            => Storage.Equals(src.Storage);

        public override bool Equals(object src)
            => src is variant v && Equals(v);

        public string Format()
        {
            if(CellKind.IsUnsigned())
                return Low64.ToString();
            else if(CellKind.IsSigned())
                return cell<long>(0).ToString();
            else if(CellKind == NK.F32)
                return cell<float>(0).ToString();
            else
                return cell<double>(0).ToString();
        }

        public string FormatHex()
        {
            var dst = EmptyString;
            switch(CellKind)
            {
                case NK.I8:
                case NK.U8:
                    dst = ((byte)this).FormatHex(zpad:false,specifier:true,uppercase:true);
                break;
                case NK.I16:
                case NK.U16:
                    dst = ((ushort)this).FormatHex(zpad:false,specifier:true,uppercase:true);
                break;
                case NK.I32:
                case NK.U32:
                    dst = ((uint)this).FormatHex(zpad:false,specifier:true,uppercase:true);
                break;
                case NK.I64:
                case NK.U64:
                    dst = ((ulong)this).FormatHex(zpad:false,specifier:true,uppercase:true);
                break;
                case NK.F32:
                    dst = ((float)this).FormatHex(zpad:false,specifier:true,uppercase:true);
                break;
                case NK.F64:
                    dst = ((double)this).FormatHex(zpad:false,specifier:true,uppercase:true);
                break;
            }
            return dst;
        }

        public override string ToString()
            => FormatHex();

        [MethodImpl(Inline)]
        Vector128<T> to<T>()
            where T : unmanaged
                => core.generic<T>(Storage);

        [MethodImpl(Inline)]
        T cell<T>(byte index)
            where T : unmanaged
                => vcell(to<T>(), index);

        ulong Low64
        {
            [MethodImpl(Inline)]
            get => vcell(Storage,0);
        }

        [MethodImpl(Inline)]
        static Vector128<ulong> Store(ulong value, NK kind, uint bitwidth)
            => SetWidth(Vector128.Create(value, (ulong)kind), (uint)bitwidth);

        [MethodImpl(Inline)]
        static Vector128<ulong> Store(long value, NK kind, uint bitwidth)
            => SetWidth(Vector128.Create((ulong)value, (ulong)kind), (uint)bitwidth);

        [MethodImpl(Inline)]
        static Vector128<ulong> Store(double value, NK kind, uint bitwidth)
            => SetWidth(Vector128.Create((ulong)value, (ulong)kind), (uint)bitwidth);

        [MethodImpl(Inline)]
        static Vector128<ulong> SetWidth(Vector128<ulong> src, uint width)
            => v64u(cpu.vcell(v32u(src), 3, width));

        [MethodImpl(Inline)]
        public static bool operator ==(variant x, variant y)
            => x.Equals(y);

        [MethodImpl(Inline)]
        public static bool operator !=(variant x, variant y)
            => !x.Equals(y);

        [MethodImpl(Inline)]
        public static implicit operator variant(sbyte src)
            => new variant(src);

        [MethodImpl(Inline)]
        public static implicit operator variant(byte src)
            => new variant(src);

        [MethodImpl(Inline)]
        public static implicit operator variant(short src)
            => new variant(src);

        [MethodImpl(Inline)]
        public static implicit operator variant(ushort src)
            => new variant(src);

        [MethodImpl(Inline)]
        public static implicit operator variant(int src)
            => new variant(src);

        [MethodImpl(Inline)]
        public static implicit operator variant(uint src)
            => new variant(src);

        [MethodImpl(Inline)]
        public static implicit operator variant(long src)
            => new variant(src);

        [MethodImpl(Inline)]
        public static implicit operator variant(ulong src)
            => new variant(src);

        [MethodImpl(Inline)]
        public static implicit operator variant(float src)
            => new variant(src);

        [MethodImpl(Inline)]
        public static implicit operator variant(double src)
            => new variant(src);

        [MethodImpl(Inline)]
        public static explicit operator sbyte(variant src)
            => src.cell<sbyte>(0);

        [MethodImpl(Inline)]
        public static explicit operator byte(variant src)
            => src.cell<byte>(0);

        [MethodImpl(Inline)]
        public static explicit operator short(variant src)
            => src.cell<short>(0);

        [MethodImpl(Inline)]
        public static explicit operator ushort(variant src)
            => src.cell<ushort>(0);

        [MethodImpl(Inline)]
        public static explicit operator int(variant src)
            => src.cell<int>(0);

        [MethodImpl(Inline)]
        public static explicit operator uint(variant src)
            => src.cell<uint>(0);

        [MethodImpl(Inline)]
        public static explicit operator long(variant src)
            => src.cell<long>(0);

        [MethodImpl(Inline)]
        public static explicit operator ulong(variant src)
            => src.cell<ulong>(0);

        [MethodImpl(Inline)]
        public static explicit operator float(variant src)
            => src.cell<float>(0);

        [MethodImpl(Inline)]
        public static explicit operator double(variant src)
            => src.cell<double>(0);

        public static variant Zero
            => default;
    }
}
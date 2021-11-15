//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    [ApiHost]
    public readonly struct RelativeAddress
    {
        const NumericKind Closure = UnsignedInts;

        /// <summary>
        /// Defines a <see cref='RelativeAddress'/> offset with a specified offset
        /// </summary>
        /// <param name="offset">The offset amount</param>
        [MethodImpl(Inline), Op]
        public static RelativeAddress define(MemoryAddress @base, ulong offset)
            => new RelativeAddress(@base, offset);

        /// <summary>
        /// Defines a <typeparamname name='T'/> valued <see cref='RelativeAddress{T}'/> relative to a specified offset
        /// </summary>
        /// <param name="offset">The offset</param>
        /// <typeparam name="T">The offset type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static RelativeAddress<T> define<T>(MemoryAddress @base, T offset)
            where T : unmanaged
                => new RelativeAddress<T>(@base, offset);

        [Op]
        public static string format(RelativeAddress src)
            => src.Offset.FormatAsmHex(4);

        [Op, Closures(Closure)]
        public static string format<T>(RelativeAddress<T> src)
            where T : unmanaged
        {
            if(width<T>() == 8)
                return string.Format("{0} + {1}", src.Base, @as<T,byte>(src.Offset).FormatAsmHex());
            else if(width<T>() == 16)
                return string.Format("{0} + {1}", src.Base, @as<T,ushort>(src.Offset).FormatAsmHex());
            else if(width<T>() == 32)
                return string.Format("{0} + {1}", src.Base, @as<T,uint>(src.Offset).FormatAsmHex());
            else
                return string.Format("{0} + {1}", src.Base, @as<T,ulong>(src.Offset).FormatAsmHex());
        }

        public MemoryAddress Base {get;}

        public ulong Offset {get;}

        [MethodImpl(Inline)]
        internal RelativeAddress(MemoryAddress @base, ulong offset)
        {
            Base = @base;
            Offset = offset;
        }

        public MemoryAddress Absolute
        {
             [MethodImpl(Inline)]
             get => Base + Offset;
        }

        public bool IsEmpty
        {
             [MethodImpl(Inline)]
             get => Absolute == 0;
        }

        public bool IsNonEmpty
        {
             [MethodImpl(Inline)]
             get => !IsEmpty;
        }

        [MethodImpl(Inline)]
        public string Format()
            => format(this);

        [MethodImpl(Inline)]
        public bool Equals(RelativeAddress src)
            => Absolute == src.Absolute;

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => Offset.GetHashCode();

        public override bool Equals(object src)
            => src is RelativeAddress l && Equals(l);

        [MethodImpl(Inline)]
        public static RelativeAddress operator+(RelativeAddress x, byte y)
            => new RelativeAddress(x.Base, x.Offset + y);

        [MethodImpl(Inline)]
        public static RelativeAddress operator+(RelativeAddress x, ushort y)
            => new RelativeAddress(x.Base, x.Offset + y);

        [MethodImpl(Inline)]
        public static RelativeAddress operator+(RelativeAddress x, uint y)
            => new RelativeAddress(x.Base, x.Offset + y);

        [MethodImpl(Inline)]
        public static RelativeAddress operator-(RelativeAddress x, byte y)
            => new RelativeAddress(x.Base, x.Offset - y);

        [MethodImpl(Inline)]
        public static RelativeAddress operator-(RelativeAddress x, ushort y)
            => new RelativeAddress(x.Base, x.Offset - y);

        [MethodImpl(Inline)]
        public static RelativeAddress operator-(RelativeAddress x, uint y)
            => new RelativeAddress(x.Base, x.Offset - y);

        [MethodImpl(Inline)]
        public static bool operator==(RelativeAddress x, RelativeAddress y)
            => x.Equals(y);

        [MethodImpl(Inline)]
        public static bool operator!=(RelativeAddress x, RelativeAddress y)
            => !x.Equals(y);

        public static RelativeAddress Empty
            => default;
    }
}
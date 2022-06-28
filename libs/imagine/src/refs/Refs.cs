//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.CompilerServices.Unsafe;

    [ApiHost,Free]
    public partial class Refs
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref sbyte int8<T>(ref T src)
            => ref As<T,sbyte>(ref src);

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref short int16<T>(ref T src)
            => ref As<T,short>(ref src);

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref int int32<T>(ref T src)
            => ref As<T,int>(ref src);

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref long int64<T>(ref T src)
            => ref As<T,long>(ref src);

        /// <summary>
        /// Presents a T-references as a <see cref='byte'/> reference
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref byte u8<T>(in T src)
            => ref @as<T,byte>(src);

        /// <summary>
        /// Presents a T-reference as a <see cref='ushort'/> reference
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref ushort u16<T>(in T src)
            => ref @as<T,ushort>(src);

        /// <summary>
        /// Presents a parametric references as a <see cref='uint'/> reference
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref uint u32<T>(in T src)
            => ref @as<T,uint>(src);

        /// <summary>
        /// Presents a T-references as a <see cref='ulong'/> reference
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref ulong u64<T>(in T src)
            => ref @as<T,ulong>(src);

        /// <summary>
        /// Presents a parametric source reference to a <see cref='byte'/>
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref byte uint8<T>(ref T src)
            => ref As<T,byte>(ref src);

        /// <summary>
        /// Presents a parametric source reference to a <see cref='ushort'/>
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref ushort uint16<T>(ref T src)
            => ref As<T,ushort>(ref src);

        /// <summary>
        /// Presents a parametric source reference to a <see cref='uint'/>
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref uint uint32<T>(ref T src)
            => ref As<T,uint>(ref src);


        /// <summary>
        /// Presents a parametric source reference to a <see cref='ulong'/>
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref ulong uint64<T>(ref T src)
            => ref As<T,ulong>(ref src);
    }
}

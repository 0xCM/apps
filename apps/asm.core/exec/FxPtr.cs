//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public readonly unsafe partial struct FxPtr
    {
        const NumericKind Closure = Integers;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static delegate* unmanaged<T,T,T> binop<T>(void* f)
            where T : unmanaged
                => (delegate* unmanaged<T,T,T>) f;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static delegate* unmanaged<T*,T*,T*> binop_ptr<T>(void* f)
            where T : unmanaged
                => (delegate* unmanaged<T*,T*,T*>) f;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static delegate* unmanaged<T*,T*,T*> binop_ptr<T>(ReadOnlySpan<byte> code)
            where T : unmanaged
                => (delegate* unmanaged<T*,T*,T*>) memory.liberate(code);


        [MethodImpl(Inline), Op, Closures(Closure)]
        public static delegate* unmanaged<T,T,T> binop<T>(ReadOnlySpan<byte> code)
            where T : unmanaged
                => (delegate* unmanaged<T,T,T>) memory.liberate(code);


        [MethodImpl(Inline), Op, Closures(Closure)]
        public static delegate* unmanaged<T,T> unaryop<T>(void* f)
            where T : unmanaged
                => (delegate* unmanaged<T,T>) f;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static delegate* unmanaged<T,T> unaryop<T>(ReadOnlySpan<byte> code)
            where T : unmanaged
                => (delegate* unmanaged<T,T>) memory.liberate(code);


        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector128<T> invoke<T>(delegate* unmanaged<T*,T*,T*> f, Vector128<T> a, Vector128<T> b)
            where T : unmanaged
                => *((Vector128<T>*)f((T*)&a, (T*)&b));

    }
}
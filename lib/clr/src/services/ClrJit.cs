//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection;

    using static core;
    using static Root;

    [ApiHost]
    public readonly struct ClrJit
    {
        [Op, MethodImpl(Inline)]
        static MemoryAddress fptr(MethodInfo src)
            => src.MethodHandle.GetFunctionPointer();

        [Op]
        public static MemoryAddress jit(MethodInfo src)
        {
            RuntimeHelpers.PrepareMethod(src.MethodHandle);
            return fptr(src);
        }

        [Op]
        public static void jit(ReadOnlySpan<MethodInfo> src, Span<MemoryAddress> dst)
        {
            var count = src.Length;
            for(var i=0; i<count; i++)
                seek(dst,i) = jit(skip(src,i));
        }

        [Op]
        public static Index<MemberAddress> jit(Index<MethodInfo> src)
        {
            var methods = src.View;
            var count = methods.Length;
            var buffer = alloc<MemberAddress>(count);
            ref var dst = ref first(buffer);
            for(var i=0; i<count; i++)
            {
                var method = skip(methods, i);
                seek(dst,i) = Clr.address(method, jit(method));
            }
            return buffer;
        }

        [Op]
        public static MemoryAddress jit(Delegate src)
        {
            sys.prepare(src);
            return fptr(src.Method);
        }

        [Op]
        public static DynamicPointer jit(DynamicDelegate src)
        {
            sys.prepare(src.Operation);
            return ClrDynamic.pointer(src);
        }

        public static DynamicPointer jit<D>(DynamicDelegate<D> src)
            where D : Delegate
                => jit(src.Untyped);
    }
}
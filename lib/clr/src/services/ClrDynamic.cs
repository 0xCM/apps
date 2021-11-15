//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;
    using System.Reflection.Emit;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    [ApiHost]
    public readonly struct ClrDynamic
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op]
        public static MethodBase method(RuntimeMethodHandle src)
            => MethodBase.GetMethodFromHandle(src);

        [Op]
        public static MsilCompilation compilation(DynamicMethod src)
        {
            var flags = src.GetMethodImplementationFlags();
            MemoryAddress address = _pointer(src);
            var msil = MsilSourceBlock.create(default, src.ResolveSignature(), msildata(src), flags);
            return new MsilCompilation(msil, address);
        }

        [Op]
        public static MsilCompilation compilation(DynamicDelegate src)
            => compilation(src.Target);

        [Op]
        public static MsilCompilation compilation(MemoryAddress @base, MethodInfo src)
        {
            var flags = src.GetMethodImplementationFlags();
            var msil = MsilSourceBlock.create(default, src.ResolveSignature(), src.GetMethodBody().GetILAsByteArray(), flags);
            return new MsilCompilation(msil, @base);
        }

        [Op]
        public static RuntimeMethodHandle handle(DynamicMethod src)
        {
            var getMethodDescriptorInfo = typeof(DynamicMethod).GetMethod("GetMethodDescriptor", BindingFlags.NonPublic | BindingFlags.Instance);
            return (RuntimeMethodHandle)getMethodDescriptorInfo.Invoke(src, null);
        }

        /// <summary>
        /// Creates a dynamic pointer from an untyped dynamic delegate
        /// </summary>
        /// <param name="src">The source delegate</param>
        /// <param name="handle">A proxy for the unmanaged pointer</param>
        [MethodImpl(Inline), Op]
        public static DynamicPointer pointer(DynamicDelegate src)
            => pointer(src, _pointer(src.Target));

        [MethodImpl(Inline), Op]
        public static DynamicPointer pointer(DynamicDelegate src, IntPtr handle)
            => new DynamicPointer(src, handle);

        /// <summary>
        /// Creates a dynamic pointer from a generic dynamic delegate
        /// </summary>
        /// <param name="src">The source delegate</param>
        /// <param name="handle">A proxy for the unmanaged pointer</param>
        /// <typeparam name="D">The delegate type</typeparam>
        public static DynamicPointer pointer<D>(DynamicDelegate<D> src)
            where D : Delegate
                => pointer(src);

        /// <summary>
        /// Finds the magical function pointer for a dynamic method
        /// </summary>
        /// <param name="method">The source method</param>
        /// <remarks>See https://stackoverflow.com/questions/45972562/c-sharp-how-to-get-runtimemethodhandle-from-dynamicmethod</remarks>
        static IntPtr _pointer(DynamicMethod method)
        {
            var descriptor = typeof(DynamicMethod).GetMethod("GetMethodDescriptor", BindingFlags.NonPublic | BindingFlags.Instance);
            return ((RuntimeMethodHandle)descriptor.Invoke(method, null)).GetFunctionPointer();
        }

        public static MethodSlots<I> slots<I>(Type src)
            where I : unmanaged
                => new MethodSlots<I>(slots(src));

        [Op]
        public static Index<MethodSlot> slots(Type src)
        {
            var methods = @readonly(src.DeclaredMethods());
            var count = methods.Length;
            var buffer = alloc<MethodSlot>(count);
            ref var dst = ref first(buffer);
            for(var i=0; i<count; i++)
            {
                var method = skip(methods,i);
                RuntimeHelpers.PrepareMethod(method.MethodHandle);
                seek(dst,i) = new MethodSlot(method.Name, method.MethodHandle.GetFunctionPointer());
            }
            return buffer;
        }

        [Op]
        public static ApiMsil msil(MemoryAddress @base, OpUri uri, MethodInfo src)
            => new ApiMsil(src.MetadataToken, @base, uri, src.ResolveSignature(), src.GetMethodBody().GetILAsByteArray(), src.GetMethodImplementationFlags());

        /// <summary>
        /// See https://stackoverflow.com/questions/4148297/resolving-the-tokens-found-in-the-il-from-a-dynamic-method/35711376#35711376
        /// </summary>
        [Op]
        static byte[] msildata(DynamicMethod src)
        {
            var resolver = typeof(DynamicMethod).GetField("m_resolver", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(src);
            if (resolver == null)
                throw new ArgumentException("The dynamic method's IL has not been finalized.");
            return (byte[])resolver.GetType().GetField("m_code", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(resolver);
        }
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;
    using System.Reflection.Emit;
    using System.Runtime.InteropServices;
    using System.Runtime.CompilerServices;


    using static Root;
    using static core;

    [ApiHost]
    public unsafe readonly struct DFx
    {
        const NumericKind Closure = UnsignedInts;

        public struct BinOpSpec<T>
        {
            public Identifier Name;

            public SegRef Definition;

            public T Arg0;

            public T Arg1;

            public BinaryOp<T> Operation;

            public Outcome<T> Result;
        }

        public struct EmitterSpec<T>
        {
            public Identifier Name;

            public SegRef Definition;

            public Emitter<T> Operation;
        }

        [Op, Closures(Closure)]
        public static unsafe Emitter<T> emitter<T>(Identifier name, byte* pCode)
            => emitter<T>(name, (MemoryAddress)pCode, out _);

        [Op, Closures(Closure)]
        public static unsafe Emitter<T> emitter<T>(OpIdentity id, ReadOnlySpan<byte> code)
            => emitter<T>(id.Format(), memory.liberate(code), out _);

        [Op, Closures(Closure)]
        public static unsafe Emitter<T> emitter<T>(Identifier name, ReadOnlySpan<byte> f)
            => emitter<T>(name, (MemoryAddress)memory.liberate(f), out _);

        public static unsafe Emitter<T> emitter<T>(Identifier name, MemoryAddress address, out DynamicMethod method)
        {
            var tFunc = typeof(Emitter<T>);
            var tReturn = typeof(T);
            method = new DynamicMethod(name, tReturn, null, typeof(int).Module);
            var g = method.GetILGenerator();
            g.Emit(OpCodes.Ldc_I8, (long)address);
            g.EmitCalli(OpCodes.Calli, CallingConvention.StdCall, tReturn, null);
            g.Emit(OpCodes.Ret);
            return (Emitter<T>)CellDelegate.define(name, address, method, method.CreateDelegate(tFunc));
        }

        public static unsafe DynamicAction action(string name, ReadOnlySpan<byte> f)
            => action(name, memory.liberate(f));

        public static unsafe DynamicAction action(string name, MemoryAddress f)
        {
            var tFunc = typeof(Action);
            var method = new DynamicMethod(name, null, null, tFunc.Module);
            var g = method.GetILGenerator();
            g.Emit(OpCodes.Ldc_I8, f);
            g.EmitCalli(OpCodes.Calli, CallingConvention.StdCall, null, null);
            g.Emit(OpCodes.Ret);
            return new DynamicAction(name, f, method, (Action)method.CreateDelegate(tFunc));
        }

        [MethodImpl(Inline), Op]
        public static SegRef load(ReadOnlySpan<byte> src, uint offset, in NativeBuffer dst)
        {
            var i0 = offset;
            ref var target = ref seek(dst.Edit, offset);
            var location = address(target);
            for(var i=0; i<src.Length; i++)
                seek(target, offset++) = skip(src,i);
            return (location, offset - i0);
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BinOpSpec<T> binop<T>(Identifier name, SegRef block)
        {
            var spec = new BinOpSpec<T>();
            spec.Name = name;
            spec.Definition = block;
            spec.Operation = BinaryOpDynamics.create<T>(spec.Name, spec.Definition.Pointer());
            return spec;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static EmitterSpec<T> emitter<T>(Identifier name, SegRef block)
        {
            var spec = new EmitterSpec<T>();
            spec.Name = name;
            spec.Definition = block;
            spec.Operation = DFx.emitter<T>(spec.Name, block.Address.Pointer<byte>());
            return spec;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref BinOpSpec<T> specify<T>(in T arg0, in T arg1, ref BinOpSpec<T> dst)
        {
            dst.Arg0 = arg0;
            dst.Arg1 = arg1;
            return ref dst;
        }

        [Op, Closures(Closure)]
        public static T invoke<T>(in BinOpSpec<T> f)
            => f.Operation(f.Arg0, f.Arg1);

        [Op, Closures(Closure)]
        public static T invoke<T>(in EmitterSpec<T> f)
            => f.Operation();

        public static string format<T>(in BinOpSpec<T> f, T result)
        {
            const string Pattern = "{0}({1},{2}) = {3}";
            return string.Format(Pattern, f.Name, f.Arg0, f.Arg1, result);
        }

        public static Func<T0,R> emit<T0,R>(ApiCodeBlock src, Span<byte> buffer, out Func<T0,R> fx)
        {
            fx = (Func<T0,R>)DynamicFunctions.create(n1).Emit(src.OpUri.OpId, functype:typeof(Func<T0,R>), result:typeof(R), args: array(typeof(T0)), buffer);
            return fx;
        }

        public static void emit<T>(N1 n, ApiCodeBlock code, MemoryAddress dst, out UnaryOp<T> fx)
            where T : unmanaged
        {
            var tOperand = typeof(T);
            var tResult = typeof(T);
            var tOperator = typeof(UnaryOp<T>);
            var builder = DynamicFunctions.create(n);
            fx = (UnaryOp<T>)builder.Emit(code.OpUri.OpId, functype:tOperator, result:tResult, args: array(tOperand), dst);
        }

        public static void emit<T>(N2 n, ApiCodeBlock code, MemoryAddress dst, out BinaryOp<T> fx)
            where T : unmanaged
        {
            var tOperand = typeof(T);
            var tResult = typeof(T);
            var tOperator = typeof(BinaryOp<T>);
            var builder = DynamicFunctions.create(n);
            fx = (BinaryOp<T>)builder.Emit(code.OpUri.OpId, functype:tOperator, result:tResult, args: array(tOperand), dst);
        }

        public static void emit<T>(N3 n, ApiCodeBlock code, MemoryAddress dst, out TernaryOp<T> fx)
            where T : unmanaged
        {
            var tOperand = typeof(T);
            var tResult = typeof(T);
            var tOperator = typeof(TernaryOp<T>);
            var builder = DynamicFunctions.create(n);
            fx = (TernaryOp<T>)builder.Emit(code.OpUri.OpId, functype:tOperator, result:tResult, args: array(tOperand), dst);
        }

        public static void emit<T0,T1,R>(MethodInfo src, bool calli, out Func<T0,T1,R> fx)
        {
            var args = new Type[]{typeof(T0), typeof(T1)};
            var returnType = typeof(R);
            var method = new DynamicMethod(src.Name, returnType, args, src.Module);
            var g = method.GetILGenerator();
            if(calli)
            {
                g.Emit(OpCodes.Ldarg_0);
                g.Emit(OpCodes.Ldarg_1);
                g.EmitCall(OpCodes.Call, src, null);
                g.Emit(OpCodes.Ret);
            }
            else
            {
                g.Emit(OpCodes.Ldarg_0);
                g.Emit(OpCodes.Ldarg_1);
                g.EmitCalli(OpCodes.Calli, CallingConvention.StdCall, returnType, args);
                g.Emit(OpCodes.Ret);
            }

            fx = (Func<T0,T1,R>)method.CreateDelegate(typeof(Func<T0,T1,R>));
        }

        public static UnaryOp<T> unaryop<T>(BufferToken dst, ApiCodeBlock src)
            where T : unmanaged
        {
            try
            {
                return unaryop<T>(src.Id, dst.Load(src.Encoded));
            }
            catch(Exception e)
            {
                term.magenta($"Operator production for {src.Id} failed");
                term.magenta(src);
                term.error(e);
                return empty;
            }
        }

        [MethodImpl(Inline)]
        public static BinaryOp<T> binaryop<T>(BufferToken dst, ApiCodeBlock src)
            where T : unmanaged
        {
            try
            {
                return binaryop<T>(src.Id, dst.Load(src.Encoded));
            }
            catch(Exception e)
            {
                term.magenta($"Operator production for {src.Id} failed");
                term.magenta(src);
                term.error(e);
                return empty;
            }
        }

        [MethodImpl(Inline)]
        static BinaryOp<T> binaryop<T>(OpIdentity id, BufferToken dst)
            where T : unmanaged
        {
            var tOperand = typeof(T);
            var tResult = typeof(T);
            var tOperator = typeof(BinaryOp<T>);
            return (BinaryOp<T>)emit(id, functype:tOperator, result:tResult, args: array(tOperand,tOperand), dst.Address);
        }

        [MethodImpl(Inline)]
        static UnaryOp<T> unaryop<T>(OpIdentity id, BufferToken dst)
            where T : unmanaged
        {
            var tOperand = typeof(T);
            var tResult = typeof(T);
            var tOperator = typeof(UnaryOp<T>);
            return (UnaryOp<T>)emit(id, functype:tOperator, result:tResult, args: array(tOperand), dst.Address);
        }

        static CellDelegate emit(OpIdentity id, Type functype, Type result, Type[] args, MemoryAddress dst)
        {
            var method = new DynamicMethod(id, result, args, functype.Module);
            var g = method.GetILGenerator();
            switch(args.Length)
            {
                case 1:
                    g.Emit(OpCodes.Ldarg_0);
                break;
                case 2:
                    g.Emit(OpCodes.Ldarg_0);
                    g.Emit(OpCodes.Ldarg_1);
                break;
                case 3:
                    g.Emit(OpCodes.Ldarg_0);
                    g.Emit(OpCodes.Ldarg_1);
                    g.Emit(OpCodes.Ldarg_2);
                break;
                case 4:
                    g.Emit(OpCodes.Ldarg_0);
                    g.Emit(OpCodes.Ldarg_1);
                    g.Emit(OpCodes.Ldarg_2);
                    g.Emit(OpCodes.Ldarg_3);
                break;

            }
            g.Emit(OpCodes.Ldc_I8, (long)dst);
            g.EmitCalli(OpCodes.Calli, CallingConvention.StdCall, result, args);
            g.Emit(OpCodes.Ret);
            return CellDelegates.define(id, dst, method, method.CreateDelegate(functype));
        }

        static T empty<T>(T src)
            where T : unmanaged
                => default;

        static T empty<T>(T x, T y)
            where T : unmanaged
                => default;
    }
}
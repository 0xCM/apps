//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static core;

    public readonly struct OperationSpec
    {
        public readonly OperationKind Kind;

        readonly ulong OpSizes;

        readonly ulong OpKinds;
    }

    public readonly struct OperandSpec
    {
        public readonly NativeSizeCode Size;
    }

    public class CodeBuffer : IDisposable
    {
        public static CodeBuffer allocate(uint size = Pow2.T14)
            => new CodeBuffer(size);

        NativeBuffer Code;

        ByteSize EffectiveSize;

        ByteSize Capacity;

        OperationKind OpKind;

        CodeBuffer(ByteSize size)
        {
            Code = memory.native(size);
            Capacity = size;
        }

        public void Dispose()
        {
            Code.Dispose();
        }


        void Clear()
        {
            Code.Clear();
        }

        public ByteSize Load(ReadOnlySpan<byte> src)
        {
            Clear();
            var size = min(Capacity, src.Length);
            var buffer = Code.Edit;
            for(var i=0; i<size; i++)
                seek(buffer, i) = skip(src,i);

            EffectiveSize = size;
            return EffectiveSize;
        }


        public T ExecUnaryOp<T>(string name, ReadOnlySpan<byte> src, T a)
        {
            Clear();
            var f = DFx.unaryop<T>(name, DFx.load(src, 0, Code));
            return f.Invoke(a);
        }

        public T ExecBinOp<T>(string name, ReadOnlySpan<byte> src, T a, T b)
        {
            Clear();
            var f = DFx.binop<T>(name, DFx.load(src, 0, Code));
            return f.Invoke(a,b);
        }

        public T ExecEmitter<T>(string name, ReadOnlySpan<byte> src)
        {
            Clear();
            var block = DFx.load(src, 0, Code);
            //var _f = Marshal.GetDelegateForFunctionPointer<DelegateBindings.cpuid>(block.Address);
            var f = DFx.emitter<T>(name, block);
            // var f = DynamicOperations.binop<ulong>(RoutineName, block);
            return f.Operation.Invoke();
        }
    }
}
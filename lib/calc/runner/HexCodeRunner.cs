//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static core;

    unsafe class HexCodeRunner : IDisposable
    {
        readonly NativeBuffer CodeBuffer;

        readonly Action<object> Receiver;

        readonly IWfRuntime Wf;

        public HexCodeRunner(IWfRuntime wf, Action<object> receiver)
        {
            Wf = wf;
            CodeBuffer = memory.native(Pow2.T10);
            Receiver = receiver;
        }

        public void Dispose()
        {
            CodeBuffer.Dispose();
        }

        void Push(object content)
            => Receiver(content);

        uint LoadBuffer(uint offset, ReadOnlySpan<byte> src)
        {
            var i0 = offset;
            var dst = CodeBuffer.Edit;
            var j=offset;
            for(var i=0; i<src.Length; i++)
                seek(dst, offset++) = skip(src,i);
            return offset - i0;
        }

        static ReadOnlySpan<byte> min64u_64u_64u
            => new byte[18]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x3b,0xca,0x72,0x04,0x48,0x8b,0xc2,0xc3,0x48,0x8b,0xc1,0xc3};

        void Exec(object[] args)
        {
            LoadBuffer(0,min64u_64u_64u);
            var pCode = CodeBuffer.Address.Pointer<byte>();
            var name = "min64u";
            var f = BinaryOpDynamics.create<ulong>(name, pCode);
            var a = 4ul;
            var b = 12ul;
            var c = f(a,b);
            Push(string.Format("{0}({1},{2})={3}", name, a, b, c));
        }


        void Demos(object[] args)
        {
            DynamicDemos.runA(result => Push(result));
            DynamicDemos.runB(result => Push(result));
            DynamicDemos.runC(result => Push(result));
        }
    }
}
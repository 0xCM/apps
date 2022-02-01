//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static core;
    using static CodeExecCases;

    partial class CheckCmdProvider
    {
        [CmdOp("check/code/exec")]
        Outcome CheckCodeExec(CmdArgs args)
        {
            var result = Outcome.Success;

            using var buffer = CodeBuffer.allocate();

            CheckBinaryOpExec(buffer);
            CheckUnaryOpExec(buffer);
            CheckUnaryFuncExec(buffer);

            return result;
        }

        void CheckBinaryOpExec(CodeBuffer buffer)
        {
            var name = nameof(min64u_64u_64u);
            var code = min64u_64u_64u;
            var a = 3ul;
            var b = 4ul;
            var f = buffer.LoadBinOp<ulong>(name,code);
            var c = f.Invoke(a,b);
            Write(f.Format(a,b,c));
        }

        void CheckUnaryOpExec(CodeBuffer buffer)
        {
            var name = nameof(dec_64u);
            var code = dec_64u;
            var a = 52ul;
            var f = buffer.LoadUnaryOp<ulong>(name, code);
            var b = f.Invoke(a);
            Write(f.Format(a,b));
        }

        void CheckUnaryFuncExec(CodeBuffer buffer)
        {
            var name = nameof(nonz_64u);
            var code = nonz_64u;
            var a = 52ul;
            var f = buffer.LoadUnaryFunc<ulong,bit>(name,code);
            var b = f.Invoke(a);
            Write(f.Format(a,b));
        }

        [CmdOp("check/capture/entries")]
        Outcome CheckEntryPoints(CmdArgs args)
        {
            var flow = Running("Creating method table");
            var table = MethodEntryPoints.create(Wf.ApiJit().JitCatalog(ApiRuntimeCatalog));
            var count = table.Count;

            for(var i=0; i<count; i++)
            {
                ref readonly var entry = ref table[i];
                Write(entry.Format());
            }
            Ran(flow, $"Created method table with {table.View.Length} entries");
            return true;
        }
    }

    readonly struct CodeExecCases
    {
        public static ReadOnlySpan<byte> min64u_64u_64u
            => new byte[18]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x3b,0xca,0x72,0x04,0x48,0x8b,0xc2,0xc3,0x48,0x8b,0xc1,0xc3};

        public static ReadOnlySpan<byte> nonz_64u
            => new byte[18]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x85,0xc9,0x0f,0x95,0xc0,0x0f,0xb6,0xc0,0x0f,0xb6,0xc0,0xc3};

        public static ReadOnlySpan<byte> dec_64u
             => new byte[10]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8d,0x41,0xff,0xc3};
    }
}
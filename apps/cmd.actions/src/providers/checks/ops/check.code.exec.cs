//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using Asm;


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

            return result;
        }

        void CheckBinaryOpExec(CodeBuffer buffer)
        {
            var name = nameof(min64u_64u_64u);
            var code = min64u_64u_64u;
            var a = 3ul;
            var b = 4ul;
            var c = buffer.ExecBinOp(name, code, a, b);
            var desc = string.Format("{0}({1}, {2}) = {3}", name, a, b, c);
            Write(desc);
        }

        void CheckUnaryOpExec(CodeBuffer buffer)
        {
            var name = nameof(dec_64u);
            var code = dec_64u;
            var a = 52ul;
            var b = buffer.ExecUnaryOp(name, code, a);
            var desc = string.Format("{0}({1}) = {2}", name, a, b);
            Write(desc);
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
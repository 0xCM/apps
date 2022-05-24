//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;
    using static Asm.RegClasses;

    partial class AsmCoreCmd
    {
        [CmdOp("asm/check/jmp")]
        void CheckJumps()
        {
            CheckJcc();
            CheckJmp32(n0);
            CheckJmp32(n1);
            CheckJmp32(n2);
        }

        void CheckJcc()
        {
            var @case = AsmCaseAssets.create().Branches();
            Utf8.decode(@case.ResBytes, out var doc);
            using var dispenser = Alloc.asm();
            var parser = DecodedAsmParser.create(dispenser);
            var result = parser.ParseBlocks(doc);
            var blocks = parser.Parsed();
            var view = blocks;
            var count = view.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var block = ref skip(view,i);
                Write(block.Label.Name);
                var statements = block.Code;
                var kS = statements.Count;
                for(var j=0; j<kS; j++)
                {
                    ref readonly var statement = ref statements[j];
                    ref readonly var encoded = ref statement.Encoded;
                    ref readonly var decoded = ref statement.Decoded;
                    Write(string.Format("{0,-42} # {1}", decoded, encoded));
                }
            }

        }

        void CheckJmp32(N1 n)
        {
            var result = Outcome.Success;
            var cases = AsmCases.jmp32();
            var count = cases.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var expect = ref cases[i];
                var disp = AsmRel32.disp(expect.Encoding.Bytes);
                Require.equal(disp, expect.Disp);
                var source = expect.Source;
                Rip rip = (source, JmpRel32.InstSize);
                MemoryAddress target = (MemoryAddress)((long)rip + (int)disp);
                Require.equal(AsmRel32.disp(rip, target), disp);
                Require.equal(AsmRel32.target(rip, expect.Encoding.Bytes), target);
                var encoding = JmpRel32.encode(rip, target);
                Require.equal(encoding, expect.Encoding);
                var relTarget = (int)disp + (int)JmpRel32.InstSize;
                @string statement = string.Format("jmp near ptr {0:x}h", relTarget);
                Require.equal(statement, expect.Statment);
                Write(statement);
            }
        }


        void CheckJmp32(N0 n)
        {
            var result = Outcome.Success;
            //var @case = AsmCaseAssets.create().Switch();

            var @base = (MemoryAddress)0x7ffd4512bf30;
            var @return = @base + (MemoryAddress)0x10b7;
            var sz = (byte)5;

            // 005ah jmp near ptr 10b7h                            ; JMP rel32                        | E9 cd                            | 5   | e9 58 10 00 00
            var label0 = 0x005a;
            var ip0 = @base + label0;

            var dx0 = AsmRel32.disp((ip0, sz), @return);

            var code0 = JmpRel32.encode((ip0,sz), @return);
            var code1 = AsmParser.asmhex("e9 58 10 00 00");

            if(!code0.Equals(code1))
                Error(string.Format("{0} != {1}", code1, code0));

            var label1 = 0x0065;
            var ip1 = @base + label1;
            var dx1 = AsmRel32.disp((ip1,sz), @return);
            var actual1 = JmpRel32.encode((ip1,sz), @return);
            var expect1 = AsmParser.asmhex("e9 4d 10 00 00");
            if(!actual1.Equals(expect1))
                Error(string.Format("{0} != {1}", expect1, actual1));

            var label2 = 0x0070;
            var ip2 = @base + label2;
            var dx2 = AsmRel32.disp((ip2,sz), @return);
            var actual2 = JmpRel32.encode((ip2,sz), @return);
            var expect2 = AsmParser.asmhex("e9 42 10 00 00");
            if(!actual2.Equals(expect2))
                Error(string.Format("{0} != {1}", expect2, actual2));

            var label3 = 0x007b;
            var ip3 = @base + label3;
            var dx3 = AsmRel32.disp((ip3,sz), @return);
            var actual3 = JmpRel32.encode((ip3,sz), @return);
            var expect3 = AsmParser.asmhex("e9 37 10 00 00");
            if(!actual3.Equals(expect3))
                Error(string.Format("{0} != {1}", expect3, actual3));
        }


        void CheckJmp32(N2 n)
        {
            const string Asm = "call 7fff92427890h";
            const string Encoding = "e8 25 e4 b2 5f";
            const byte InstSize = CallRel32.InstSize;
            const ulong Base = 0x7fff328f9430ul;
            const ushort Offset = 0x36;
            const ulong Target = 0x7fff92427890ul;
            const ulong Source = Base + Offset;

            Rip rip = Rip.define(Source,InstSize);

            Hex.hexbytes(Encoding, out var enc1);
            var dx = AsmRel32.disp(enc1);

            var enc2 = CallRel32.encode(rip, Target);
            if(enc1 != enc2)
                Error(string.Format("Encoding mismatch '{0}' != '{1}'", enc1, enc2));

            var box = new AsmIpBox(Base, uint.MaxValue);
            if(!box.IP(Source))
                Error("Ip out of range");

            box.Advance(InstSize, dx, out var target1);

            if(target1 != Target)
                Error("Computed target did not match expected target");

            var target2 = AsmRel32.target(rip, enc1);
            if(target2 != Target)
                Error("Computed target did not match expected target");
        }
    }
}
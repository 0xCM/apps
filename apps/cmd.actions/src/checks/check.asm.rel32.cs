//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;
    using System;

    using static core;
    using static Asm.AsmHexSpecs;

    partial class CheckCmdProvider
    {
        [CmdOp("check/asm/rel32")]
        Outcome CheckAsmRel32Calls(CmdArgs args)
        {
            var result = Outcome.Success;

            void Check1()
            {
                const ulong FunctionBase = 0x7ffc56862280;
                const ushort InstructionOffset = 0x25;
                const uint Displacement = 0xfc632176;
                var result = Outcome.Success;

                MemoryAddress client = FunctionBase + InstructionOffset;
                var call = AsmHexSpecs.call(client, Displacement);
                Write(AsmRender.format(call));
            }

            void Check2()
            {
                const string Input = "e8 d1 d5 b3 59";
                result = Hex.hexbytes(Input, out var code);
                if(result)
                {
                    var disp = AsmOpFactory.disp32(code,1);
                    Write(string.Format("{0} => disp32={1:x8}", Input, disp));
                }
            }

            void Check3()
            {
                const string Input = "e8 25 e4 b2 5f";
                const string Statement = "0036h call 7fff92427890h";
                const long Base = 0x7fff328f9430;
                var offset = 0x36;
                var ip = Base + offset;
                var sz = 5u;
                var nip = ip + sz;
                result = Hex.hexbytes(Input, out var code);
                var dx = AsmOpFactory.disp32(code,1);
                var target = (MemoryAddress)(nip + dx);
                var expect = (MemoryAddress)0x7fff92427890;
                if(target == expect)
                {
                    Status("Computed target matched expected target");
                }
                else
                {
                    Error("Computed target did not match expected target");
                }
            }

            void Check5()
            {
                // BaseAddress = 7ffc56862280h
                // 0025h call 7ffc52e94420h                      ; CALL rel32                       | E8 cd                            | 5   | e8 76 21 63 fc
                // Expected: 7ffc56862310h
                const string Asm = "call 7ffc52e94420h";
                const ulong Base = 0x7ffc56862280;
                const uint Offset = 0x25;
                const byte InstSize = 0x5;
                const ulong Disp = 0xfc632176;
                MemoryAddress Target = 0x7ffc56862310;
                AsmHexCode hex = array<byte>(0xe8, 0x76, 0x21, 0x63, 0xfc);
                MemoryAddress target = asm.rip(Base, Offset, InstSize) + Disp;
                // if(target != Target)
                // {
                //     Error(string.Format("{0} != {1}", target, Target));
                // }
            }


            void Check4()
            {
                const string Asm = "call 7fff92427890h";
                const string Encoding = "e8 25 e4 b2 5f";
                const ulong Base = 0x7fff328f9430ul;
                const byte Offset = 0x36;
                const byte InstSize = 5;
                const ulong Target = 0x7fff92427890ul;

                MemoryAddress ip = Base + Offset;
                Hex.hexbytes(Encoding, out var enc1);
                var dx = AsmOpFactory.disp32(enc1,1);

                var enc2 = AsmHexSpecs.call32(ip, Target);
                if(enc1 != enc2)
                {
                    Error(string.Format("Encoding mismatch '{0}' != '{1}'", enc1, enc2));
                }

                var box = new MemBox(Base, uint.MaxValue);
                if(!box.IP(ip))
                {
                    Error("Ip out of range");
                    return;
                }

                box.Advance(InstSize, dx, out var target);
                if(target == Target)
                {
                    Status("Computed target matched expected target");
                }
                else
                {
                    Error("Computed target did not match expected target");
                }

            }

            Check1();
            Check2();
            Check3();
            Check4();
            Check5();
            CheckJmpRel32();

            return result;
        }


        void CheckJmpRel32()
        {
            var result = Outcome.Success;
            var @case = AsmCaseAssets.create().Switch();

            var @base = (MemoryAddress)0x7ffd4512bf30;
            var @return = @base + (MemoryAddress)0x10b7;
            var sz = (byte)5;

            var label0 = 0x005a;
            var ip0 = @base + label0;
            var dx0 = AsmOpFactory.disp32(ip0, @return);
            var actual0 = jmp32(ip0, @return);
            var expect0 = asm.hexcode("e9 58 10 00 00");
            var d0l = asm.link(dx0, ip0, @return);
            Write(d0l);
            if(!actual0.Equals(expect0))
                Error(string.Format("{0} != {1}", expect0, actual0));
            else
                Write(string.Format("{0} == {1}", expect0, actual0));

            var label1 = 0x0065;
            var ip1 = @base + label1;
            var dx1 = AsmOpFactory.disp32(ip1, @return);
            var actual1 = jmp32(ip1, @return);
            var expect1 = asm.hexcode("e9 4d 10 00 00");
            var d1l = asm.link(dx1, ip1, @return);
            Write(d1l);
            if(!actual1.Equals(expect1))
                Error(string.Format("{0} != {1}", expect1, actual1));
            else
                Write(string.Format("{0} == {1}", expect1, actual1));

            var label2 = 0x0070;
            var ip2 = @base + label2;
            var dx2 = AsmOpFactory.disp32(ip2, @return);
            var actual2 = jmp32(ip2, @return);
            var expect2 = asm.hexcode("e9 42 10 00 00");
            var d2l = asm.link(dx2, ip2, @return);
            Write(d2l);
            if(!actual2.Equals(expect2))
                Error(string.Format("{0} != {1}", expect2, actual2));
            else
                Write(string.Format("{0} == {1}", expect2, actual2));

            var label3 = 0x007b;
            var ip3 = @base + label3;
            var dx3 = AsmOpFactory.disp32(ip3, @return);
            var actual3 = jmp32(ip3, @return);
            var expect3 = asm.hexcode("e9 37 10 00 00");
            var d3l = asm.link(dx3,ip3,@return);
            Write(d3l);
            if(!actual3.Equals(expect3))
                Error(string.Format("{0} != {1}", expect3, actual3));
            else
                Write(string.Format("{0} == {1}", expect3, actual3));
        }
    }
}
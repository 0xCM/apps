//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

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
                const ulong Base = 0x7ffc56862280;
                const ushort Offset = 0x25;
                const uint Disp = 0xfc632176;
                const ulong IP = Base + Offset;

                var call = AsmHexSpecs.call(IP, Disp);
                Write(call.Format());
            }

            void Check2()
            {
                const string Input = "e8 d1 d5 b3 59";
                result = Hex.hexbytes(Input, out var code);
                if(result)
                {
                    var disp = AsmValues.disp32(code,1);
                    Write(string.Format("{0} => disp32={1:x8}", Input, disp));
                }
            }

            void Check3()
            {
                const string Asm = "call 7fff92427890h";
                const string Encoding = "e8 25 e4 b2 5f";
                const byte InstSize = CallRel32.InstSize;
                const long Base = 0x7fff328f9430;
                const ushort Offset = 0x36;
                const long Source = Base + Offset;
                const long Target = 0x7fff92427890;
                const long RIP = Source + InstSize;
                const uint Disp = 0x5FB2E425;
                const string RenderPattern = "{0,-12}: {1}";

                result = Hex.hexbytes(Encoding, out var code);
                var dx = AsmRel32.disp(code);
                var target = (MemoryAddress)(RIP + dx);
                if(target == Target && dx == Disp)
                {
                    var dst = text.buffer();
                    dst.AppendLineFormat(RenderPattern, nameof(Asm), Asm);
                    dst.AppendLineFormat(RenderPattern, nameof(Encoding), Encoding);
                    dst.AppendLineFormat(RenderPattern, nameof(Base), (MemoryAddress)Base);
                    dst.AppendLineFormat(RenderPattern, nameof(Offset), (Address16)Offset);
                    dst.AppendLineFormat(RenderPattern, nameof(Source), (MemoryAddress)Source);
                    dst.AppendLineFormat(RenderPattern, nameof(RIP), (MemoryAddress)RIP);
                    dst.AppendLineFormat(RenderPattern, nameof(Target), (MemoryAddress)Target);
                    dst.AppendLineFormat(RenderPattern, "Disp",  dx);

                    Write(dst.Emit(), FlairKind.StatusData);
                }
                else
                {
                    Error("Computed target did not match expected target");
                }
            }

            void Check4()
            {
                const string Asm = "call 7fff92427890h";
                const string Encoding = "e8 25 e4 b2 5f";
                const byte InstSize = CallRel32.InstSize;
                const ulong Base = 0x7fff328f9430ul;
                const ushort Offset = 0x36;
                const ulong Target = 0x7fff92427890ul;
                const ulong Source = Base + Offset;
                const ulong RIP = Source + InstSize;

                Hex.hexbytes(Encoding, out var enc1);
                var dx = AsmRel32.disp(enc1);

                var enc2 = AsmHexSpecs.call32(Source, Target);
                if(enc1 != enc2)
                    Error(string.Format("Encoding mismatch '{0}' != '{1}'", enc1, enc2));

                var box = new AsmIpBox(Base, uint.MaxValue);
                if(!box.IP(Source))
                    Error("Ip out of range");

                box.Advance(InstSize, dx, out var target1);

                if(target1 != Target)
                    Error("Computed target did not match expected target");

                var target2 = AsmRel32.target(Source, enc1);
                if(target2 != Target)
                    Error("Computed target did not match expected target");

            }

            void Check5()
            {
                const string Input = "e8 25 e4 b2 5f";
                const string Statement = "0036h call 7fff92427890h";
                const long Base = 0x7fff328f9430;
                const long Target = 0x7fff92427890;
                const byte Offset = 0x36;
                const long IP = Base + Offset;
                Hex.hexbytes(Input, out var encoding);
                if(!AsmRel32.isCall(encoding))
                {
                    Error("Rel32 test failed");
                    return;
                }

            }

            void Check6()
            {
                var cases = AsmCases.callrel32();
                var count = cases.Count;
                for(var i=0; i<count; i++)
                {
                    ref readonly var c = ref cases[i];
                    Write(c.Format());
                }
            }

            // Check1();
            // Check2();
            Check3();
            Check4();
            // Check5();
            // Check6();
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

            // 005ah jmp near ptr 10b7h                            ; JMP rel32                        | E9 cd                            | 5   | e9 58 10 00 00
            var label0 = 0x005a;
            var ip0 = @base + label0;
            var dx0 = AsmValues.disp32(ip0, @return);

            var code0 = jmp32(ip0, @return);
            var code1 = asm.hexcode("e9 58 10 00 00");

            var d0l = Disp32Link.define(dx0, ip0, @return);
            Write(d0l);
            if(!code0.Equals(code1))
                Error(string.Format("{0} != {1}", code1, code0));
            else
                Write(string.Format("{0} == {1}", code1, code0));

            var label1 = 0x0065;
            var ip1 = @base + label1;
            var dx1 = AsmValues.disp32(ip1, @return);
            var actual1 = jmp32(ip1, @return);
            var expect1 = asm.hexcode("e9 4d 10 00 00");
            var d1l = Disp32Link.define(dx1, ip1, @return);
            Write(d1l);
            if(!actual1.Equals(expect1))
                Error(string.Format("{0} != {1}", expect1, actual1));
            else
                Write(string.Format("{0} == {1}", expect1, actual1));

            var label2 = 0x0070;
            var ip2 = @base + label2;
            var dx2 = AsmValues.disp32(ip2, @return);
            var actual2 = jmp32(ip2, @return);
            var expect2 = asm.hexcode("e9 42 10 00 00");
            var d2l = Disp32Link.define(dx2, ip2, @return);
            Write(d2l);
            if(!actual2.Equals(expect2))
                Error(string.Format("{0} != {1}", expect2, actual2));
            else
                Write(string.Format("{0} == {1}", expect2, actual2));

            var label3 = 0x007b;
            var ip3 = @base + label3;
            var dx3 = AsmValues.disp32(ip3, @return);
            var actual3 = jmp32(ip3, @return);
            var expect3 = asm.hexcode("e9 37 10 00 00");
            var d3l = Disp32Link.define(dx3,ip3,@return);
            Write(d3l);
            if(!actual3.Equals(expect3))
                Error(string.Format("{0} != {1}", expect3, actual3));
            else
                Write(string.Format("{0} == {1}", expect3, actual3));
        }
    }
}
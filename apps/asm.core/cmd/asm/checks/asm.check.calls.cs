//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    partial class AsmCoreCmd
    {
        [CmdOp("asm/check/calls")]
        void CheckAsmCalls()
        {
            void Check1()
            {
                const ulong Base = 0x7ffc56862280;
                const ushort Offset = 0x25;
                const uint Disp = 0xfc632176;
                const ulong IP = Base + Offset;
                Rip rip = Rip.define(IP, 5);
                var call = CallRel32.define(rip, (Disp32)Disp);
                Write(call.Format());
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

                Hex.hexbytes(Encoding, out var code);

                var disp1 = AsmRel32.disp(code);
                var disp2 = asm.disp(code.View,1, NativeSizeCode.W32);
                Require.equal(disp1,disp2);
                var target = (MemoryAddress)(RIP + disp1);
                if(target == Target && disp1 == Disp)
                {
                    var dst = text.buffer();
                    dst.AppendLineFormat(RenderPattern, nameof(Asm), Asm);
                    dst.AppendLineFormat(RenderPattern, nameof(Encoding), Encoding);
                    dst.AppendLineFormat(RenderPattern, nameof(Base), (MemoryAddress)Base);
                    dst.AppendLineFormat(RenderPattern, nameof(Offset), (Address16)Offset);
                    dst.AppendLineFormat(RenderPattern, nameof(Source), (MemoryAddress)Source);
                    dst.AppendLineFormat(RenderPattern, nameof(RIP), (MemoryAddress)RIP);
                    dst.AppendLineFormat(RenderPattern, nameof(Target), (MemoryAddress)Target);
                    dst.AppendLineFormat(RenderPattern, "Disp",  disp1);

                    Write(dst.Emit(), FlairKind.StatusData);
                }
                else
                {
                    Error("Computed target did not match expected target");
                }
            }

            Check1();
            Check3();
        }
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    partial class CheckCmdProvider
    {
        [CmdOp("check/asm/rel32/calls")]
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
                var call = AsmSpecs.call(client, Displacement);
                Write(AsmRender.format(call));
            }

            void Check2()
            {
                const string Input = "e8 d1 d5 b3 59";
                result = Hex.hexbytes(Input, out var code);
                if(result)
                {
                    var disp = asm.disp32(code,1);
                    Write(string.Format("{0} => disp32={1:x8}", Input, disp));
                }
            }

            void Check3()
            {
                const string Input = "e8 25 e4 b2 5f";
                const string Statement = "0036h call 7fff92427890h";
                var @base = 0x7fff328f9430;
                var offset = 0x36;
                var ip = @base + offset;
                var sz = 5;
                var nip = ip + sz;
                //var code = new byte[]{0xe8, 0x25, 0xe4, 0xb2, 0x5f};
                result = Hex.hexbytes(Input, out var code);
                var dx = asm.disp32(code,1);
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

            Check1();
            Check2();
            Check3();

            return result;
        }
    }
}
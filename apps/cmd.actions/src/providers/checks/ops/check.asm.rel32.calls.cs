//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static Asm.AsmSpecs;

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
                const string input = "e8 d1 d5 b3 59";
                result = Hex.hexbytes(input, out var code);
                if(result)
                {
                    var disp = asm.disp32(code,1);
                    Write(string.Format("{0} => disp32={1:x8}", input, disp));
                }
            }

            Check1();
            Check2();

            return result;
        }
    }
}
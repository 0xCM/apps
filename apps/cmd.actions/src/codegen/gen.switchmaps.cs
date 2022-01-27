//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static Root;
    using static core;

    partial class CodeGenProvider
    {
        [CmdOp("gen/switchmaps")]
        Outcome GenSwitchMap(CmdArgs args)
        {
            GenIntSwitch();
            GenEnumToIntSwitch();
            return true;
        }

        void GenIntSwitch()
        {
            var g = CodeGen.SwitchMap();
            var src = array<uint>(34, 51, 98, 101, 264, 888, 911, 902, 3828, 13, 19);
            var dst = array<uint>(3000, 201, 197, 313145, 264801, 911122, 4, 7, 11, 54, 99);
            var spec = CgSpecs.@switch("test", src, dst);
            var result = g.Generate(spec);
            Write(result);
        }

        void GenEnumToIntSwitch()
        {
            var g = CodeGen.SwitchMap();
            var src = array<Hex3Kind>(Hex3Kind.x02, Hex3Kind.x03, Hex3Kind.x04);
            var dst = array<byte>(2,3,4);
            var spec = CgSpecs.@switch("enum_test", src, dst);
            var result = g.Generate(spec);
            Write(result);
        }
    }
}
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
        [CmdOp("gen/hex/strings")]
        Outcome GenHexStrings(CmdArgs args)
        {
            var g = CodeGen.HexStrings();
            var name = "HexStringArrays";
            var ns = "Z0";
            var content = text.buffer();
            var margin = 0u;
            content.IndentLineFormat(margin,"public readonly struct {0}", name);
            content.IndentLine(margin, Chars.LBrace);
            margin +=4;
            content.IndentLine(margin,g.GenArray("Hex8Strings", byte.MinValue, byte.MaxValue, LetterCaseKind.Upper));
            margin -= 4;
            content.IndentLine(margin,Chars.RBrace);

            var path = CodeGen.EmitFile(CgSpecs.define(ns).WithContent(content.Emit()), name, CgTarget.Common);
            Status(AppMsg.Emitted.Format(path));

            return true;
        }

        [CmdOp("gen/switch/map")]
        Outcome GenSwitchMap(CmdArgs args)
        {
            var g = CodeGen.SwitchMap();
            var src = array<uint>(34, 51, 98, 101, 264, 888, 911, 902, 3828, 13, 19);
            var dst = array<uint>(3000, 201, 197, 313145, 264801, 911122, 4, 7, 11, 54, 99);
            var spec = CgSpecs.@switch("test", src, dst);
            var result = g.Generate(spec);
            Write(result);
            return true;
        }
    }
}
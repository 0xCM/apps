//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
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
            Status(AppMsg.EmittedFile.Format(path));

            return true;
        }
    }
}
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
        [CmdOp("gen/switchmaps")]
        Outcome GenSwitchMap(CmdArgs args)
        {
            GenIntSwitch();
            GenEnumToIntSwitch();
            return true;
        }

        void GenIntSwitch()
        {
            var src = array<uint>(34, 51, 98, 101, 264, 888, 911, 902, 3828, 13, 19);
            var dst = array<uint>(3000, 201, 197, 313145, 264801, 911122, 4, 7, 11, 54, 99);
            var spec = CgSpecs.@switch("test", src, dst);
            var result = CsLang.SwitchMap().Generate(spec);
            Write(result);
        }

        void GenEnumToIntSwitch()
        {
            var src = array<Hex3Kind>(Hex3Kind.x02, Hex3Kind.x03, Hex3Kind.x04);
            var dst = array<byte>(2,3,4);
            var spec = CgSpecs.@switch("enum_test", src, dst);
            var result = CsLang.SwitchMap().Generate(spec);
            Write(result);
        }

        [CmdOp("gen/hex/strings")]
        Outcome GenHexStrings(CmdArgs args)
        {
            var name = "HexStringArrays";
            var ns = "Z0";
            var dst = CsLang.emitter();
            var offset = 0u;
            dst.OpenNamespace(offset, ns);
            offset += 4;
            dst.OpenStruct(offset, name);
            offset +=4;

            var content = CsLang.HexStrings().GenArray("Hex8Strings", byte.MinValue, byte.MaxValue, LetterCaseKind.Upper);
            dst.IndentLine(offset,content);
            offset -= 4;
            dst.CloseStruct(offset);
            offset -= 4;
            dst.CloseNamespace(offset);

            AppSvc.FileEmit(dst.Emit(), AppDb.CgStage().Path(name,FileKind.Cs));

            return true;
        }

   }
}
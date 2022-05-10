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
            var g = CsLang.HexStrings();
            var name = "HexStringArrays";
            var ns = "Z0";
            var content = text.buffer();
            var margin = 0u;
            content.IndentLineFormat(margin,"public readonly struct {0}", name);
            content.IndentLine(margin, Chars.LBrace);
            margin +=4;
            content.IndentLine(margin, g.GenArray("Hex8Strings", byte.MinValue, byte.MaxValue, LetterCaseKind.Upper));
            margin -= 4;
            content.IndentLine(margin,Chars.RBrace);

            var spec = CgSpecs.define(ns).WithContent(content.Emit());
            CsLang.EmitFile(spec, name, CgTarget.Common);
            return true;
        }

        [CmdOp("gen/records")]
        Outcome GenRecords(CmdArgs args)
        {
            var g = CsLang.Records();
            var dst = text.buffer();
            iter(ApiRuntimeCatalog.TableDefs, src => g.Emit(0u,src,dst));
            Write(dst.Emit());
            return true;
        }

        [CmdOp("gen/asci/bytes")]
        Outcome EmitAsciBytes(CmdArgs args)
        {
            var name = "Uppercase";
            var content = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var dst = text.buffer();
            var bytes = CsLang.AsciLookups().Emit(8u, name,content, dst);
            Write(dst.Emit());
            return true;
        }

        [CmdOp("gen/vex-tokens")]
        Outcome GenTokenSpecs(CmdArgs args)
        {
            var result = Outcome.Success;
            var src = Symbols.concat(Symbols.index<AsmOcTokens.VexToken>());
            var name = "VexTokens";
            var dst = AppDb.CgStage().Path("literals", name, FileKind.Cs);
            using var writer = dst.Writer();
            writer.WriteLine(string.Format("public readonly struct {0}", name));
            writer.WriteLine("{");
            CsLang.StringLiterals().Emit("Data", src, writer);
            writer.WriteLine("}");
            return result;
        }

        [CmdOp("gen/int-strings")]
        Outcome GenIntStrings(CmdArgs args)
        {
            var result = Outcome.Success;
            result = DataParser.parse(arg(args,0).Value, out uint min);
            result = DataParser.parse(arg(args,1).Value, out uint max);
            var values = list<string>();
            var name = string.Format("Range{0}To{1}", min, max);
            var n = max.ToString().Length;
            for(var i=min; i<=max; i++)
                values.Add(i.ToString().PadLeft(n));

            var dst = AppDb.CgStage().Path("literals", name, FileKind.Cs);
            CsLang.StringLiterals().Emit(name,values.ViewDeposited(), dst);
            return result;
        }
    }
}
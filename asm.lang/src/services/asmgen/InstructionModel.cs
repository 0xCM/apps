//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static CsPatterns;

    partial class AsmModelGen
    {
        readonly struct InstructionModel
        {
            public AsmMnemonic Monic {get;}

            public string TypeName {get;}

            [MethodImpl(Inline)]
            public InstructionModel(AsmMnemonic src)
            {
                Monic = src;
                TypeName = Monic.Format(MnemonicCase.Captialized);
            }

            public string FactoryName()
            {
                var identifier = Monic.Format(MnemonicCase.Lowercase);
                return identifier switch{
                    "in" => "@in",
                    "out" => "@out",
                    "int" => "@int",
                    "lock" => "@lock",
                    _ => identifier
                };
            }

            public void RenderFactories(uint margin, ITextBuffer dst)
            {
                dst.IndentLine(margin, string.Format("public {0} {1}() => default;", TypeName, FactoryName()));
                dst.AppendLine();
                dst.IndentLine(margin, InlineOpAttributeSpec);
                dst.IndentLine(margin, string.Format("public {0} {1}(AsmHexCode encoded) => new {0}(encoded);", TypeName, FactoryName()));
                dst.AppendLine();
            }

            public void RenderType(uint margin, ITextBuffer dst)
            {
                dst.IndentLine(margin, string.Format("public struct {0} : {1}<{0}>", TypeName, InstructionContractName));
                dst.IndentLine(margin, Open);
                margin += Indent;
                dst.IndentLine(margin, string.Format(FieldDeclPattern, "AsmHexCode", "Content"));
                dst.AppendLine();
                dst.IndentLine(margin, InlineAttrib());
                dst.IndentLine(margin, string.Format("public {0}(AsmHexCode encoded)", TypeName));
                dst.IndentLine(margin, Open);
                margin += Indent;
                dst.IndentLine(margin, string.Format("Content = encoded;"));
                margin -= Indent;
                dst.IndentLine(margin, Close);
                dst.AppendLine();
                dst.IndentLine(margin, string.Format("public AsmMnemonicCode Mnemonic => AsmMnemonicCode.{0};", Monic.Name));
                dst.AppendLine();
                dst.IndentLine(margin, "public AsmHexCode Encoded => Content;");

                dst.AppendLine();
                dst.IndentLine(margin, string.Format(ImplicitOperatorDeclPattern, "AsmMnemonicCode", TypeName, string.Format(QualifiedAccessPattern, "src", "Mnemonic")));
                dst.AppendLine();
                dst.IndentLine(margin, string.Format("public static implicit operator AsmMnemonic({0} src) => AsmMnemonics.{1};", TypeName, Monic.Name));
                dst.AppendLine();
                dst.IndentLine(margin, string.Format("public static implicit operator AsmHexCode({0} src) => src.Encoded;", TypeName));
                dst.AppendLine();
                dst.IndentLine(margin, string.Format("public static implicit operator {0}(AsmHexCode src) => new {0}(src);", TypeName));
                margin -= Indent;
                dst.IndentLine(margin, Close);
                dst.AppendLine();

                RenderFactories(margin, dst);
            }

            [MethodImpl(Inline)]
            public static implicit operator InstructionModel(AsmMnemonic src)
                => new InstructionModel(src);

            public static InstructionModel Empty
                => new InstructionModel(AsmMnemonic.Empty);
        }
    }
}
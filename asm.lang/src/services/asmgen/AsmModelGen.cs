//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    using T = AsmGenTarget;

    [ApiHost]
    public sealed partial class AsmModelGen : AppService<AsmModelGen>
    {
        const string InstructionContractName = nameof(ITypedInstruction);

        const string InlineOpAttributeSpec = "[MethodImpl(Inline), Op]";

        [Op]
        public void GenModelsInPlace(ReadOnlySpan<string> src)
        {
            var flow = Wf.Running();
            EmitInstructionContracts(GetTargetPath(T.InstructionContracts));
            EmitMonicExpressions(src, GetTargetPath(AsmGenTarget.MonicExpression));
            EmitMonicEnum(src, GetTargetPath(AsmGenTarget.MonicCodeEnum));
            EmitInstructionTypes(src,GetTargetPath(T.InstructionTypes));
            EmitStatementBuilder(src, GetTargetPath(T.StatementBuilder));
            Wf.Ran(flow);
        }

        [Op]
        public void GenModelsInPlace()
        {
            GenModelsInPlace(LoadMnemonicNames());
        }

        [Op]
        public void GenModels(ReadOnlySpan<string> src, FS.FolderPath dst)
        {
            var flow = Running();
            EmitInstructionContracts(GetTargetPath(T.InstructionContracts, dst));
            EmitMonicExpressions(src, GetTargetPath(AsmGenTarget.MonicExpression, dst));
            EmitMonicEnum(src, GetTargetPath(AsmGenTarget.MonicCodeEnum, dst));
            EmitInstructionTypes(src, GetTargetPath(T.InstructionTypes, dst));
            EmitStatementBuilder(src, GetTargetPath(T.StatementBuilder, dst));
            Ran(flow);
        }

        [Op]
        public void GenModels(FS.FolderPath dst)
        {
            GenModels(LoadMnemonicNames(), dst);
        }

        const byte Indent = 4;

        const string Open = "{";

        const string Close = "}";

        const string MonicSymbolPattern = "[Symbol(\"{0}\")]";

        const string NamespaceDeclPattern = "namespace {0}";

        const string TargetNamespaceName = "Z0.Asm";

        const string ImplicitOperatorDeclPattern = "public static implicit operator {0}({1} src) => {2};";

        const string UsingCompilerServices = "using System.Runtime.CompilerServices;";

        const string UsingRoot = "using static Root;";

        const string UsingTypePattern = "using static {0};";

        const string QualifiedAccessPattern = "{0}.{1}";

        static string NamespaceDecl() => CsPatterns.NamespaceDecl(TargetNamespaceName);

        const string ItemAssignPattern = "{0} = {1},";

        const string FieldDeclPattern = "public {0} {1};";

        const string InstructionContractPattern = @"namespace Z0.Asm
{
    public interface {TargetName}
    {
        AsmMnemonicCode Mnemonic {get;}

        AsmHexCode Encoded {get;}
    }

    public interface {TargetName}<T> : {TargetName}
        where T : struct, {TargetName}<T>
    {

    }
}";

    }
}
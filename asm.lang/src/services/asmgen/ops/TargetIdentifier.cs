//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static Root;

    partial class AsmModelGen
    {
        static Identifier TargetIdentifier(AsmGenTarget kind)
            => kind switch {
                AsmGenTarget.InstructionTypes => "AsmInstructions",
                AsmGenTarget.MonicCodeEnum => "AsmMnemonicCode",
                AsmGenTarget.MonicExpression => "AsmMnemonics",
                AsmGenTarget.InstructionContracts=> "ITypedInstruction",
                AsmGenTarget.StatementBuilder => "AsmStatementBuilder",
                AsmGenTarget.RegNameFactories => "AsmRegNames",
                _ => EmptyString
            };
    }
}
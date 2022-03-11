//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static XedModels;
    using static XedRules;

    partial class IntelXed
    {
        const string xed = "xed";

        void EmitTokenSummaries()
        {
            ApiMetadata.EmitApiTokens(xed, xed);
        }

        void EmitRawTokens()
        {
            var scope = "xed/tokens";
            ApiMetadata.EmitTokens<AttributeKind>(scope, xed);
            ApiMetadata.EmitTokens<CategoryKind>(scope, xed);
            ApiMetadata.EmitTokens<ChipCode>(scope, xed);
            ApiMetadata.EmitTokens<CpuidBit>(scope, xed);
            ApiMetadata.EmitTokens<ElementKind>(scope, xed);
            ApiMetadata.EmitTokens<BaseTypeKind>(scope, xed);
            ApiMetadata.EmitTokens<EASZ>(scope, xed);
            ApiMetadata.EmitTokens<EOSZ>(scope, xed);
            ApiMetadata.EmitTokens<GroupName>(scope, xed);
            ApiMetadata.EmitTokens<ExtensionKind>(scope, xed);
            ApiMetadata.EmitTokens<FormFacets>(scope, xed);
            ApiMetadata.EmitTokens<IClass>(scope, xed);
            ApiMetadata.EmitTokens<IFormType>(scope, xed);
            ApiMetadata.EmitTokens<IsaKind>(scope, xed);
            ApiMetadata.EmitTokens<LookupKind>(scope, xed);
            ApiMetadata.EmitTokens<NonterminalKind>(scope, xed);
            ApiMetadata.EmitTokens<FieldKind>(scope, xed);
            ApiMetadata.EmitTokens<OperandWidthCode>(scope, xed);
            ApiMetadata.EmitTokens<OperandAction>(scope, xed);
            ApiMetadata.EmitTokens<PointerWidthKind>(scope, xed);
            ApiMetadata.EmitTokens<XedRegId>(scope, xed);
            ApiMetadata.EmitTokens<RegClassCode>(scope, xed);
        }
    }
}
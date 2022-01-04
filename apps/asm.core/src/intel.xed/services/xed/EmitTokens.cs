//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static XedModels;

    partial class IntelXed
    {
        public void EmitTokens()
        {
            EmitRawTokens();
            EmitTokenSummaries();
        }

        public void EmitTokenSummaries()
        {
            ApiMetadata.EmitApiTokens(xed, xed);
            ApiMetadata.EmitApiTokens(state,xed);
        }

        public void EmitRawTokens()
        {
            var scope = "xed/tokens";
            ApiMetadata.EmitTokens<AttributeKind>(scope, xed);
            ApiMetadata.EmitTokens<CategoryKind>(scope, xed);
            ApiMetadata.EmitTokens<ChipCode>(scope, xed);
            ApiMetadata.EmitTokens<CpuidBit>(scope, xed);
            ApiMetadata.EmitTokens<DataType>(scope, xed);
            ApiMetadata.EmitTokens<BaseTypeKind>(scope, xed);
            ApiMetadata.EmitTokens<EASZ>(scope, xed);
            ApiMetadata.EmitTokens<EOSZ>(scope, xed);
            ApiMetadata.EmitTokens<EncodingGroup>(scope, xed);
            ApiMetadata.EmitTokens<ExtensionKind>(scope, xed);
            ApiMetadata.EmitTokens<FormFacets>(scope, xed);
            ApiMetadata.EmitTokens<IClass>(scope, xed);
            ApiMetadata.EmitTokens<IFormType>(scope, xed);
            ApiMetadata.EmitTokens<IsaKind>(scope, xed);
            ApiMetadata.EmitTokens<LookupKind>(scope, xed);
            ApiMetadata.EmitTokens<NonterminalKind>(scope, xed);
            ApiMetadata.EmitTokens<OperandKind>(scope, xed);
            ApiMetadata.EmitTokens<OperandWidthType>(scope, xed);
            ApiMetadata.EmitTokens<OperandAction>(scope, xed);
            ApiMetadata.EmitTokens<PointerWidthKind>(scope, xed);
            ApiMetadata.EmitTokens<RegId>(scope, xed);
            ApiMetadata.EmitTokens<RegClassCode>(scope, xed);
        }
    }
}
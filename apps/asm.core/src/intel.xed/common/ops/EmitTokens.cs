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
        }
    }
}
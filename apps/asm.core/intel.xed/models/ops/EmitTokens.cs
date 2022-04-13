//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class IntelXed
    {
        const string xed = "xed";

        void EmitTokenSummaries()
        {
            ApiMetadata.EmitApiTokens(xed, xed);
        }
    }
}
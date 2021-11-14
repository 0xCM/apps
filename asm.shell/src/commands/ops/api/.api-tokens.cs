//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class AsmCmdService
    {
        [CmdOp(".api-tokens")]
        Outcome EmitTokens(CmdArgs args)
        {
            var catalog = ApiRuntimeLoader.catalog();
            var components = catalog.Components.Storage;
            var types = components.Enums().Tagged<SymSourceAttribute>();
            var tokens = Symbols.tokens("api",types);
            EmitTokens(tokens);
            return true;
        }

        void EmitTokens(ITokenSet src)
        {
            var project = Ws.Project("data.models");
            var dst = project.TablePath<SymInfo>("tokens", src.Name);
            var tokens = Symbols.syminfo(src.Types());
            TableEmit(tokens, SymInfo.RenderWidths, dst);
        }
    }
}
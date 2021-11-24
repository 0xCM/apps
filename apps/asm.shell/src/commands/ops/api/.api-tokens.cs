//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    partial class AsmCmdService
    {
        [CmdOp(".api-tokens")]
        Outcome EmitTokens(CmdArgs args)
        {
            var catalog = ApiRuntimeLoader.catalog();
            var components = catalog.Components.Storage;
            var tokens = Symbols.tokens("api", components.Enums().Tagged<SymSourceAttribute>());
            EmitTokens(tokens, Ws.Project("data.models"));
            return true;
        }

        public uint EmitTokens(ITokenSet src, IProjectWs project)
            => TableEmit(Symbols.syminfo(src.Types()), SymInfo.RenderWidths, project.TablePath<SymInfo>("tokens", src.Name));

        public uint EmitTokens(string name, Type[] types, FS.FilePath dst)
            => TableEmit(Symbols.syminfo(types), SymInfo.RenderWidths, dst);
    }
}
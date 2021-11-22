//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Reflection;

    partial class AsmCmdService
    {
        [CmdOp(".api-tokens")]
        Outcome EmitTokens(CmdArgs args)
        {
            var catalog = ApiRuntimeLoader.catalog();
            var components = catalog.Components.Storage;
            var tokens = Symbols.tokens("api",components.Enums().Tagged<SymSourceAttribute>());
            EmitTokens(tokens, Ws.Project("data.models"));
            return true;
        }

        public uint EmitTokens(ITokenSet src, IProjectWs project)
        {
            var descriptions = Symbols.syminfo(src.Types());
            var dst = project.TablePath<SymInfo>("tokens", src.Name);
            return TableEmit(descriptions, SymInfo.RenderWidths, dst);
        }

        public uint EmitTokens(string name, Type[] types, FS.FilePath dst)
        {
            var tokens = Symbols.tokens(name,types);
            var descriptions = Symbols.syminfo(tokens.Types());
            return TableEmit(descriptions, SymInfo.RenderWidths, dst);
        }
    }
}
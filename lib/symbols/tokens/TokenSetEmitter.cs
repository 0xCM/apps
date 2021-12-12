//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static core;
    public class TokenSetEmitter : AppService<TokenSetEmitter>
    {
        public uint EmitTokens(ITokenSet src, IProjectWs project)
        {
            var records = Symbols.syminfo(src.Types());
            var dst = project.TablePath<SymInfo>("tokens", src.Name);
            return TableEmit(records, SymInfo.RenderWidths, dst);
        }

        public uint EmitTokens(ITokenSet src, FS.FilePath dst)
        {
            var records = Symbols.syminfo(src.Types());
            return TableEmit(records, SymInfo.RenderWidths, dst);
        }

        public uint EmitTokens(string name, Type[] types, FS.FilePath dst)
        {
            var tokens = Tokens.set(name,types);
            var records = Symbols.syminfo(tokens.Types());
            return TableEmit(records, SymInfo.RenderWidths, dst);
        }
    }
}
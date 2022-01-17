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
        public Index<SymInfo> EmitTokens(ITokenSet src, FS.FilePath dst)
        {
            var records = Symbols.syminfo(src.Types());
            TableEmit(records.View, SymInfo.RenderWidths, dst);
            return records;
        }

        public Index<SymInfo> EmitTokens(string name, Type[] types, FS.FilePath dst)
        {
            var tokens = Tokens.set(name,types);
            var records = Symbols.syminfo(tokens.Types());
            TableEmit(records.View, SymInfo.RenderWidths, dst);
            return records;
        }
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    using static Root;
    using static core;

    partial class AsmCmdService
    {
        [CmdOp(".gen-token-specs")]
        Outcome GenTokenSpecs(CmdArgs args)
        {
            var result = Outcome.Success;
            var src = Symbols.concat(Symbols.index<AsmOpCodeTokens.ModRmToken>());
            var dst = Ws.Gen().Root + FS.file("token-specs", FS.Cs);
            var svc = Wf.Generators().StringLiterals();
            svc.Emit("ModRmTokens", src, dst);
            return result;
        }

        [CmdOp(".gen-int-string")]
        Outcome GenIntString(CmdArgs args)
        {
            var result = Outcome.Success;
            result = DataParser.parse(arg(args,0).Value, out uint min);
            result = DataParser.parse(arg(args,1).Value, out uint max);
            var values = list<string>();
            var name = string.Format("Range{0}To{1}", min, max);
            var n = max.ToString().Length;
            for(var i=min; i<=max; i++)
            {
                values.Add(i.ToString().PadLeft(n));
            }
            var svc = Wf.Generators().StringLiterals();
            var dst = Ws.Gen().Root + FS.file(name, FS.Cs);
            svc.Emit(name,values.ViewDeposited(), dst);
            return result;
        }

        [CmdOp(".tokenstrings")]
        Outcome EmitTokenStrings(CmdArgs args)
        {
            // "----\0----\0----\0"
            var result = Outcome.Success;
            var dst = text.buffer();
            var spec = new char[12];
            var j=0u;
            seek(spec,j++) = Chars.Dash;
            seek(spec,j++) = Chars.Dash;
            seek(spec,j++) = Chars.Dash;
            seek(spec,j++) = Chars.Null;

            seek(spec,j++) = Chars.Dash;
            seek(spec,j++) = Chars.Dash;
            seek(spec,j++) = Chars.Dash;
            seek(spec,j++) = Chars.Null;

            seek(spec,j++) = Chars.Dash;
            seek(spec,j++) = Chars.Dash;
            seek(spec,j++) = Chars.Dash;
            seek(spec,j++) = Chars.Null;

            var ts = TokenStrings.define(spec);
            Write(ts.TokenCount);

            return result;
        }
    }
}
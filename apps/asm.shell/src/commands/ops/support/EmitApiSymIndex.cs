//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static core;
    using static Root;

    partial class AsmCmdService
    {
        Index<SymLiteralRow> SymLiterals()
        {
            var catalog = State.ApiCatalog(ApiRuntimeLoader.catalog);
            return Symbols.literals(catalog.Components.Storage.Enums());
        }

        [CmdOp(".emit-sym-index")]
        Outcome EmitApiSymIndex(CmdArgs args)
        {
            var result = Outcome.Success;
            var literals = SymLiterals();
            var count = literals.Length;
            var counter = 0u;
            var dst = Ws.Tables().Subdir(WsAtoms.machine) + FS.file("symliterals", FS.Txt);
            using var writer = dst.UnicodeWriter();
            for(var i=0u; i<count; i++)
            {
                ref readonly var literal = ref literals[i];
                var name = literal.Name.Format();
                ref readonly var pos = ref literal.Position;
                var symbol = literal.Symbol.Format();
                ref readonly var scalar = ref literal.ScalarValue;
                var @class = literal.Class.IsNonEmpty ? literal.Class.Format() : EmptyString;
                var type =  empty(@class) ? literal.Type.Format() : (literal.Type.Format() + RP.embrace(@class));
                var desc = EmptyString;
                desc = string.Format("[{0:D5}:{1:D5}:{2}:{3}] = '{4}'", i, pos, type, name, symbol);;
                writer.WriteLine(desc);
            }

            return result;
        }
    }
}
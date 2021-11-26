//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.IO;

    using static core;

    partial class AsmCmdService
    {
        [CmdOp(".api-members")]
        Outcome ApiMembers(CmdArgs args)
        {
            var result = Outcome.Success;
            var entries = ApiCatalogs.LoadApiCatalog(ApiArchive.ApiCatalog());
            iter(entries, e => Write(e.OpUri));
            return result;
        }

        [CmdOp(".emit-symbol-span")]
        Outcome EmitSymIndex(CmdArgs srgs)
        {
            var result = Outcome.Success;
            var dst = Ws.Project("gen").Subdir("symbols") + FS.file("symindex", FS.Cs);
            var emitting = EmittingFile(dst);
            using var writer = dst.AsciWriter();
            EmitSymbolSpan<AsciLetterLoSym>("AsciLetterLoSym", writer);
            EmittedFile(emitting, 1);
            return result;
        }

        Outcome EmitSymbolSpan<E>(Identifier container, StreamWriter dst)
            where E : unmanaged, Enum
        {
            var result = Outcome.Success;
            var buffer = text.buffer();
            SpanRes.symrender<E>(container, buffer);
            dst.WriteLine(buffer.Emit());
            return result;
        }
    }
}
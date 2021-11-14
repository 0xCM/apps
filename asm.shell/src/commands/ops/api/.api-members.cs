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

        [CmdOp(".emit-sym-index")]
        Outcome EmitSymIndex(CmdArgs srgs)
        {
            var result = Outcome.Success;
            var dst = Ws.Tables().Subdir("tmp") + FS.file("symindex", FS.Cs);
            using var writer = dst.AsciWriter();
            EmitSymIndex<AsciLetterLoSym>("AsciLetterLoSym", writer);
            return result;
        }

        Outcome EmitSymIndex<E>(Identifier container, StreamWriter dst)
            where E : unmanaged, Enum
        {
            var result = Outcome.Success;
            var buffer = text.buffer();
            SpanRes.symrender<E>(container, buffer);
            dst.WriteLine(buffer.Emit());
            return result;
        }

       void EmitSymIndex<K>(FS.FilePath dst)
            where K : unmanaged, Enum
        {
            var src = Symbols.index<K>().View;
            var count = src.Length;
            if(count != 0)
            {
                var flow = Wf.EmittingFile(dst);
                using var writer = dst.Writer();
                writer.WriteLine(Symbols.header());
                for(var i=0; i<count; i++)
                    writer.WriteLine(skip(src,i));
                Wf.EmittedFile(flow, count);
            }
        }
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public sealed class AsmToolchain : AppService<AsmToolchain>
    {
        Outcome Exec(in CmdLine cmd)
        {
            var stdout = list<string>();
            var errout = list<string>();

            void OnStatus(in string data)
            {
                if(nonempty(data))
                    stdout.Add(data);
            }

            void OnError(in string data)
            {
                if(nonempty(data))
                    errout.Add(data);
            }

            var cmdrun = Wf.Running(cmd);
            var cmdproc = ScriptProcess.create(cmd, OnStatus, OnError);
            cmdproc.Wait();
            Wf.Ran(cmdrun);

            if(errout.Count == 0)
                return true;
            else
                return (false, errout.Delimit(Chars.NL).Format());
        }

        ByteSize EmitHexText(ReadOnlySpan<byte> src, ushort rowsize, FS.FilePath dst)
        {
            const char Delimiter = Chars.Pipe;
            var @base = MemoryAddress.Zero;
            var size = src.Length;
            var flow = Wf.EmittingFile(dst);
            using var writer = dst.AsciWriter();
            var formatter = HexDataFormatter.create(@base, rowsize, false);
            var buffer = alloc<byte>(rowsize);
            var parts = size/rowsize;
            var offset = @base;
            var data = default(ReadOnlySpan<byte>);
            for(var i=0; i<parts; i++)
            {
                data = slice(src,offset,rowsize);
                writer.WriteLine(formatter.FormatLine(data, offset, Delimiter));
                offset += rowsize;
            }

            var remainder = size % rowsize;
            if(remainder != 0)
            {
                data = slice(src, offset, remainder);
                writer.WriteLine(formatter.FormatLine(data, offset, Delimiter));
            }
            Wf.EmittedFile(flow,size);
            return size;
        }


        Outcome Run(CmdLine cmdline, FS.FilePath dst)
        {
            var stdout = list<string>();
            var errout = list<string>();
            var running = Wf.Running(cmdline);

            void OnStatus(in string data)
            {
                if(nonempty(data))
                    stdout.Add(data);
            }

            void OnError(in string data)
            {
                if(nonempty(data))
                    errout.Add(data);
            }

            using var writer = dst.AsciWriter();
            var process = ScriptProcess.create(cmdline, writer, OnStatus, OnError);
            process.Wait();
            stdout.Sort();
            Wf.Ran(running);

             if(errout.Count == 0)
                return true;
            else
                return (false, errout.Delimit(Chars.NL).Format());
       }
    }
}
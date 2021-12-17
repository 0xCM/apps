//-----------------------------------------------------------------------------
// Derivative Work
// Copyright  : Microsoft/.Net foundation
// Copyright  : (c) Chris Moore, 2020
// License    :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static Root;
    using static core;

    partial class ScriptProcess
    {
        [Op]
        public static Outcome run(CmdLine cmd, CmdVars vars, Receiver<string> status, Receiver<string> error, out ReadOnlySpan<TextLine> dst)
            => run(cmd, vars, FS.FilePath.Empty, status,error, out dst);

        [Op]
        public static Outcome run(CmdLine cmd, Receiver<string> status, Receiver<string> error, out ReadOnlySpan<TextLine> dst)
            => run(cmd, CmdVars.Empty, FS.FilePath.Empty, status,error, out dst);

        /// <summary>
        /// Executes a path-identified process and deposits the response to a specified path
        /// </summary>
        /// <param name="src">A path to an executable image</param>
        /// <param name="args">Process arguments</param>
        /// <param name="dst">The response target</param>
        public static Outcome run(FS.FilePath src, CmdArgs args, FS.FilePath dst)
        {
            var result = Outcome.Success;
            try
            {
                var cmd = new CmdLine(string.Format("{0} \"{1}\"", src.Format(PathSeparator.BS), args.Format()));
                var process = create(cmd).Wait();
                var lines =  Lines.read(process.Output);
                if(dst.IsNonEmpty)
                {
                    using var writer = dst.AsciWriter();
                    iter(lines, line => writer.WriteLine(line));
                }
                return true;
            }
            catch(Exception e)
            {
                dst = default;
                return e;
            }
        }

        [Op]
        public static Outcome run(CmdLine cmd, CmdVars vars, FS.FilePath log, Receiver<string> status, Receiver<string> error, out ReadOnlySpan<TextLine> dst)
        {
            try
            {
                var process = create(cmd, vars, status, error).Wait();
                var lines =  Lines.read(process.Output);
                if(log.IsNonEmpty)
                {
                    using var writer = log.AsciWriter();
                    iter(lines, line => writer.WriteLine(line));
                }
                dst = lines;
                return true;
            }
            catch(Exception e)
            {
                dst = default;
                return e;
            }
        }
    }
}
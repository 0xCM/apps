//-----------------------------------------------------------------------------
// Derivative Work
// Copyright  : Microsoft/.Net foundation
// Copyright  : (c) Chris Moore, 2020
// License    :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.IO;

    using static Root;

    partial class ScriptProcess
    {
        /// <summary>
        /// Creates a command process
        /// </summary>
        /// <param variable="commandLine">The command line to run as a subprocess</param>
        /// <param variable="options">Options for the process</param>
        [MethodImpl(Inline), Op]
        public static ScriptProcess create(CmdLine command, ScriptProcessOptions config)
            => new ScriptProcess(command, config);

        [MethodImpl(Inline), Op]
        public static ScriptProcess create(CmdLine cmd)
            => new ScriptProcess(cmd);

        [Op]
        public static ScriptProcess create(CmdLine cmd, CmdVars vars)
        {
            var options = new ScriptProcessOptions();
            include(vars, options);
            return new ScriptProcess(cmd, options);
        }

        [Op]
        public static ScriptProcess create(CmdLine cmd, CmdVars vars, Receiver<string> status, Receiver<string> error)
        {
            var options = new ScriptProcessOptions();
            include(vars, options);
            options.WithReceivers(status, error);
            return new ScriptProcess(cmd, options);
        }

        [Op]
        public static ScriptProcess create(CmdLine cmd, Receiver<string> status, Receiver<string> error)
        {
            var options = new ScriptProcessOptions();
            options.WithReceivers(status, error);
            return new ScriptProcess(cmd, options);
        }

        [MethodImpl(Inline), Op]
        public static ScriptProcess create(CmdLine cmd, TextWriter dst)
            => new ScriptProcess(cmd, new ScriptProcessOptions(dst));

        [MethodImpl(Inline), Op]
        public static ScriptProcess create(CmdLine cmd, TextWriter dst, Receiver<string> status, Receiver<string> error)
        {
            var options = new ScriptProcessOptions(dst);
            options.WithReceivers(status, error);
            return new ScriptProcess(cmd, options);
        }

        static void include(CmdVars src, ScriptProcessOptions dst)
        {
            foreach(var v in src)
            {
                if(v.IsNonEmpty)
                    dst.AddEnvironmentVariable(v.Name,v.Value);
            }
        }
    }
}
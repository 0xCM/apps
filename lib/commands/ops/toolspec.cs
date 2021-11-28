//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct Cmd
    {
        /// <summary>
        /// Creates a <see cref='ToolSpec'/>
        /// </summary>
        /// <param name="tool">The tool identifier</param>
        /// <param name="verbs"></param>
        [MethodImpl(Inline), Op]
        public static ToolSpec toolspec(ToolId tool, CmdFlagSpec[] flags, CmdOptionSpec[] options, CmdUsage syntax)
            => new ToolSpec(tool, flags, options, syntax);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ToolSpec toolspec<T>(CmdFlagSpec[] flags, CmdOptionSpec[] options, CmdUsage syntax)
            where T : unmanaged
                => new ToolSpec(typeof(T).Name, flags, options, syntax);
    }
}
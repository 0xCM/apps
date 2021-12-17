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
        /// Creates a <see cref='ToolCmdArgs'/> collection from an array
        /// </summary>
        /// <param name="src">The source array</param>
        [MethodImpl(Inline), Op]
        public static CmdScriptPattern pattern(string name, string content)
            => new CmdScriptPattern(name, content);
    }
}
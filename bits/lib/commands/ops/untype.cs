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
        /// Populates a <see cref='ToolCmdArg'/> structure from a specified source
        /// </summary>
        /// <param name="src">The data source</param>
        /// <typeparam name="T">The option value type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ToolCmdArg untype<T>(in ToolCmdArg<T> src)
        {
            var dst = new ToolCmdArg();
            untype(src, ref dst);
            return dst;
        }

        /// <summary>
        /// Populates a <see cref='ToolCmdArg'/> structure from a specified source
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="dst">The data target</param>
        /// <typeparam name="T">The option value type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref ToolCmdArg untype<T>(in ToolCmdArg<T> src, ref ToolCmdArg dst)
        {
            dst = new ToolCmdArg(src.Name, src.Value.ToString());
            return ref dst;
        }
    }
}
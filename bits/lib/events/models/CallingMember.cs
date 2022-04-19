//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using Caller = System.Runtime.CompilerServices.CallerMemberNameAttribute;
    using File = System.Runtime.CompilerServices.CallerFilePathAttribute;
    using Line = System.Runtime.CompilerServices.CallerLineNumberAttribute;

    /// <summary>
    /// Captures invocation origin details
    /// </summary>
    public struct CallingMember : ITextual
    {
        [MethodImpl(Inline), Op]
        public static CallingMember define([Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => new CallingMember(caller, file, line ?? 0);

        [MethodImpl(Inline), Op]
        public static ref CallingMember define(ref CallingMember dst, [Caller] string name = null, [CallerFilePath] string path = null, [Line] int? line = null)
        {
            dst.CallerName = name;
            dst.CallerFile = path;
            dst.CallerLine = (uint)(line ?? 0);
            return ref dst;
        }

        /// <summary>
        /// The originator name
        /// </summary>
        public Name CallerName;

        /// <summary>
        /// The name of the file from which the invocation occurred
        /// </summary>
        public Name CallerFile;

        /// <summary>
        /// The file-relative invocation line number
        /// </summary>
        public uint CallerLine;

        [MethodImpl(Inline)]
        public CallingMember(string name, string file, int line)
        {
            CallerName = name;
            CallerFile = file;
            CallerLine = (uint)line;
        }

        [MethodImpl(Inline)]
        public string Format()
            => string.Format("{0} | {1}:{2}", CallerName, CallerFile, CallerLine);

        public override string ToString()
            => Format();
    }
}
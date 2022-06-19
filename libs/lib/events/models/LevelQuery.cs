//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class XTend
    {
        [MethodImpl(Inline), Op]
        public static bool IsBabble(this LogLevel src)
            => src == LogLevel.Babble;

        [MethodImpl(Inline), Op]
        public static bool IsStatus(this LogLevel src)
            => src == LogLevel.Status;

        [MethodImpl(Inline), Op]
        public static bool IsWarning(this LogLevel src)
            => src == LogLevel.Warning;

        [MethodImpl(Inline), Op]
        public static bool IsError(this LogLevel src)
            => src == LogLevel.Error;
    }
}
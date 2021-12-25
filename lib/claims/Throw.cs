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

    [ApiHost]
    public readonly struct Throw
    {
        [MethodImpl(Inline), Op]
        static AppMsgSource origin([Caller]string caller = null, [File] string? file = null, [Line] int? line = null)
            => AppMsgSource.capture(caller, file, line);

        [Op]
        public static void e(Exception e)
            => throw e;

        public static T e<T>(Exception e)
            => throw e;

        [Op]
        public static void sourced(string msg, [Caller]string caller = null, [File] string? file = null, [Line] int? line = null)
            => sourced(msg, origin(caller,file,line));

        [Op]
        public static void message(string msg)
            => throw new Exception(msg);

        [Op]
        public static void message(Func<string> f)
            => throw new Exception(f());

        [Op]
        public static void sourced(string msg, in AppMsgSource src)
            => throw new Exception(string.Format("{0} {1}", msg, src.Format()));
    }
}
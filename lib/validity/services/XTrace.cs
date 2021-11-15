//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using Caller = System.Runtime.CompilerServices.CallerMemberNameAttribute;

    static class XTrace
    {
        public static string TracePrefix(object title, Type host, string caller)
            => string.Concat(PartResolution.Executing.Format(), Chars.FSlash, host.Name, Chars.FSlash, caller, Chars.LBrace, title, Chars.RBrace).PadRight(60);

        public static IAppMsg TraceMsg(object title, object msg, Type host, string caller, FlairKind color)
            => AppMsg.colorize(string.Concat(TracePrefix(title, host, caller), Chars.Pipe, Chars.Space, msg), color);

        public static IAppMsg TraceMsg(object msg, Type host, string caller, FlairKind color)
            => TraceMsg(string.Empty, msg, host, caller, color);

        public static void Trace(this IMessageQueue dst, IAppMsg msg)
            => dst.NotifyConsole(msg);

        public static void Trace(this IMessageQueue dst, object msg, Type host, [Caller] string caller = null)
            => dst.Trace(TraceMsg(msg, host, caller, FlairKind.Running));

        public static void Trace(this IMessageQueue dst, string title, object msg, FlairKind color, Type host, [Caller] string caller = null)
            => dst.Trace(TraceMsg(title, msg, host, caller, color));

        public static void Trace(this IMessageQueue dst, string title, string msg, Type host, [Caller] string caller = null)
            => dst.Trace(TraceMsg(title, msg, host, caller, FlairKind.Running));
    }
}
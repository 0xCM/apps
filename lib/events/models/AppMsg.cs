//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using Caller = System.Runtime.CompilerServices.CallerMemberNameAttribute;
    using File = System.Runtime.CompilerServices.CallerFilePathAttribute;
    using Line = System.Runtime.CompilerServices.CallerLineNumberAttribute;

    using static Root;

    /// <summary>
    /// Defines a message that encapsulates application diagnostic/status/error message content
    /// </summary>
    [ApiHost]
    public class AppMsg : IAppMsg
    {
        public AppMsgData Data {get;}

        public static MsgPattern<Count,Count> FieldCountMismatch
            => "The target requires {0} fields but {1} were found in the source";

        public static MsgPattern<string,string> ParseFailure
            => "Parsing {0} from {1} failed";

        public static MsgPattern<string> UriParseFailure
            => "Coult not parse '{0}' as a uri";

        public static MsgPattern<dynamic> NotFound
            => "{0} not found";

        public static MsgPattern<ApiHostUri> HostNotFound
            => "Host {0} not found";

        public static StatusMsg<T> status<T>(T data)
            => new StatusMsg<T>(data);

        [MethodImpl(Inline), Op]
        public static AppMsg called(object content, LogLevel kind, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => new AppMsg(content, kind, (FlairKind)kind, caller, file, line);

        [MethodImpl(Inline), Op]
        public static AppMsg error(object content, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => define($"{content} {caller} {line} {file}", LogLevel.Error);

        [MethodImpl(Inline), Op]
        public static AppMsg error(Exception e)
            => define(e.ToString(), LogLevel.Error);

        [MethodImpl(Inline), Op]
        public static AppMsg babble(object content)
            => new AppMsg(content, LogLevel.Babble, FlairKind.Disposed, EmptyString, EmptyString, null);

        [MethodImpl(Inline), Op]
        public static AppMsgSource source(string caller, string file, int? line)
            => new AppMsgSource(caller, file, line);

        [MethodImpl(Inline), Op]
        public static AppMsg define(object content, LogLevel kind)
            => new AppMsg(content, kind, (FlairKind)(kind), EmptyString, EmptyString, null);

        [MethodImpl(Inline), Op]
        public static AppMsg define(AppMsgData src)
            => new AppMsg(src);

        [MethodImpl(Inline), Op]
        public static AppMsg colorize(object content, FlairKind color)
            => new AppMsg(content, LogLevel.Status, color, string.Empty, EmptyString, null);

        [MethodImpl(Inline), Op]
        public static AppMsg info(object content)
            => new AppMsg(content, LogLevel.Status, FlairKind.Status, EmptyString, EmptyString, null);

        [MethodImpl(Inline), Op]
        public static AppMsg warn(object content)
            => new AppMsg(content, LogLevel.Warning, FlairKind.Warning, EmptyString, EmptyString, null);

        [MethodImpl(Inline)]
        AppMsg(object content, LogLevel kind, FlairKind color, string caller, string file, int? line)
            => Data = new AppMsgData(content,"{0}", kind, color, AppMsgSource.define(caller, file, line));

        [MethodImpl(Inline)]
        AppMsg(AppMsgData data)
            => Data = data;

        /// <summary>
        /// The message classification
        /// </summary>
        public LogLevel Kind
            => Data.Kind;

        /// <summary>
        /// The message foreground color when rendered for display
        /// </summary>
        public FlairKind Flair
            => Data.Flair;

        public string Format()
            => Data.Format();

        public override string ToString()
            => Format();

        public static AppMsg Empty => new AppMsg(AppMsgData.Empty);
    }
}
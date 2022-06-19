//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;

    using static Root;

    /// <summary>
    /// Specifies application message origination details
    /// </summary>
    [ApiHost]
    public readonly struct AppMsgSource : ITextual
    {
        [MethodImpl(Inline), Op]
        public static AppMsgSource capture([CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => new AppMsgSource(caller, file, line);

        [MethodImpl(Inline), Op]
        public static AppMsgSource define(string caller, string file, int? line)
            => new AppMsgSource(caller, file, line);

        /// <summary>
        /// The name of the member that originated the message
        /// </summary>
        public string Caller {get;}

        /// <summary>
        /// The path to the source file in which the message originated
        /// </summary>
        public string File {get;}

        /// <summary>
        /// The source file line number on which the message originated
        /// </summary>
        public uint Line {get;}

        [MethodImpl(Inline)]
        public AppMsgSource(string caller, string file, int? line)
        {
            Caller = caller;
            File = file ?? EmptyString;
            Line = (uint)(line ?? 0);
        }

        public string Format()
            => string.Format(RenderPattern, Path.GetFileName(File), Caller, Line, File);

        public override string ToString()
            => Format();

        public static AppMsgSource Empty
            => new AppMsgSource(EmptyString, EmptyString, 0);

        const string RenderPattern = "{0}/{1}?line = {2} | {3}";
    }
}
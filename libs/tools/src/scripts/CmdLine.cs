//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    /// <summary>
    /// Captures the content of a command-line
    /// </summary>
    public readonly struct CmdLine
    {
        [MethodImpl(Inline), Op]
        public static ToolCmdLine create(ToolId tool, params string[] src)
            => new ToolCmdLine(tool, CmdLine.create(src));

        [MethodImpl(Inline), Op]
        public static ToolCmdLine create(ToolId tool, CmdModifier modifier, params string[] src)
            => new ToolCmdLine(tool, modifier, CmdLine.create(src));

        public static CmdArg arg(in CmdArgs src, int index)
        {
            if(src.IsEmpty)
                sys.@throw(EmptyArgList.Format());

            var count = src.Length;
            if(count < index - 1)
                sys.@throw(ArgSpecError.Format());
            return src[(ushort)index];
        }

        static MsgPattern EmptyArgList => "No arguments specified";

        static MsgPattern ArgSpecError => "Argument specification error";

        [MethodImpl(Inline), Op]
        public static CmdLine create(params string[] src)
            => new CmdLine(src);

        readonly Index<string> Data;

        [MethodImpl(Inline)]
        public CmdLine(params string[] content)
            => Data = content;

        public ReadOnlySpan<CmdLinePart> Parts
        {
            [MethodImpl(Inline)]
            get => recover<string,CmdLinePart>(Data.Edit);
        }

        [MethodImpl(Inline)]
        public string Format()
            => text.delimit(Data.View, Chars.Space, 0);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator CmdLine(string src)
            => new CmdLine(src);

        [MethodImpl(Inline)]
        public static implicit operator CmdLine(string[] src)
            => new CmdLine(src);

        [MethodImpl(Inline)]
        public static implicit operator string(CmdLine src)
            => src.Format();

        public static CmdLine Empty
        {
            [MethodImpl(Inline)]
            get => new CmdLine(sys.empty<string>());
        }
    }
}
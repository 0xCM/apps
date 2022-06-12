//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct CmdScript
    {
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
        public static CmdLine cmdline(params string[] src)
            => new CmdLine(src);

        [MethodImpl(Inline), Op]
        public static ToolCmdLine cmdline(ToolId tool, params string[] src)
            => new ToolCmdLine(tool, cmdline(src));

        [MethodImpl(Inline), Op]
        public static ToolCmdLine cmdline(ToolId tool, CmdModifier modifier, params string[] src)
            => new ToolCmdLine(tool, modifier, cmdline(src));

        [MethodImpl(Inline), Op]
        public static CmdScriptExpr expr(CmdScriptPattern src)
            => new CmdScriptExpr(src);

        [MethodImpl(Inline), Op]
        public static CmdScriptExpr expr(CmdScriptPattern src, CmdVars vars)
            => new CmdScriptExpr(src, vars);

        /// <summary>
        /// Creates a <see cref='ToolCmdArgs'/> collection from an array
        /// </summary>
        /// <param name="src">The source array</param>
        [MethodImpl(Inline), Op]
        public static CmdScriptPattern pattern(string name, string content)
            => new CmdScriptPattern(name, content);

        /// <summary>
        /// Creates an identifiable <see cref='CmdScript'/> from a <see cref='CmdScriptExpr'/> sequence
        /// </summary>
        /// <param name="id">The identifier to assign</param>
        /// <param name="src">The source expressions</param>
        [MethodImpl(Inline), Op]
        public static CmdScript create(string id, CmdScriptExpr src)
            => new CmdScript(id, src);

        public Identifier Id {get;}

        readonly CmdScriptExpr Data;

        [MethodImpl(Inline)]
        public CmdScript(CmdScriptExpr src)
        {
            Id = EmptyString;
            Data = src;
        }

        [MethodImpl(Inline)]
        public CmdScript(string id, CmdScriptExpr src)
        {
            Id = id;
            Data = src;
        }

        public string Format()
            => Data.Format();

        public override string ToString()
            => Format();

        public CmdLine ToCmdLine()
            => new CmdLine(Format());

        public static CmdScript Empty
        {
            [MethodImpl(Inline)]
            get => new CmdScript(CmdScriptExpr.Empty);
        }

    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct CmdScript
    {
        [MethodImpl(Inline), Op]
        public static CmdScriptExpr expr(CmdScriptPattern pattern)
            => new CmdScriptExpr(pattern);

        [MethodImpl(Inline), Op]
        public static CmdScriptExpr expr(CmdScriptPattern pattern, CmdVars vars)
            => new CmdScriptExpr(pattern, vars);

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
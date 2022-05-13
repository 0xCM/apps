//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    public class CmdScriptPattern : TextTemplate
    {
        public static CmdScriptExpr format(in CmdScriptPattern pattern, params CmdVar[] args)
            => string.Format(pattern.Pattern, args.Select(a => a.Format()));

        public static CmdScriptExpr format<K>(in CmdScriptPattern pattern, params CmdVar<K>[] args)
            where K : unmanaged
                => string.Format(pattern.Pattern, args.Select(a => a.Format()));

        /// <summary>
        /// Creates a <see cref='ToolCmdArgs'/> collection from an array
        /// </summary>
        /// <param name="src">The source array</param>
        [MethodImpl(Inline), Op]
        public static CmdScriptPattern create(string name, string content)
            => new CmdScriptPattern(name, content);

        public Name Name {get;}

        [MethodImpl(Inline)]
        public CmdScriptPattern(TextBlock pattern)
            : base(pattern)
        {
            Name = EmptyString;
        }

        [MethodImpl(Inline)]
        public CmdScriptPattern(string name, TextBlock pattern)
            : base(pattern)
        {
            Name = name;
        }

        [MethodImpl(Inline)]
        public static implicit operator CmdScriptPattern(string src)
            => new CmdScriptPattern(src);

        [MethodImpl(Inline)]
        public static implicit operator CmdScriptPattern(Pair<string> src)
            => new CmdScriptPattern(src.Left, src.Right);

        public static CmdScriptPattern Empty
            => new CmdScriptPattern(EmptyString, EmptyString);
    }
}
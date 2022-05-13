//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct CmdScriptExpr
    {
        [MethodImpl(Inline), Op]
        public static CmdScriptExpr create(CmdScriptPattern pattern)
            => new CmdScriptExpr(pattern);

        [MethodImpl(Inline), Op]
        public static CmdScriptExpr create(CmdScriptPattern pattern, CmdVars vars)
            => new CmdScriptExpr(pattern, vars);

        public CmdScriptPattern Pattern {get;}

        public CmdVars Variables {get;}

        [MethodImpl(Inline)]
        public CmdScriptExpr(string pattern)
        {
            Pattern = pattern;
            Variables = Cmd.vars();
        }

        [MethodImpl(Inline)]
        public CmdScriptExpr(CmdScriptPattern pattern)
        {
            Pattern = pattern;
            Variables = Cmd.vars();
        }

        [MethodImpl(Inline)]
        public CmdScriptExpr(CmdScriptPattern pattern, CmdVars vars)
        {
            Pattern = pattern;
            Variables = vars;
        }

        public string Format()
            => Pattern.Format();

        public string Id
        {
            [MethodImpl(Inline)]
            get => Pattern.Name;
        }

        public ref CmdVar this[byte index]
        {
            [MethodImpl(Inline)]
            get => ref Variables[index];
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Pattern.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Pattern.IsNonEmpty;
        }

        [MethodImpl(Inline)]
        public static implicit operator CmdScriptExpr(string src)
            => new CmdScriptExpr(src);

        [MethodImpl(Inline)]
        public static implicit operator CmdScriptExpr(CmdScriptPattern src)
            => new CmdScriptExpr(src);

        public static CmdScriptExpr Empty => new CmdScriptExpr(EmptyString);
    }
}
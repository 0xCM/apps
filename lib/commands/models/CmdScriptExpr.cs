//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct CmdScriptExpr : ICmdScriptExpr
    {
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

        [MethodImpl(Inline)]
        public static implicit operator string(CmdScriptExpr src)
            => src.Pattern;

        [MethodImpl(Inline)]
        public string Format()
            => Cmd.format(this);

        public override string ToString()
            => Format();

        public static CmdScriptExpr Empty => new CmdScriptExpr(EmptyString);
    }
}
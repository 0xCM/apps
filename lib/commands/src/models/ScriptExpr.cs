//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct ScriptExpr : ICmdScriptExpr
    {
        public ScriptPattern Pattern {get;}

        public CmdVars Variables {get;}

        [MethodImpl(Inline)]
        public ScriptExpr(string pattern)
        {
            Pattern = pattern;
            Variables = Cmd.vars();
        }

        [MethodImpl(Inline)]
        public ScriptExpr(ScriptPattern pattern)
        {
            Pattern = pattern;
            Variables = Cmd.vars();
        }

        [MethodImpl(Inline)]
        public ScriptExpr(ScriptPattern pattern, CmdVars vars)
        {
            Pattern = pattern;
            Variables = vars;
        }

        public string Id
        {
            [MethodImpl(Inline)]
            get => Pattern.PatternId;
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
        public static implicit operator ScriptExpr(string src)
            => new ScriptExpr(src);

        [MethodImpl(Inline)]
        public static implicit operator ScriptExpr(ScriptPattern src)
            => new ScriptExpr(src);

        [MethodImpl(Inline)]
        public static implicit operator string(ScriptExpr src)
            => src.Pattern;

        [MethodImpl(Inline)]
        public string Format()
            => Cmd.format(this);

        public override string ToString()
            => Format();
    }
}
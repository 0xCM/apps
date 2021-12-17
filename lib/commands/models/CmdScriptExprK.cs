//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct CmdScriptExpr<K> : ICmdScriptExpr
        where K : unmanaged
    {
        public CmdScriptPattern Pattern {get;}

        public Index<CmdVar<K>> Variables {get;}

        [MethodImpl(Inline)]
        public CmdScriptExpr(CmdScriptPattern pattern, Index<CmdVar<K>> vars)
        {
            Pattern = pattern;
            Variables = vars;
        }

        public string Id
        {
            [MethodImpl(Inline)]
            get => Pattern.Name;
        }

        public ref CmdVar<K> this[byte index]
        {
            [MethodImpl(Inline)]
            get => ref Variables[index];
        }

        [MethodImpl(Inline)]
        public static implicit operator string(CmdScriptExpr<K> src)
            => src.Format();

       [MethodImpl(Inline)]
        public string Format()
            => Cmd.format(this);

        public override string ToString()
            => Format();
     }
}
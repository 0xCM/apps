//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct CmdScript : ITextual
    {
        public Identifier Id {get;}

        readonly Index<CmdScriptExpr> Data;

        [MethodImpl(Inline)]
        public CmdScript(CmdScriptExpr[] src)
        {
            Id = EmptyString;
            Data = src;
        }

        [MethodImpl(Inline)]
        public CmdScript(string id, CmdScriptExpr[] src)
        {
            Id = id;
            Data = src;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Data.Length;
        }

        public Span<CmdScriptExpr> Edit
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public ReadOnlySpan<CmdScriptExpr> View
        {
            [MethodImpl(Inline)]
            get => Data;
        }


        [MethodImpl(Inline)]
        public static implicit operator CmdScript(CmdScriptExpr[] src)
            => new CmdScript(src);

        public string Format()
            => Cmd.format(this);

        public override string ToString()
            => Format();

        public static CmdScript Empty
        {
            get => new CmdScript(core.array<CmdScriptExpr>());
        }
    }
}
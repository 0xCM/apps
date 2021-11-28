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

        readonly Index<ScriptExpr> Data;

        [MethodImpl(Inline)]
        public CmdScript(ScriptExpr[] src)
        {
            Id = EmptyString;
            Data = src;
        }

        [MethodImpl(Inline)]
        public CmdScript(string id, ScriptExpr[] src)
        {
            Id = id;
            Data = src;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Data.Length;
        }

        public Span<ScriptExpr> Edit
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public ReadOnlySpan<ScriptExpr> View
        {
            [MethodImpl(Inline)]
            get => Data;
        }


        [MethodImpl(Inline)]
        public static implicit operator CmdScript(ScriptExpr[] src)
            => new CmdScript(src);

        public string Format()
            => Cmd.format(this);

        public override string ToString()
            => Format();

        public static CmdScript Empty
        {
            get => new CmdScript(core.array<ScriptExpr>());
        }
    }
}
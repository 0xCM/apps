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

        public static CmdScript Empty
        {
            [MethodImpl(Inline)]
            get => new CmdScript(CmdScriptExpr.Empty);
        }

        public CmdLine ToCmdLine()
            => new CmdLine(Format());
    }
}
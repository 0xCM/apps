//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct CmdScript
    {
        public readonly Identifier Id;

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
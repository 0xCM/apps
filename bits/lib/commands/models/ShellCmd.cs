//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public abstract class ShellCmd
    {
        public static SetCmd set(Identifier name, CmdScriptExpr value)
            => new SetCmd(name,value);

        public Name CmdName {get;}

        public CmdScriptExpr CmdExpr {get;}

        protected ShellCmd(Name name, CmdScriptExpr expr)
        {
            CmdName = name;
            CmdExpr = expr;
        }

        public abstract string Format();

        public class SetCmd : ShellCmd
        {
            public SetCmd(Identifier name, CmdScriptExpr value)
                : base(name,value)
            {


            }

            public override string Format()
                => string.Format("{0}={1}", CmdName, CmdExpr);
        }
    }
}
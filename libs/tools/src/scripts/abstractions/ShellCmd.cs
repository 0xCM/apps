//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class ScriptCmd<C>
        where C : ScriptCmd<C>, new()
    {
        public Name CmdName {get;}

        public CmdVars Vars {get; set;}

        public abstract CmdScriptPattern Pattern {get;}

        protected ScriptCmd(Name name)
        {
            CmdName = name;
            Vars = CmdVars.create();
        }

        public abstract string Format();


    }
}
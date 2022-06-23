//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class CmdDef : ICmdDef
    {
        public abstract CmdKind CmdKind {get;}
    }

    public abstract class CmdDef<D> : CmdDef
        where D : CmdDef<D>
    {

    }
}
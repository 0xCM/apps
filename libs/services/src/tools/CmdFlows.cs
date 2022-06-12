//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IDataNode<K,D>
    {
        K Id {get;}

        D Def {get;}
    }

    public class CmdFlows
    {
        [MethodImpl(Inline)]
        public static CmdFlow<T> flow<T>(IActor actor, T src, T dst)
            => new CmdFlow<T>(actor,src,dst);
    }
}
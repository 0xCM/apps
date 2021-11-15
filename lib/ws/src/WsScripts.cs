//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IWsScripts
    {

    }

    public abstract class WsScripts<T> : IWsScripts
        where T : WsScripts<T>, new()
    {
        public static T create() => new T();
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct AppRes<T> : IAppRes<T>
    {
        public string Name {get;}

        public T Content {get;}

        [MethodImpl(Inline)]
        public AppRes(string name, T data)
        {
            Name = name;
            Content = data;
        }
    }
}
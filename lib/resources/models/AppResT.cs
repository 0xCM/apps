//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

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
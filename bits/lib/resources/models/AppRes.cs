//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct AppRes : IAppRes<string>
    {
        public string Name {get;}

        public string Content {get;}

        [MethodImpl(Inline)]
        public AppRes(string name, string data)
        {
            Name = name;
            Content = data;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => core.blank(Content);
        }

        public string Format()
            => Content;

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator AppRes<string>(AppRes src)
            => new AppRes<string>(src.Name,src.Content);

        public static AppRes Empty
            => new AppRes(EmptyString, EmptyString);
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Sqlite
    {
        public readonly struct Command
        {
            public TextBlock Content {get;}

            [MethodImpl(Inline)]
            public Command(string content)
            {
                Content = content;
            }

            [MethodImpl(Inline)]
            public static implicit operator Command(string src)
                => new Command(src);
        }
    }
}
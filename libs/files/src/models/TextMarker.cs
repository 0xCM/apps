//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class TextMarker
    {
        public string Name {get;}

        public string Content {get;}

        [MethodImpl(Inline)]
        public TextMarker(string id, string content)
        {
            Name = id;
            Content = content;
        }

        public uint Length
        {
            [MethodImpl(Inline)]
            get => (uint)Content.Length;
        }

        public string Format()
            => Content;

        public override string ToString()
            => Format();
    }
}
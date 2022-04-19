//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct JsonPacket<T>
    {
        public T Content {get;}

        /// <summary>
        /// The content type identifier
        /// </summary>
        public string Type {get;}

        [MethodImpl(Inline)]
        public JsonPacket(T content)
        {
            Content = content;
            Type = typeof(T).FullName;
        }

        [MethodImpl(Inline)]
        public JsonPacket(T content, string type)
        {
            Content = content;
            Type = type;
        }

        [MethodImpl(Inline)]
        public static implicit operator JsonPacket<T>(T src)
            => new JsonPacket<T>(src);

        [MethodImpl(Inline)]
        public static implicit operator JsonPacket(JsonPacket<T> src)
            => new JsonPacket(src.Content, src.Type);
    }
}
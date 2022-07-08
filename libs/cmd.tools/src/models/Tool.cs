//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct Tool : ITool
    {
        public readonly Actor ToolId;

        [MethodImpl(Inline)]
        public Tool(Actor id)
        {
            ToolId = id;
        }

        public string Format()
            => ToolId.Format();

        public override string ToString()
            => Format();

        Actor ITool.ToolId
            => ToolId;

        [MethodImpl(Inline)]
        public static implicit operator Tool(Actor id)
            => new Tool(id);

        [MethodImpl(Inline)]
        public static implicit operator Actor(Tool src)
            => src.ToolId;

        [MethodImpl(Inline)]
        public static implicit operator Tool(string src)
            => new Tool(src);


        public static Tool Empty => new Tool(Actor.Empty);
    }
}
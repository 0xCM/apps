//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct Tool : ITool
    {
        public readonly ToolId ToolId;

        [MethodImpl(Inline)]
        public Tool(ToolId id)
        {
            ToolId = id;
        }

        public string Name
            => ToolId.Format();

        public string Format()
            => Name;

        public override string ToString()
            => Format();

        ToolId ITool.ToolId
            => ToolId;

        [MethodImpl(Inline)]
        public static implicit operator Tool(ToolId id)
            => new Tool(id);

        [MethodImpl(Inline)]
        public static implicit operator Actor(Tool tool)
            => new Actor(tool.Name);

        [MethodImpl(Inline)]
        public static implicit operator Tool(Actor src)
            => new Tool(src.Name);

        public static Tool Empty => new Tool(ToolId.Empty);
    }
}
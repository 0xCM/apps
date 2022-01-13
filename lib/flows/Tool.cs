//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct Tool : ITool
    {
        public ToolId ToolId {get;}

        [MethodImpl(Inline)]
        public Tool(ToolId id)
        {
            ToolId = id;
        }

        public Identifier Name
            => ToolId.Format();

        public string Format()
            => Name;

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Tool(ToolId id)
            => new Tool(id);

        public static Tool Empty => new Tool(ToolId.Empty);
    }
}
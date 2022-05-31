//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct LiteralProvider
    {
        public readonly PartId Part;

        public readonly string Name;

        public readonly Type Definition;

        [MethodImpl(Inline)]
        public LiteralProvider(string name, Type src, PartId part)
        {
            Definition = src;
            Name = name;
            Part = part;
        }
    }
}
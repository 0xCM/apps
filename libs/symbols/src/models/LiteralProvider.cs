//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct LiteralProvider
    {
        public readonly PartId Part;

        public readonly Type Type;

        public readonly StringAddress Group;

        public readonly StringAddress Name;

        [MethodImpl(Inline)]
        public LiteralProvider(PartId part, Type type, StringAddress group, StringAddress name)
        {
            Type = type;
            Name = name;
            Part = part;
            Group = group;
        }
    }
}
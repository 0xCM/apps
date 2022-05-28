//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct LiteralProvider
    {
        public readonly string Name;

        public readonly Type Definition;

        public readonly PartId Part;

        [MethodImpl(Inline)]
        public LiteralProvider(string name, Type src)
        {
            Definition = src;
            Name = name;
            Part = src.Assembly.Id();
        }
    }
}
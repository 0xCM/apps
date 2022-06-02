//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public readonly record struct ApiDataType : IComparable<ApiDataType>
    {
        public readonly Type Definition;

        public readonly DataSize Size;

        [MethodImpl(Inline)]
        public ApiDataType(Type def, DataSize size)
        {
            Definition = def;
            Size = size;
        }

        public string Name
        {
            [MethodImpl(Inline)]
            get => Definition.DisplayName();
        }

        public Assembly Assembly
        {
            [MethodImpl(Inline)]
            get => Definition.Assembly;
        }

        public PartId Part
        {
            [MethodImpl(Inline)]
            get => Assembly.Id();
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => hash(Definition.AssemblyQualifiedName);
        }

        public int CompareTo(ApiDataType src)
        {
            var result = Part.Format().CompareTo(src.Part.Format());
            if(result == 0)
                Name.CompareTo(src.Name);
            return result;
        }

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public bool Equals(ApiDataType src)
            => Definition.Equals(src.Definition);
    }
}
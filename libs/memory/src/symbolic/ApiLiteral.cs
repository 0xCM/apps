//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a compile-time literal value
    /// </summary>
    [StructLayout(StructLayout, Pack=1), Record(TableId)]
    public struct ApiLiteral : IComparable<ApiLiteral>
    {
        const string TableId = "api.literals";

        [Render(16)]
        public PartId Part;

        [Render(32)]
        public string Group;

        [Render(32)]
        public string Type;

        [Render(32)]
        public string Name;

        [Render(12)]
        public string Kind;

        [Render(12)]
        public uint Length;

        [Render(1)]
        public RuntimeLiteralValue<string> Value;

        public int CompareTo(ApiLiteral src)
        {
            var result = Part.PartName().CompareTo(src.Part.PartName());
            if(result == 0)
            {
                result = Type.CompareTo(src.Type);
                if(result == 0)
                    Name.CompareTo(src.Name);
            }

            return result;
        }

        public static ApiLiteral Empty => default;
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = BitPatterns;

    public class BitPattern
    {
        /// <summary>
        /// The pattern definition
        /// </summary>
        public readonly BitPatternDef Def;

        /// <summary>
        /// The width of the data represented by the pattern
        /// </summary>
        public readonly byte DataWidth;

        /// <summary>
        /// The minimum amount of storage required to store the represented data
        /// </summary>
        public readonly NativeSize MinSize;

        /// <summary>
        /// A data type with size of <see cref='MinSize'/> or greater
        /// </summary>
        public readonly Type DataType;

        /// <summary>
        /// The segments in the field
        /// </summary>
        public readonly Index<BfSegModel> Segments;

        /// <summary>
        /// A semantic identifier
        /// </summary>
        public readonly string Descriptor;

        internal BitPattern(BfOrigin origin, asci64 data, asci32 name, byte width, Type datatype, NativeSize minsize, Index<BfSegModel> segments, string descriptor)
        {
            Def = api.define(name, origin, data);
            DataWidth = width;
            DataType = datatype;
            MinSize = minsize;
            Segments = segments;
            Descriptor = descriptor;
        }

        /// <summary>
        /// The pattern source
        /// </summary>
        public ref readonly BfOrigin Origin
        {
            [MethodImpl(Inline)]
            get => ref Def.Origin;
        }

        /// <summary>
        /// The pattern specification
        /// </summary>
        public ref readonly asci64 Content
        {
            [MethodImpl(Inline)]
            get => ref Def.Data;
        }

        /// <summary>
        /// The pattern name
        /// </summary>
        public ref readonly asci32 Name
        {
            [MethodImpl(Inline)]
            get => ref Def.Name;
        }

        public string Format()
            => Descriptor;

        public override string ToString()
            => Format();
    }
}
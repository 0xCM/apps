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
        /// The pattern source
        /// </summary>
        public readonly BfOrigin Origin;

        /// <summary>
        /// The pattern specification
        /// </summary>
        public readonly string Content;

        /// <summary>
        /// The pattern name
        /// </summary>
        public readonly string Name;

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

        internal BitPattern(BfOrigin orign, string content, string name, byte width, Type datatype, NativeSize minsize, Index<BfSegModel> segments, string descriptor)
        {
            Origin = orign;
            Content = content;
            Name = name;
            DataWidth = width;
            DataType = datatype;
            MinSize = minsize;
            Segments = segments;
            Descriptor = descriptor;
        }

        public string Format()
            => Descriptor;

        public override string ToString()
            => Format();

        public static implicit operator BitPattern(string src)
            =>  api.originate(src);

        public static BitPattern operator +(BitPattern a, BitPattern b)
            => api.concat(a,b);
    }
}
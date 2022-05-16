//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = BitPatterns;

    public class BitPatternCalcs
    {
        public readonly BitPatternDef Def;

        [MethodImpl(Inline)]
        public BitPatternCalcs(in BitPatternDef def)
        {
            Def = def;
        }

        /// <summary>
        /// The width of the data represented by the pattern
        /// </summary>
        [MethodImpl(Inline)]
        public byte DataWidth()
            => api.datawidth(Content);

        /// <summary>
        /// The minimum amount of storage required to store the represented data
        /// </summary>
        [MethodImpl(Inline)]
        public NativeSize MinSize()
            => api.minsize(Content);

        /// <summary>
        /// A data type with size of <see cref='MinSize'/> or greater
        /// </summary>
        [MethodImpl(Inline)]
        public Type DataType()
            => api.datatype(Content);

        /// <summary>
        /// The segments in the field
        /// </summary>
        [MethodImpl(Inline)]
        public Index<BfSegModel> Segments()
            => api.segments(Content);

        public Index<byte> SegWidths()
            => api.segwidths(Content);

        /// <summary>
        /// A semantic identifier
        /// </summary>
        [MethodImpl(Inline)]
        public string Descriptor()
            => api.descriptor(Content);

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
            get => ref Def.Content;
        }

        public string BitString(ulong value)
            => api.bitstring(Def, value);
    }
}
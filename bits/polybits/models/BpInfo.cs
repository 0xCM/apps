//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class BpInfo
    {
        /// <summary>
        /// The pattern definition
        /// </summary>
        public readonly BpDef Def;

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
        public readonly Index<BfSegModel> Segs;

        /// <summary>
        /// A semantic identifier
        /// </summary>
        public readonly string Descriptor;

        /// <summary>
        /// An elaborated definition
        /// </summary>
        public readonly BpSpec Spec;

        internal BpInfo(in BpDef def, byte width, Type datatype, NativeSize minsize, Index<BfSegModel> segs, string descriptor)
        {
            Def = def;
            DataWidth = width;
            DataType = datatype;
            MinSize = minsize;
            Segs = segs;
            Descriptor = descriptor;
            Spec = BitPatterns.spec(this);
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
            get => ref Def.Content;
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
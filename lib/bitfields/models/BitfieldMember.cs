//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct BitfieldMember
    {
        public static string format(in BitfieldMember src)
        {
            var width = src.SegWidth;
            if(width == 0)
                return EmptyString;
            if(width == 1)
                return string.Format("{0}[{1}]", src.Name, src.MinIndex);
            else
                return string.Format("{0}[{1}:{2}]", src.Name, src.MaxIndex, src.MinIndex);
        }


        public string Name {get;}

        public byte MinIndex {get;}

        public byte MaxIndex {get;}

        public BitMask Mask {get;}

        [MethodImpl(Inline)]
        public BitfieldMember(string name, byte min, byte max, BitMask mask)
        {
            Name = name;
            MinIndex = min;
            MaxIndex = max;
            Mask = mask;
        }

        public byte SegWidth
        {
            [MethodImpl(Inline)]
            get => bits.segwidth(MinIndex,MaxIndex);
        }

        public string Format()
            => format(this);

        public override string ToString()
            => Format();
    }
}
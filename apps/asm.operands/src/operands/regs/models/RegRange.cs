//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [StructLayout(LayoutKind.Sequential, Pack=1, Size =4)]
    public readonly struct RegRange
    {
        public RegClass Class {get;}

        public RegIndex MinIndex {get;}

        public RegIndex MaxIndex {get;}

        [MethodImpl(Inline)]
        public RegRange(RegClass @class, RegIndex i0, RegIndex i1)
        {
            Class = @class;
            MinIndex = i0;
            MaxIndex = i1;
        }

        public string Format()
            => string.Format("{0}[{1}..{2}]", Class, MinIndex, MaxIndex);

        public override string ToString()
            => Format();
    }
}
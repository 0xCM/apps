//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static AsmPrefixCodes;

    public struct RepPrefix : IAsmPrefix<RepPrefixCode>, IAsmByte<RepPrefix>
    {
        public RepPrefixCode _Code;

        [MethodImpl(Inline)]
        public RepPrefix(RepPrefixCode src)
        {
            _Code = src;
        }

        [MethodImpl(Inline)]
        public byte Value()
            => (byte)_Code;

        public byte Encoded
        {
            [MethodImpl(Inline)]
            get => (byte)_Code;
        }

        [MethodImpl(Inline)]
        public RepPrefixCode Code()
            => _Code;

        [MethodImpl(Inline)]
        public void Code(RepPrefixCode src)
            => _Code = src;

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => _Code == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => _Code != 0;
        }

        public override string ToString()
            => Format();

        public string Format()
            => AsmRender.asmbyte(this);

        [MethodImpl(Inline)]
        public static implicit operator RepPrefix(RepPrefixCode src)
            => new RepPrefix(src);

        [MethodImpl(Inline)]
        public static implicit operator byte(RepPrefix src)
            => (byte)src._Code;
    }
}
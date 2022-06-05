//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ObjSymClass : IEquatable<ObjSymClass>
    {
        public readonly ObjSymKind Kind;

        public readonly ObjSymCode Code;

        [MethodImpl(Inline)]
        public ObjSymClass(ObjSymCode code)
        {
            Code = code;
            Kind = ObjSymCalcs.kind(code);
        }

        [MethodImpl(Inline)]
        public ushort Pack()
            => math.or((ushort)Kind, math.sll((ushort)Code, 4));

        [MethodImpl(Inline)]
        public bool Equals(ObjSymClass src)
            => Code == src.Code;

        public override bool Equals(object src)
            => src is ObjSymClass c && Equals(c);

        public override int GetHashCode()
            => (byte)Code;

        [MethodImpl(Inline)]
        public static implicit operator ObjSymClass(ObjSymCode src)
            => new ObjSymClass(src);

        [MethodImpl(Inline)]
        public static implicit operator ObjSymCode(ObjSymClass src)
            => src.Code;

        [MethodImpl(Inline)]
        public static implicit operator ObjSymKind(ObjSymClass src)
            => src.Kind;
    }
}
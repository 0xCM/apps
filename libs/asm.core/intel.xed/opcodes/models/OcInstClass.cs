//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly record struct OcInstClass : IComparable<OcInstClass>
        {
            public readonly Hex32 Id;

            public readonly InstClass InstClass;

            public readonly XedOpCode OpCode;

            public readonly byte ClassIndex;

            [MethodImpl(Inline)]
            public OcInstClass(uint id, InstClass @class, XedOpCode opcode, byte index)
            {
                Id = id;
                InstClass = @class;
                OpCode = opcode;
                ClassIndex = index;
            }

            public Hex32 Hash
            {
                [MethodImpl(Inline)]
                get => Id;
            }

            public override int GetHashCode()
                => (int)Hash;

            public int CompareTo(OcInstClass src)
            {
                var result = OpCode.CompareTo(src.OpCode);
                if(result == 0)
                    result = InstClass.CompareTo(src.InstClass);
                return result;
            }

            public string Format()
            {
                var b0 = (byte)Id;
                Hex4 oci = (byte)b0;
                Hex4 seq = (byte)(b0 >> 4);
                Hex8 ocb = (byte)(Id >> 8);
                Hex16 @class = (ushort)(Id >> 16);
                return string.Format("{0} {1} {2} {3}", oci, seq, ocb, @class);
            }
            public override string ToString()
                => Format();

            public static OcInstClass Empty => default;
        }
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedModels;

    partial class XedRules
    {
        public readonly struct OcInstClass : IComparable<OcInstClass>, IEquatable<OcInstClass>
        {
            public readonly uint PatternId;

            public readonly XedOpCode OpCode;

            public readonly InstClass InstClass;

            [MethodImpl(Inline)]
            public OcInstClass(uint pattern, XedOpCode oc, InstClass @class)
            {
                PatternId = pattern;
                OpCode = oc;
                InstClass = @class;
            }

            public OpCodeClass OcClass
            {
                [MethodImpl(Inline)]
                get => OpCode.Class;
            }

            public MachineMode Mode
            {
                [MethodImpl(Inline)]
                get => OpCode.Mode;
            }

            public AsmOcValue OcValue
            {
                [MethodImpl(Inline)]
                get => OpCode.Value;
            }

            public Hash32 Hash
            {
                [MethodImpl(Inline)]
                get => alg.hash.combine(OpCode.Hash, (uint)InstClass.Kind);
            }

            [MethodImpl(Inline)]
            public bool Equals(OcInstClass src)
                => OpCode == src.OpCode && InstClass == src.InstClass;

            public override int GetHashCode()
                => Hash;

            public override bool Equals(object src)
                => src is OcInstClass x && Equals(x);

            public int CompareTo(OcInstClass src)
            {
                var result = OpCode.CompareTo(src.OpCode);
                if(result == 0)
                    result = InstClass.CompareTo(src.InstClass);
                return result;
            }

            public string Format()
                => string.Format("{0}[{1}:{2}]={3}", OpCode.Class, XedOpCodes.selector(OpCode.Kind), OpCode.Value, InstClass);

            public override string ToString()
                => Format();

            public static OcInstClass Empty => default;
        }
    }
}
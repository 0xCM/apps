//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class XedRules
    {
        public record struct InstGroupSeq : IComparable<InstGroupSeq>
        {
            public byte Index;

            public ushort PatternId;

            public MachineMode Mode;

            public InstClass Class;

            public ModKind Mod;

            public InstLock Lock;

            public XedOpCode OpCode;

            public int CompareTo(InstGroupSeq src)
            {
                var result = Class.CompareTo(src.Class);
                if(result == 0)
                {
                    result = OpCode.CompareTo(src.OpCode);

                    if(result==0)
                    {
                        result = Mod.CompareTo(src.Mod);
                        if(result==0)
                            result = Lock.CompareTo(src.Lock);
                    }

                }
                return result;
            }
        }
    }
}
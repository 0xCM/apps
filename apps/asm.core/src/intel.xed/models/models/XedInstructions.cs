//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct XedInstructions
    {
        Index<XedInstInfo> _Descriptions {get;}

        Index<XedInstOperand> _Operands {get;}

        public XedInstructions(XedInstInfo[] entries, XedInstOperand[] operands)
        {
            _Descriptions = entries;
            _Operands = operands;
        }

        public uint OperandCount
        {
            [MethodImpl(Inline)]
            get => _Operands.Count;
        }

        public uint InstCount
        {
            [MethodImpl(Inline)]
            get => _Descriptions.Count;
        }

        public ReadOnlySpan<XedInstInfo> Descriptions
        {
            [MethodImpl(Inline)]
            get => _Descriptions;
        }

        public ReadOnlySpan<XedInstOperand> Operands
        {
            [MethodImpl(Inline)]
            get => _Operands;
        }

        [MethodImpl(Inline)]
        public ref readonly XedInstInfo Instruction(ushort index)
            => ref _Descriptions[index];

        [MethodImpl(Inline)]
        public ref readonly XedInstOperand Operand(uint index)
            => ref _Operands[index];

        public static XedInstructions Empty => new XedInstructions(sys.empty<XedInstInfo>(), sys.empty<XedInstOperand>());
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    partial struct XedModels
    {
        public struct RuleOperand
        {
            public RuleOpName Name;

            public object Value;

            [MethodImpl(Inline)]
            public RuleOperand(RuleOpName name, byte value)
            {
                Name = name;
                Value = value;
            }

            [MethodImpl(Inline)]
            public RuleOperand(RuleOpName name, Register value)
            {
                Name = name;
                Value = value;
            }

            [MethodImpl(Inline)]
            public RuleOperand(RuleOpName name, text31 value)
            {
                Name = name;
                Value = value;
            }

            [MethodImpl(Inline)]
            public RuleOperand(RuleOpName name, Imm value)
            {
                Name = name;
                Value = value;
            }

            [MethodImpl(Inline)]
            public RuleOperand(RuleOpName name, Disp value)
            {
                Name = name;
                Value = value;
            }

            public bool Reg(out Register dst)
            {
                if(Value is Register r)
                {
                    dst = r;
                    return true;
                }
                else
                {
                    dst = default;
                    return false;
                }
            }

            public bool Disp(out Asm.Disp dst)
            {
                if(Value is Disp x)
                {
                    dst = x;
                    return true;
                }
                else
                {
                    dst = default;
                    return false;
                }
            }

            public bool Disp(out Z0.Imm dst)
            {
                if(Value is Imm x)
                {
                    dst = x;
                    return true;
                }
                else
                {
                    dst = default;
                    return false;
                }
            }

            public bool Disp(out text31 dst)
            {
                if(Value is text31 x)
                {
                    dst = x;
                    return true;
                }
                else
                {
                    dst = default;
                    return false;
                }
            }

            public bool Byte(out byte dst)
            {
                if(Value is byte x)
                {
                    dst = x;
                    return true;
                }
                else
                {
                    dst = default;
                    return false;
                }
            }

            public string Format()
                => Value?.ToString() ?? EmptyString;

            public override string ToString()
                => Format();

            public static RuleOperand Empty => new RuleOperand(RuleOpName.None, uint4.Min);
        }
    }
}
//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static core;

    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public struct MacroSpec
        {
            public readonly RuleMacroName Name;

            public readonly byte FieldCount;

            readonly ByteBlock9 A0;

            readonly ByteBlock9 A1;

            readonly ByteBlock9 A2;

            readonly ByteBlock9 A3;

            readonly ByteBlock9 A4;

            [MethodImpl(Inline)]
            public MacroSpec(RuleMacroName name, FieldAssignment a0)
            {
                Name = name;
                FieldCount = 1;
                A0 = @as<FieldAssignment,ByteBlock9>(a0);
                A1 = default;
                A2 = default;
                A3 = default;
                A4 = default;
            }

            [MethodImpl(Inline)]
            public MacroSpec(RuleMacroName name, FieldAssignment a0, FieldAssignment a1)
            {
                Name = name;
                FieldCount = 2;
                A0 = @as<FieldAssignment,ByteBlock9>(a0);
                A1 = @as<FieldAssignment,ByteBlock9>(a1);
                A2 = default;
                A3 = default;
                A4 = default;
            }

            [MethodImpl(Inline)]
            public MacroSpec(RuleMacroName name, FieldAssignment a0, FieldAssignment a1, FieldAssignment a2)
            {
                Name = name;
                FieldCount = 3;
                A0 = @as<FieldAssignment,ByteBlock9>(a0);
                A1 = @as<FieldAssignment,ByteBlock9>(a1);
                A2 = @as<FieldAssignment,ByteBlock9>(a2);
                A3 = default;
                A4 = default;
            }

            [MethodImpl(Inline)]
            public MacroSpec(RuleMacroName name, FieldAssignment a0, FieldAssignment a1, FieldAssignment a2, FieldAssignment a3)
            {
                Name = name;
                FieldCount = 4;
                A0 = @as<FieldAssignment,ByteBlock9>(a0);
                A1 = @as<FieldAssignment,ByteBlock9>(a1);
                A2 = @as<FieldAssignment,ByteBlock9>(a2);
                A3 = @as<FieldAssignment,ByteBlock9>(a3);
                A4 = default;
            }

            [MethodImpl(Inline)]
            public MacroSpec(RuleMacroName name, FieldAssignment a0, FieldAssignment a1, FieldAssignment a2, FieldAssignment a3, FieldAssignment a4)
            {
                Name = name;
                FieldCount = 4;
                A0 = @as<FieldAssignment,ByteBlock9>(a0);
                A1 = @as<FieldAssignment,ByteBlock9>(a1);
                A2 = @as<FieldAssignment,ByteBlock9>(a2);
                A3 = @as<FieldAssignment,ByteBlock9>(a3);
                A4 = @as<FieldAssignment,ByteBlock9>(a4);
            }

            [MethodImpl(Inline)]
            public ref readonly FieldAssignment Assignment(int i, out FieldAssignment dst)
            {
                dst = FieldAssignment.Empty;
                if(i==0)
                    dst = @as<ByteBlock9,FieldAssignment>(A0);
                else if(i==1)
                    dst = @as<ByteBlock9,FieldAssignment>(A1);
                else if(i==2)
                    dst = @as<ByteBlock9,FieldAssignment>(A2);
                else if(i==3)
                    dst = @as<ByteBlock9,FieldAssignment>(A3);
                else if(i==4)
                    dst = @as<ByteBlock9,FieldAssignment>(A4);

                return ref dst;
            }

            public string Format()
            {
                var dst = text.buffer();
                dst.AppendFormat("{0}: ", MacroNames[Name].Expr);
                for(var i=0; i<FieldCount; i++)
                {
                    ref readonly var a = ref Assignment(i, out _);
                    if(i!=0)
                        dst.Append(Chars.Space);

                    dst.Append(a.Format());
                }
                return dst.Emit();
            }

            public override string ToString()
                => Format();

            public static MacroSpec Empty => new MacroSpec(RuleMacroName.None, FieldAssignment.Empty);
        }
    }
}
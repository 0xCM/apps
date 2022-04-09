//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedModels;

    using Asm;

    partial class XedDisasm
    {
        // public readonly struct DisasmOp
        // {
        //     public readonly OpName Name;

        //     readonly ByteBlock32 Data;

        //     [MethodImpl(Inline)]
        //     internal DisasmOp(OpValue src)
        //     {
        //         Name = src.Name;
        //         var data = ByteBlock32.Empty;
        //         if(src.Name == OpNameKind.DISP)
        //             core.@as<Disp>(data.First) = src.Disp;
        //         else
        //             core.@as<OpValue>(data.First) = src;
        //         Data = data;
        //     }

        //     [MethodImpl(Inline)]
        //     internal DisasmOp(OpName name, Disp disp)
        //     {
        //         Name = name;
        //         var data = ByteBlock32.Empty;
        //         core.@as<Disp>(data.First) = disp;
        //         Data = data;
        //     }

        //     [MethodImpl(Inline)]
        //     internal DisasmOp(OpName name, text31 mem)
        //     {
        //         Name = name;
        //         var data = ByteBlock32.Empty;
        //         core.@as<text31>(data.First) = mem;
        //         Data = data;
        //     }

        //     public string Format()
        //     {
        //         var dst = EmptyString;
        //         switch(Name.Kind)
        //         {
        //             case OpNameKind.RELBR:
        //             case OpNameKind.DISP:
        //                 dst = core.@as<Disp>(Data.First).Format();
        //             break;
        //             case OpNameKind.AGEN:
        //             case OpNameKind.MEM0:
        //             case OpNameKind.MEM1:
        //                 dst = core.@as<text31>(Data.First).Format();
        //             break;

        //             default:
        //                 dst = core.@as<OpValue>(Data.First).Format();
        //             break;
        //         }
        //         return dst;
        //     }

        //     public override string ToString()
        //         => Format();

        //     [MethodImpl(Inline)]
        //     public static explicit operator Disp(DisasmOp src)
        //         => src.Name.Kind == OpNameKind.DISP ? core.@as<Disp>(src.Data.First) : Disp.Empty;
        // }

        public readonly struct DisasmOp
        {
            public readonly OpName Name;

            public readonly object Value;

            [MethodImpl(Inline)]
            public DisasmOp(OpValue value)
            {
                Name = value.Name;
                Value = value;
            }

            [MethodImpl(Inline)]
            public DisasmOp(OpNameKind name, object value)
            {
                Name = name;
                Value = value;
            }

            public string Format()
                => Value?.ToString() ?? EmptyString;

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static explicit operator Disp(DisasmOp src)
                => src.Value is OpValue v ? (Disp)v : Disp.Empty;

            public static DisasmOp Empty => new DisasmOp(OpNameKind.None, z8);
        }
    }
}
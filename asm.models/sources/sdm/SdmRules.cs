//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;
    using static SdmModels;
    using static SdmModels.SdmEncodingSigs;

    using K = SdmModels.ModRmEncKind;

    [ApiHost]
    public readonly partial struct SdmRules
    {
        public readonly struct ExplicitRegNames
        {
            public const string AL = "AL";

            public const string AX = "AX";

            public const string EAX = "EAX";

            public const string RAX = "RAX";
        }

        [MethodImpl(Inline), Op]
        public static ImmRule imm(byte id, byte data)
            => new ImmRule(id,data);

        [MethodImpl(Inline), Op]
        public static ModRmRule modrm(ModRmEncKind kind)
            => new ModRmRule(kind);

        [MethodImpl(Inline), Op]
        public static ExplicitRegRule reg(byte id)
            => new ExplicitRegRule(id);

        [MethodImpl(Inline), Op]
        public static EncodingSig sig(EncodingClass @class, byte kind)
            => new EncodingSig(@class,kind);

        [MethodImpl(Inline), Op]
        public static EncodingOperand operand(OperandIndex n, EncodingSig sig)
            => new EncodingOperand(n,sig);

        [MethodImpl(Inline), Op]
        public static EncodingFunction function()
            => default;

        [MethodImpl(Inline), Op]
        public static EncodingFunction function(EncodingOperand op0)
            => new EncodingFunction(op0);

        [MethodImpl(Inline), Op]
        public static EncodingFunction function(EncodingOperand op0, EncodingOperand op1)
            => new EncodingFunction(op0,op1);

        [MethodImpl(Inline), Op]
        public static EncodingFunction function(EncodingOperand op0, EncodingOperand op1, EncodingOperand op2)
            => new EncodingFunction(op0,op1,op2);

        [MethodImpl(Inline), Op]
        public static EncodingFunction function(EncodingOperand op0, EncodingOperand op1, EncodingOperand op2, EncodingOperand op3)
            => new EncodingFunction(op0,op1,op2,op3);

        [Op]
        public static bit parse(string src, out ModRmEncKind dst)
        {
            dst = 0;
            var i = text.index(src, ModRm);
            if(i < 0)
                return false;

            var content = text.right(src,Chars.Colon);
            switch(src)
            {
                case ModRm_RmR:
                    dst = K.RmR;
                break;

                case ModRm_RmW:
                    dst = K.RmW;
                break;

                case ModRm_RmRW:
                    dst = K.RmRW;
                break;

                case ModRm_RegR:
                    dst = K.RegR;
                break;

                case ModRm_RegW:
                    dst = K.RegW;
                break;

                case ModRm_RegRW:
                    dst = K.RegRW;
                break;

                case ModRm_RmR11:
                    dst = K.RmRMust11;
                break;

                case ModRm_RmWNot11:
                    dst = K.RmWNot11;
                break;
            }
            return dst != 0;
        }
    }
}
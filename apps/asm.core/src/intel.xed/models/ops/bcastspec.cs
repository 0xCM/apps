//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedModels.BCastKind;
    using static Asm.AsmBroadcastClass;

    partial struct XedModels
    {
        [Op]
        public static AsmBroadcastInfo spec(BCastKind kind)
        {
            var dst = AsmBroadcastInfo.Empty;
            var id = (uint5)(byte)kind;
            switch(kind)
            {
                case BCast_1TO16_8:
                    dst = AsmBroadcastInfo.define(id, BCast8, Symbols.expr(BCast8Kind.BCast_1TO16_8).Format(), 1, 16);
                break;

                case BCast_1TO32_8:
                    dst = AsmBroadcastInfo.define(id, BCast8, Symbols.expr(BCast8Kind.BCast_1TO32_8).Format(), 1, 32);
                break;

                case BCast_1TO64_8:
                    dst = AsmBroadcastInfo.define(id, BCast8, Symbols.expr(BCast8Kind.BCast_1TO64_8).Format(), 1, 64);
                break;

                case BCast_1TO2_8:
                    dst = AsmBroadcastInfo.define(id, BCast8, Symbols.expr(BCast8Kind.BCast_1TO2_8).Format(), 1, 8);
                break;

                case BCast_1TO4_8:
                    dst = AsmBroadcastInfo.define(id, BCast8, Symbols.expr(BCast8Kind.BCast_1TO4_8).Format(), 1, 4);
                break;

                case BCast_1TO8_8:
                    dst = AsmBroadcastInfo.define(id, BCast8, Symbols.expr(BCast8Kind.BCast_1TO8_8).Format(), 1, 8);
                break;

                case BCast_1TO8_16:
                    dst = AsmBroadcastInfo.define(id, BCast16, Symbols.expr(BCast16Kind.BCast_1TO8_16).Format(), 1, 8);
                break;

                case BCast_1TO16_16:
                    dst = AsmBroadcastInfo.define(id, BCast16, Symbols.expr(BCast16Kind.BCast_1TO16_16).Format(), 1, 16);
                break;

                case BCast_1TO32_16:
                    dst = AsmBroadcastInfo.define(id, BCast16, Symbols.expr(BCast16Kind.BCast_1TO32_16).Format(), 1, 32);
                break;

                case BCast_1TO2_16:
                    dst = AsmBroadcastInfo.define(id, BCast16, Symbols.expr(BCast16Kind.BCast_1TO2_16).Format(), 1, 2);
                break;

                case BCast_1TO4_16:
                    dst = AsmBroadcastInfo.define(id, BCast16, Symbols.expr(BCast16Kind.BCast_1TO4_16).Text, 1, 4);
                break;

                case BCast_1TO16_32:
                    dst = AsmBroadcastInfo.define(id, BCast32, Symbols.expr(BCast32Kind.BCast_1TO16_32).Text, 1, 16);
                break;

                case BCast_4TO16_32:
                    dst = AsmBroadcastInfo.define(id, BCast32, Symbols.expr(BCast32Kind.BCast_4TO16_32).Text, 4, 16);
                break;

                case BCast_1TO8_32:
                    dst = AsmBroadcastInfo.define(id, BCast32, Symbols.expr(BCast32Kind.BCast_1TO8_32).Text, 1, 8);
                break;

                case BCast_4TO8_32:
                    dst = AsmBroadcastInfo.define(id, BCast32, Symbols.expr(BCast32Kind.BCast_4TO8_32).Text, 4, 8);
                break;

                case BCast_2TO16_32:
                    dst = AsmBroadcastInfo.define(id, BCast32, Symbols.expr(BCast32Kind.BCast_2TO16_32).Text, 2, 16);
                break;

                case BCast_8TO16_32:
                    dst = AsmBroadcastInfo.define(id, BCast32, Symbols.expr(BCast32Kind.BCast_8TO16_32).Text, 8, 16);
                break;

                case BCast_1TO4_32:
                    dst = AsmBroadcastInfo.define(id, BCast32, Symbols.expr(BCast32Kind.BCast_1TO4_32).Text, 1, 4);
                break;

                case BCast_2TO4_32:
                    dst = AsmBroadcastInfo.define(id, BCast32, Symbols.expr(BCast32Kind.BCast_2TO4_32).Text, 2, 4);
                break;

                case BCast_2TO8_32:
                    dst = AsmBroadcastInfo.define(id, BCast32, Symbols.expr(BCast32Kind.BCast_2TO8_32).Text, 2, 8);
                break;

                case BCast_1TO2_32:
                    dst = AsmBroadcastInfo.define(id, BCast32, Symbols.expr(BCast32Kind.BCast_1TO2_32).Text, 1, 2);
                break;

                case BCast_1TO8_64:
                    dst = AsmBroadcastInfo.define(id, BCast64, Symbols.expr(BCast64Kind.BCast_1TO8_64).Text, 1, 8);
                break;

                case BCast_4TO8_64:
                    dst = AsmBroadcastInfo.define(id, BCast64, Symbols.expr(BCast64Kind.BCast_4TO8_64).Text, 4, 8);
                break;

                case BCastKind.BCast_2TO8_64:
                    dst = AsmBroadcastInfo.define(id, BCast64, Symbols.expr(BCast64Kind.BCast_2TO8_64).Text, 2, 8);
                break;

                case BCastKind.BCast_1TO2_64:
                    dst = AsmBroadcastInfo.define(id, BCast64, Symbols.expr(BCast64Kind.BCast_1TO2_64).Text, 1, 2);
                break;

                case BCastKind.BCast_1TO4_64:
                    dst = AsmBroadcastInfo.define(id, BCast64, Symbols.expr(BCast64Kind.BCast_1TO4_64).Text, 1, 4);
                break;

                case BCastKind.BCast_2TO4_64:
                    dst = AsmBroadcastInfo.define(id, BCast64, Symbols.expr(BCast64Kind.BCast_2TO4_64).Text, 2, 64);
                break;
            }

            return dst;
        }
    }
}
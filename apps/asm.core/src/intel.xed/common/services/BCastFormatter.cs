//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static XedModels;
    using static XedModels.BCastKind;
    using static Asm.BroadcastStrings;
    using static core;

    partial class IntelXed
    {
        public readonly struct BCastFormatter : IFormatter<BCastKind>
        {
            [MethodImpl(Inline)]
            public static string format(BCastKind src)
                => Service.Format(src);

            [MethodImpl(Inline)]
            public string Format(BCastKind src)
            {
                if(src == 0)
                    return EmptyString;
                else
                    return SymbolMap[(byte)src];
            }

            public static BCastFormatter Service => default;

            static BCastFormatter()
            {
                MapSymbols();
            }

            static void MapSymbols()
            {
                var kinds = Symbols.index<BCastKind>().Kinds;
                var count = kinds.Length - 1;
                SymbolMap = alloc<string>(count);
                for(int i=0, j=1; i<count; i++, j++)
                {
                    ref readonly var kind = ref skip(kinds,j);
                    switch(kind)
                    {
                        case BCast_1TO2_8:
                        case BCast_1TO2_16:
                        case BCast_1TO2_32:
                        case BCast_1TO2_64:
                            SymbolMap[i] = BCast1to2;
                            break;

                        case BCast_1TO4_8:
                        case BCast_1TO4_16:
                        case BCast_1TO4_32:
                        case BCast_1TO4_64:
                            SymbolMap[i] = BCast1to4;
                            break;

                        case BCast_1TO8_8:
                        case BCast_1TO8_16:
                        case BCast_1TO8_32:
                        case BCast_1TO8_64:
                            SymbolMap[i] = BCast1to8;
                            break;

                        case BCast_1TO16_16:
                        case BCast_1TO16_8:
                        case BCast_1TO16_32:
                            SymbolMap[i] = BCast1to16;
                            break;

                        case BCast_1TO32_8:
                        case BCast_1TO32_16:
                            SymbolMap[i] = BCast1to32;
                            break;


                        case BCast_1TO64_8:
                            SymbolMap[i] = BCast1to64;
                            break;

                        case BCast_2TO4_64:
                        case BCast_2TO4_32:
                            SymbolMap[i] = BCast2to4;
                            break;

                        case BCast_2TO8_32:
                        case BCast_2TO8_64:
                            SymbolMap[i] = BCast2to8;
                            break;

                        case BCast_2TO16_32:
                            SymbolMap[i] = BCast2to16;
                            break;

                        case BCast_4TO8_32:
                        case BCast_4TO8_64:
                            SymbolMap[i] = BCast4to8;
                            break;

                        case BCast_4TO16_32:
                            SymbolMap[i] = BCast4to16;
                            break;

                        case BCast_8TO16_32:
                            SymbolMap[i] = BCast8to16;
                            break;

                        default:
                        break;
                    }
                }
            }

            static Index<string> SymbolMap;
        }
    }
}
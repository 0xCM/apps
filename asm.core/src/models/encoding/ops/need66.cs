//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static OpModeKind;
    using static OpszKind;

    partial struct AsmEncoding
    {
        /// <summary>
        /// Determines whether a 66h prefix is required to indicate an operand-size override
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="default"></param>
        /// <param name="effective"></param>
        [Op]
        public static bit need66(OpModeKind mode, OpszKind @default, OpszKind effective)
            => mode switch{
                IA32e => effective switch {
                    W16 => 1,
                    W32 => 0,
                    W64 => 0,
                    _ => 0,
                },

                Compatibilty => effective switch {
                    W16 => @default switch{
                        W16 => 1,
                        W32 => 0,
                        _ => 0,
                    },

                    W32 => @default switch{
                        W16 => 0,
                        W32 => 1,
                        _ => 0,
                    },

                    _ => 0
                },

                Protected => effective switch {
                    W16 => @default switch {
                        W16 => 1,
                        W32 => 0,
                        _ => 0,
                    },
                    W32 => @default switch {
                        W16 => 0,
                        W32 => 1,
                        _ => 0,
                    },
                    _ => 0
                },

                Virtual8086 => effective switch {
                    W16 => @default switch {
                        W16 => 1,
                        W32 => 0,
                        _ => 0,
                    },
                    W32 => @default switch {
                        W16 => 0,
                        W32 => 1,
                        _ => 0,
                    },
                    _ => 0
                },

                Real => effective switch {
                    W16 => @default switch {
                        W16 => 1,
                        W32 => 0,
                        _ => 0,
                    },
                    W32 => @default switch {
                        W16 => 0,
                        W32 => 1,
                        _ => 0,
                    },
                    _ => 0
                },
              _ => 0
            };
    }
}
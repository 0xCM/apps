//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial struct IceConverters
    {
        /// <summary>
        /// Extracts register information, should it exist, from an index-identified register operand
        /// </summary>
        /// <param name="src">The source instruction</param>
        /// <param name="index">The operand index</param>
        [Op]
		public static IceRegister register(in IceInstruction src, byte index)
        {
			switch (index)
            {
                case 0: return src.Op0Register;
                case 1: return src.Op1Register;
                case 2: return src.Op2Register;
                case 3: return src.Op3Register;
                case 4: return src.Op4Register;
			}
            return 0;
		}
    }
}
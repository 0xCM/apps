//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct ModRmVar
    {
        const string ModField = "MOD";

        const string RegField = "REG";

        const string RmField = "RM";

        const string ModBits = "mm";

        const string RegBits = "rrr";

        const string RmBits = "nnn";

        const string RenderPattern = $"{ModField}[{{0}}] {RegField}[{{1}}] {RmField}[{{2}}]";

        BitfieldVar ModVar;

        BitfieldVar RegVar;

        BitfieldVar RmVar;

        [MethodImpl(Inline)]
        public static ModRmVar init()
        {
            var dst = default(ModRmVar);
            dst.ModVar = ModBits;
            dst.RegVar = RegBits;
            dst.RmVar = RmBits;
            return dst;
        }

        [MethodImpl(Inline)]
        public static ModRmVar init(uint2 mod, uint3 reg, uint3 rm)
        {
            var dst = init();
            dst.Mod(mod);
            dst.Reg(reg);
            dst.Rm(rm);
            return dst;
        }

        [MethodImpl(Inline)]
        public void Clear()
        {
            ModVar.Clear();
            RegVar.Clear();
            RmVar.Clear();
        }

        [MethodImpl(Inline)]
        public ModRm Evaluate()
            => ModRm.init(Mod(),Reg(),Rm());

        [MethodImpl(Inline)]
        public void Mod(uint2 src)
            => ModVar.Assign(src);

        [MethodImpl(Inline)]
        public uint2 Mod()
            => ModVar.Assignment();

        [MethodImpl(Inline)]
        public void Reg(uint3 src)
            => RegVar.Assign(src);

        [MethodImpl(Inline)]
        public uint3 Reg()
            => RegVar.Assignment();

        [MethodImpl(Inline)]
        public void Rm(uint3 src)
            => RmVar.Assign(src);

        [MethodImpl(Inline)]
        public uint3 Rm()
            => RmVar.Assignment();

        public string Format()
            => string.Format(RenderPattern, ModVar, RegVar, RmVar);

        public override string ToString()
            => Format();
    }
}
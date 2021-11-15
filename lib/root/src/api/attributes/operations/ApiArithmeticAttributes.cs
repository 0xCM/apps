//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using K = ApiArithmeticClass;
    using A = OpKindAttribute;

    public sealed class AddAttribute : A { public AddAttribute(ApiAsmClass asm = 0) : base(K.Add, asm) {} }

    public sealed class AddSAttribute : A { public AddSAttribute(ApiAsmClass asm = 0) : base(K.AddS, asm) {} }

    public sealed class AddHAttribute : A { public AddHAttribute(ApiAsmClass asm = 0) : base(K.AddH, asm) {} }

    public sealed class AddHSAttribute : A { public AddHSAttribute(ApiAsmClass asm = 0) : base(K.AddHS, asm) {} }

    public sealed class SadAttribute : A { public SadAttribute(ApiAsmClass asm = 0) : base(K.Sad, asm) {} }

    public sealed class SubAttribute : A { public SubAttribute(ApiAsmClass asm = 0) : base(K.Sub, asm) {} }

    public sealed class SubHAttribute : A { public SubHAttribute(ApiAsmClass asm = 0) : base(K.SubH, asm) {} }

    public sealed class SubHSAttribute : A { public SubHSAttribute(ApiAsmClass asm = 0) : base(K.SubHS, asm) {} }

    public sealed class SubSAttribute : A { public SubSAttribute(ApiAsmClass asm = 0) : base(K.SubS, asm) {} }

    public sealed class MulAttribute : A { public MulAttribute(ApiAsmClass asm = 0) : base(K.Mul, asm) {} }

    public sealed class MulLoAttribute : A { public MulLoAttribute(ApiAsmClass asm = 0) : base(K.MulLo, asm) {} }

    public sealed class MulHiAttribute : A { public MulHiAttribute(ApiAsmClass asm = 0) : base(K.MulHi, asm) {} }

    public sealed class MulXAttribute : A { public MulXAttribute(ApiAsmClass asm = 0) : base(K.MulX, asm) {} }

    public sealed class DivAttribute : A { public DivAttribute(ApiAsmClass asm = 0) : base(K.Div, asm) {} }

    public sealed class ModAttribute : A { public ModAttribute(ApiAsmClass asm = 0) : base(K.Mod, asm) {} }

    public sealed class ClampAttribute : A { public ClampAttribute(ApiAsmClass asm = 0) : base(K.Clamp, asm) {} }

    public sealed class DistAttribute : A { public DistAttribute(ApiAsmClass asm = 0) : base(K.Dist, asm) {} }

    public sealed class ClMulAttribute : A { public ClMulAttribute(ApiAsmClass asm = 0) : base(K.ClMul, asm) {} }

    public sealed class DotAttribute : A { public DotAttribute(ApiAsmClass asm = 0) : base(K.Dot, asm) {} }

    public sealed class IncAttribute : A { public IncAttribute(ApiAsmClass asm = 0) : base(K.Inc, asm) {} }

    public sealed class DecAttribute : A { public DecAttribute(ApiAsmClass asm = 0) : base(K.Dec, asm) {} }

    public sealed class NegateAttribute : A { public NegateAttribute(ApiAsmClass asm = 0) : base(K.Negate, asm) {} }

    public sealed class AbsAttribute : A { public AbsAttribute(ApiAsmClass asm = 0) : base(K.Abs, asm) {} }

    public sealed class SquareAttribute : A { public SquareAttribute(ApiAsmClass asm = 0) : base(K.Square, asm) {} }

    public sealed class SqrtAttribute : A { public SqrtAttribute(ApiAsmClass asm = 0) : base(K.Sqrt, asm) {} }

    public sealed class FmaAttribute : A { public FmaAttribute(ApiAsmClass asm = 0) : base(K.Fma, asm) {} }

    public sealed class ModMulAttribute : A { public ModMulAttribute(ApiAsmClass asm = 0) : base(K.ModMul, asm) {} }

    public sealed class DivModAttribute : A { public DivModAttribute(ApiAsmClass asm = 0) : base(K.DivMod, asm) {} }

    public sealed class AvgzAttribute : A { public AvgzAttribute(ApiAsmClass asm = 0) : base(K.Avgz, asm) {} }

    public sealed class AvgiAttribute : A { public AvgiAttribute(ApiAsmClass asm = 0) : base(K.Avgi, asm) {} }

    public sealed class MaxAttribute : A { public MaxAttribute(ApiAsmClass asm = 0) : base(K.Max, asm) {} }

    public sealed class MinAttribute : A { public MinAttribute(ApiAsmClass asm = 0) : base(K.Min, asm) {} }

    public sealed class CeilAttribute : A { public CeilAttribute(ApiAsmClass asm = 0) : base(K.Ceil, asm) {} }

    public sealed class FloorAttribute : A { public FloorAttribute(ApiAsmClass asm = 0) : base(K.Floor, asm) {} }

    public sealed class RoundAttribute : A { public RoundAttribute(ApiAsmClass asm = 0) : base(K.Round, asm) {} }

    public sealed class PowAttribute : A { public PowAttribute(ApiAsmClass asm = 0) : base(K.Pow, asm) {} }

    public sealed class Log2Attribute : A { public Log2Attribute(ApiAsmClass asm = 0) : base(K.Log2, asm) {} }

    public sealed class AddAssignAttribute : A { public AddAssignAttribute(ApiAsmClass asm = 0) : base(K.AddAssign, asm) {} }

    public sealed class SubAssignAttribute : A { public SubAssignAttribute(ApiAsmClass asm = 0) : base(K.SubAssign, asm) {} }

    public sealed class MulAssignAttribute : A { public MulAssignAttribute(ApiAsmClass asm = 0) : base(K.MulAssign, asm) {} }

    public sealed class DivAssignAttribute : A { public DivAssignAttribute(ApiAsmClass asm = 0) : base(K.DivAssign, asm) {} }
}
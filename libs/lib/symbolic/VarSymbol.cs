//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IVarSymbol
    {

    }

    public readonly record struct VarSymbol : IVarSymbol, IEquatable<VarSymbol>, IComparable<VarSymbol>
    {
        [Op]
        public static string format(IVarValue var, char assign)
            => string.Format("{0}{1}{2}", format(var.VarName), assign, var.VarValue);

        public static string replace(IVarValue src, dynamic value)
            => default;

        [Op]
        public static string format(IVarValue var)
            => format(var, Chars.Eq);

        [Op]
        public static string format(VarContextKind vck, IVarValue var, char assign)
            => string.Format("{0}{1}{2}", format(vck, var.VarName), assign, var.VarValue);

        [Op]
        public static string format(VarSymbol src)
            => format(VarContextKind.Workflow, src);

        [Op]
        public static string format(VarContextKind vck, VarSymbol src)
            => string.Format(RP.pattern(vck), src.Name);

        [Op]
        public static string format(VarContextKind vck, IVarValue var)
            => format(vck,var, Chars.Eq);

        public Name Name {get;}

        [MethodImpl(Inline)]
        public VarSymbol(string name)
            => Name = name;

        [MethodImpl(Inline)]
        public VarSymbol(char name)
            => Name = name.ToString();

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsNonEmpty;
        }

        public string Format()
            => Format(VarContextKind.Workflow);

        public string Format(VarContextKind vck)
            => string.Format(RP.pattern(vck), Name);

        public override string ToString()
            => Format();

        public bool Equals(VarSymbol src)
            => Name.Equals(src.Name);

        public override int GetHashCode()
            => Name.GetHashCode();

        public int CompareTo(VarSymbol src)
            => Name.CompareTo(src.Name);

        [MethodImpl(Inline)]
        public static implicit operator VarSymbol(string name)
            => new VarSymbol(name);

        [MethodImpl(Inline)]
        public static implicit operator VarSymbol(char name)
            => new VarSymbol(name);

        public static VarSymbol Empty => new VarSymbol(EmptyString);
    }
}
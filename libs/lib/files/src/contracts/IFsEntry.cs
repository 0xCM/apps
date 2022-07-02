//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static FS;

    public interface IFsEntry : IDataTypeExpr
    {
        PathPart Name {get;}

        Hash32 IHashed.Hash
            => HashCodes.hash(Name.Format());

        bool INullity.IsEmpty
            => Name.IsEmpty;

        bool INullity.IsNonEmpty
            => Name.IsNonEmpty;

        string IExpr2.Format()
            => Name.Format();

        int GetHashCode()
            => Hash;
    }

    public interface IFsEntry<F> : IFsEntry, IDataTypeExpr<F>
        where F : struct, IFsEntry<F>
    {
        bool IEquatable<F>.Equals(F src)
            => Name == src.Name;

        int IComparable<F>.CompareTo(F src)
            => Name.CompareTo(src.Name);
    }
}
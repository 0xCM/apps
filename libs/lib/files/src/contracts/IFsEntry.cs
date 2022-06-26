//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static FS;

    public interface IFsEntry : ITextual, IDataType
    {
        PathPart Name {get;}

        Hash32 IHashed.Hash
            => core.hash(Name.Format());

        bool INullity.IsEmpty
            => Name.IsEmpty;

        bool INullity.IsNonEmpty
            => Name.IsNonEmpty;

        string ITextual.Format()
            => Name.Format();

        int GetHashCode()
            => Hash;
    }

    public interface IFsEntry<F> : IFsEntry, IDataType<F>
        where F : struct, IFsEntry<F>
    {
        bool IEquatable<F>.Equals(F src)
            => Name == src.Name;

        int IComparable<F>.CompareTo(F src)
            => Name.CompareTo(src.Name);
    }
}
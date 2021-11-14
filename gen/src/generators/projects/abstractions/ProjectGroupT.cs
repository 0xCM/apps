//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Gen.Projects
{
    public abstract class ProjectGroup<T> : IProjectGroup<T>
        where T : IProjectElement
    {
        public GroupKind GroupKind {get;}

        public DataList<T> Members {get;}

        protected ProjectGroup(GroupKind kind)
        {
            Members = new();
            GroupKind = kind;
        }

        protected ProjectGroup(GroupKind kind, T[] members)
        {
            GroupKind = kind;
            Members = members;
        }

        public string Format()
        {
            var dst = text.buffer();
            Render(2u,dst);
            return dst.Emit();
        }

        public void Render(uint margin, ITextBuffer dst)
        {
            dst.IndentLine(margin, string.Format("<{0}>", GroupKind));
            margin+=2;
            core.iter(Members, member => dst.IndentLine(margin,member.Format()));
            margin-=2;
            dst.IndentLine(margin, string.Format("</{0}>",GroupKind));
        }
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IToolBox : ILocatable<IDbArchive>
    {
        ReadOnlySeq<ToolBox> Tools();
    }

    public readonly struct ToolBox : IToolBox
    {
        readonly IDbArchive Home;

        [MethodImpl(Inline)]
        public ToolBox(IDbArchive home)
        {
            Home = home;
        }

        public IDbArchive Location
        {
            [MethodImpl(Inline)]
            get => Home;
        }

        public string Format()
            => Home.Name;

        public override string ToString()
            => Format();

        public ToolBox Tool(string name)
            =>  new ToolBox(Archives.archive(Home.Folder(name)));

        public ReadOnlySeq<ToolBox> Tools()
            => Home.Folders().Select(f => new ToolBox(Archives.archive(f)));

    }
}
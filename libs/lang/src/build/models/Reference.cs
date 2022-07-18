//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class MsBuild
    {
        public sealed class Reference : ProjectItem
        {
            const string Pattern1 = "<{0} Include=\"{1}\"/>";

            const string Pattern2 = "<{0} Include=\"{1}\" HintPath=\"{2}\"/>";

            public string ProjectName {get;}

            public FS.FilePath Hint {get;}

            public Reference(string name, FS.FilePath? hint = null)
                : base(nameof(Reference))
            {
                ProjectName = name;
                Hint = hint ?? FS.FilePath.Empty;
            }

            public override string Format()
                => Hint.IsEmpty
                ? string.Format(Pattern1, Name, ProjectName)
                : string.Format(Pattern2, Name, ProjectName, Hint);

            public override string ToString()
                => Format();
        }
    }
}
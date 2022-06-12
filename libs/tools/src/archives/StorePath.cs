//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct StorePath
    {
        [Render(32)]
        public string Name;

        [Render(1)]
        public FS.FolderPath Location;

        [MethodImpl(Inline)]
        public StorePath(string name, FS.FolderPath dst)
        {
            Name = name;
            Location = dst;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => text.empty(Name) || Location.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => text.nonempty(Name) && Location.IsNonEmpty;
        }

        public string Format()
            => Location.Format();

        public override string ToString()
            => Format();

        public static StorePath Empty => new StorePath(EmptyString, FS.FolderPath.Empty);
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct FS
    {
        [Op]
        public static FileName file(PartId part, FileExt ext)
            => file(part.Format(), ext);

        [Op]
        public static FileName file(ApiHostUri host, FileExt ext)
            => file(string.Format("{0}.{1}", host.Part.Format(), host.HostName), ext);

        [Op]
        public static FS.FileName file(ApiHostUri host, string subject, FS.FileExt ext)
            => FS.file(string.Format("{0}.{1}.{2}", host.Part.Format(), host.HostName, subject), ext);

        [Op]
        public static FileName file(PartId part, FileExt x1, FileExt x2)
            => file(part, combine(x1, x2));

        [Op]
        public static FileName file(PartId part, string hostname, FileExt ext)
            => file(text.concat(part.Format(), Chars.Dot, hostname), ext);

        [MethodImpl(Inline), Op]
        public static FileName file(PathPart name, FileExt ext)
            => new FileName(name, ext);

        [Op]
        public static FileName file(PathPart name, FileExt x1, FileExt x2)
            => new FileName(name, FS.combine(x1,x2));

        [MethodImpl(Inline), Op]
        public static FileName file(string name)
            => new FileName(name);

        [MethodImpl(Inline), Op]
        public static FileName file(Name name, string x)
            => new FileName(name.Format(), ext(x));
    }
}
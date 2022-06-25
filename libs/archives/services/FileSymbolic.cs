//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Windows;

    public abstract class ArchiveLink<S,T>
        where S : IRootedArchive
        where T : IRootedArchive
    {

    }

    public class FileSymbolic : AppService<FileSymbolic>
    {

    }
}
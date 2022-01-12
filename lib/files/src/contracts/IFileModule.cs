//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IFileModule : IFile
    {
        FileModuleKind ModuleKind {get;}

        string ITextual.Format()
            => Path.Name;
    }

    [Free]
    public interface IFileModule<T> : IFileModule
        where T : struct, IFileModule<T>
    {

    }
}
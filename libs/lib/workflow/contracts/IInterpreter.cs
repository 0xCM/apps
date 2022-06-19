//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free =System.Security.SuppressUnmanagedCodeSecurityAttribute;

    using System.Threading.Tasks;

    [Free]
    public interface IInterpreter
    {
        Task Run();

        void Submit(string command);
    }
}
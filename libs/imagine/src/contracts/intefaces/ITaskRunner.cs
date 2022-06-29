//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Threading.Tasks;

    [Free]
    public interface ITaskRunner
    {
        Task Run();

        void Submit(string command);
    }
}
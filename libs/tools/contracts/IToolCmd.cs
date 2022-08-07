//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IToolCmd
    {
        Tool Tool {get;}
        
        Name Type {get;}

        ToolCmdArgs Args 
            => ToolCmdArgs.Empty;
    }

    [Free]
    public interface IToolCmd<T,C> : IToolCmd, ICmd<C>
        where T : ITool, new()
        where C : ICmd<C>, new()
    {

        new T Tool => new T();

        Tool IToolCmd.Tool
            => new (Tool.Name);

        Name IToolCmd.Type
            => typeof(T).DisplayName();
    }
}
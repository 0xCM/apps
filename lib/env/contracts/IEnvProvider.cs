//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IEnvProvider
    {
        EnvData Env {get;}
    }

    public interface IEnvProvider2 : IEnvSet
    {
        ref readonly Index<EnvVar> Vars {get;}

        uint VarCount => Vars.Count;

        ref readonly EnvVar this[uint index] => ref Vars[index];

        ref readonly EnvVar this[int index] => ref Vars[index];

        string Format() => ToString();
    }

    public interface IEnvProvider<D> : IEnvProvider2
        where D : IEnvVar
    {
        new ref readonly Index<D> Vars {get;}

        new ref readonly D this[uint index] => ref Vars[index];

        new ref readonly D this[int index] => ref Vars[index];
    }
}
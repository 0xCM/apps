//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class DotNetSymbols : AppService<DotNetSymbols>
    {
        ISymbolArchive Symbols => SymbolArchive.Service;

        IDumpArchive Dumps => DumpArchive.Service;

        public void DumpImageHex(byte major = 6, byte minor = 0, byte revision = 203)
            => MemoryEmitter.create(Wf).DumpImages(
                Symbols.DotNet(major, minor, revision),
                Dumps.DotNetTargets(major,minor,revision)
                );
    }
}
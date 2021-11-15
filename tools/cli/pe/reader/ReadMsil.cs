//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection.Metadata;
    using System.Linq;

    using static core;

    partial class PeReader
    {
        public ReadOnlySpan<MsilMetadata> ReadMsil()
        {
            var dst = list<MsilMetadata>();
            var types = @readonly(MD.TypeDefinitions.ToArray());
            var typeCount = types.Length;
            for(var k=0u; k<typeCount; k++)
            {
                 var hType = skip(types, k);
                 var methods = @readonly(MD.GetTypeDefinition(hType).GetMethods().Array());
                 var methodCount = methods.Length;
                 var definitions = @readonly(map(methods, m=> MD.GetMethodDefinition(m)));
                 for(var i=0u; i<methodCount; i++)
                 {
                    ref readonly var method = ref skip(methods,i);
                    ref readonly var definition = ref skip(definitions,i);
                    var rva = definition.RelativeVirtualAddress;
                    if(rva != 0)
                    {
                        var body = PE.GetMethodBody(rva);
                        dst.Add(new MsilMetadata
                        {
                            MethodRva = (Address32)rva,
                            Token = Clr.token(method),
                            ImageName = Source.FileName,
                            BodySize = body.Size,
                            LocalInit = body.LocalVariablesInitialized,
                            MaxStack = body.MaxStack,
                            MethodName = Clr.membername(MD.GetString(definition.Name)),
                            Code = body.GetILBytes(),
                        });
                    }
                 }
            }
            return dst.ViewDeposited();
        }
    }
}
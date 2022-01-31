//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    partial class CheckCmdProvider
    {
        [Free]
        public interface ICalc64
        {
            ulong Add(ulong a, ulong b);

            ulong Sub(ulong a, ulong b);

            ulong Mul(ulong a, ulong b);

            ulong Mod(ulong a, ulong b);
        }

        public readonly struct Calc64 : ICalc64
        {
            [Op]
            public ulong Add(ulong a, ulong b)
                => math.add(a,b);

            [Op]
            public ulong Mod(ulong a, ulong b)
                => math.mod(a,b);

            [Op]
            public ulong Mul(ulong a, ulong b)
                => math.mul(a,b);

            [Op]
            public ulong Sub(ulong a, ulong b)
                => math.sub(a,b);
        }


        [CmdOp("check/asm/stubs")]
        Outcome FindJumpStubs(CmdArgs args)
        {
            void Api()
            {
                var stubs = JmpStubs.SearchCaptured(ApiHostUri.from(typeof(cpu)));
                foreach(var stub in stubs)
                {
                    var jmp = stub.ToModel();
                    Write(jmp.Format());
                }
            }

            void Search()
            {
                var host = typeof(Calc64);
                var contract = typeof(ICalc64);
                var stubs = JmpStubs.SearchLive(host);
                Write(stubs.View, JmpStub.RenderWidths);
                var imap = Clr.imap(host,contract);
                Write(imap.Format());
            }

            void Encode()
            {
                var stubs = JmpStubs.create(Wf);
                if(stubs.Create<ulong>(0))
                {
                    var encoded = stubs.EncodeDispatch(0);
                    Write(encoded.FormatHexData());
                }
            }

            Api();
            Search();
            Encode();

            return true;
        }

        static Index<ApiHostUri> NestedHosts(Type src)
        {
            var dst = list<ApiHostUri>();
            var nested = @readonly(src.GetNestedTypes());
            var count = nested.Length;
            for(var i=0; i<count; i++)
            {
                var candidate = skip(nested,i);
                var uri = candidate.ApiHostUri();
                if(uri.IsNonEmpty)
                    dst.Add(uri);
            }
            return dst.ToArray();
        }

    }
}
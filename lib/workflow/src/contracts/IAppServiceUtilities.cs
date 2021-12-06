//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.IO;
    using System.Text;
    using static core;

    using Caller = System.Runtime.CompilerServices.CallerMemberNameAttribute;

    public interface IAppServiceUtilities
    {
        IWfRuntime Wf {get;}

        string HostName => GetType().Name;


        string Worker([Caller] string name = null)
            => string.Format("{0,-14}",string.Format("worker({0}) >>", name));

        void RedirectEmissions(string name, FS.FolderPath dst)
            => Wf.RedirectEmissions(Loggers.emission(name, dst));


        bool Check<T>(Outcome<T> outcome, out T payload)
        {
            if(outcome.Fail)
            {
                Error(outcome.Message);
                payload = default;
                return false;
            }
            else
            {
                payload = outcome.Data;
                return true;
            }
        }

        void Babble<T>(T content)
            => Wf.Babble(content);

        void Babble(string pattern, params object[] args)
            => Wf.Babble(string.Format(pattern,args));

        void Status<T>(T content)
            => Wf.Status(content);

        void Status(ReadOnlySpan<char> src)
            => Wf.Status(new string(src));

        void Status(string pattern, params object[] args)
            => Wf.Status(string.Format(pattern, args));

        void Warn<T>(T content)
            => Wf.Warn(content);

        void Warn(string pattern, params object[] args)
            => Wf.Warn(string.Format(pattern,args));

        void Write<T>(T content)
            => Wf.Row(content, null);

        void Write<T>(T content, FlairKind flair)
            => Wf.Row(content,flair);

        void Write<T>(string name, T value, FlairKind? flair = null)
            => Wf.Row(RP.attrib(name, value), flair);

        void Write<T>(ReadOnlySpan<T> src, FlairKind? flair = null)
        {
            var count = src.Length;
            for(var i=0; i<count; i++)
                Write(skip(src,i), flair ?? FlairKind.Data);
        }

        void Write<T>(Span<T> src, FlairKind? flair = null)
        {
            var count = src.Length;
            for(var i=0; i<count; i++)
                Write(skip(src,i), flair ?? FlairKind.Data);
        }

        void Error<T>(T content)
            => Wf.Error(content);

        WfExecFlow<T> Running<T>(T msg, [Caller] string operation = null)
            where T : IMsgPattern
                => Wf.Running(msg, string.Format("{0,-16} | {1}", HostName, operation));

        WfExecFlow<string> Running([Caller] string msg = null)
            => Wf.Running(string.Format("{0} | {1,-16}", HostName, msg));

        ExecToken Ran<T>(WfExecFlow<T> flow, [Caller] string msg = null)
                => Wf.Ran(flow.WithMsg(string.Format("{0,-16} | {1}", HostName, msg)));

        ExecToken Ran<T,D>(WfExecFlow<T> flow, D data, [Caller] string operation = null)
            where T : IMsgPattern
                => Wf.Ran(flow.WithMsg(string.Format("{0} | {1,-16} | {2}", data, HostName, operation)));

        WfFileFlow EmittingFile(FS.FilePath dst)
            => Wf.EmittingFile(dst);

        ExecToken EmittedFile(WfFileFlow flow, Count count)
            => Wf.EmittedFile(flow,count);

        void EmittedFile(WfFileFlow file, Count count, Arrow<FS.FileUri> flow)
        {
            Wf.EmittedFile(file,count);
            Write(string.Format("flow[{0}]", flow));
        }

        WfTableFlow<T> EmittingTable<T>(FS.FilePath dst)
            where T : struct
                => Wf.EmittingTable<T>(dst);

        ExecToken EmittedTable<T>(WfTableFlow<T> flow, Count count, FS.FilePath? dst = null)
            where T : struct
                => Wf.EmittedTable(flow,count, dst);

        uint TableEmit<T>(ReadOnlySpan<T> src, FS.FilePath dst)
            where T : struct
                => Wf.TableEmit(src,dst);

        uint TableEmit<T>(ReadOnlySpan<T> src, ReadOnlySpan<byte> widths, FS.FilePath dst)
            where T : struct
                => Wf.TableEmit(src, widths, dst);

        uint TableEmit<T>(ReadOnlySpan<T> src, ReadOnlySpan<byte> widths, TextEncodingKind encoding, FS.FilePath dst)
            where T : struct
                => Wf.TableEmit(src, widths, encoding, dst);

        uint TableEmit<T>(ReadOnlySpan<T> src, ReadOnlySpan<byte> widths, StreamWriter writer, FS.FilePath dst)
            where T : struct
                => Wf.TableEmit(src, widths, writer, dst);

        uint TableEmit<T>(ReadOnlySpan<T> src, ReadOnlySpan<byte> widths, ushort rowpad, Encoding encoding, FS.FilePath dst)
            where T : struct
                => Wf.TableEmit(src, widths, rowpad,  encoding, dst);

        Outcome<uint> EmitLines(ReadOnlySpan<TextLine> src, FS.FilePath dst, TextEncodingKind encoding)
            => Wf.EmitLines(src,dst,encoding);
    }
}
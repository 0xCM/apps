// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0
// {
//     using System;
//     using System.Runtime.CompilerServices;

//     using static core;
//     using static Root;

//     [CmdDispatcher]
//     public class GlobalCommands : AppService<GlobalCommands>, ICmdDispatcher
//     {
//         CmdDispatcher Dispatcher;

//         public GlobalCommands()
//         {
//         }

//         protected override void Initialized()
//         {
//             Dispatcher = Cmd.dispatcher(this);
//         }


//         [CmdOp("import-sdm-opcodes")]
//         Outcome SdmImport(CmdArgs args)
//         {
//             var result = Outcome.Success;
//             Wf.IntelSdm().ImportOpCodes();
//             return result;
//         }

//         [CmdOp("emit-metadata-sets")]
//         protected Outcome EmitMetadataSets(CmdArgs args)
//         {
//             var options = WorkflowOptions.@default();
//             Wf.CliEmitter().EmitMetadaSets(options);
//             return true;
//         }

//         [CmdOp("emit-intel-intrinsics")]
//         Outcome EmitIntelIntrinsics(CmdArgs args)
//         {
//             Wf.IntelIntrinsics().Emit();
//             return true;
//         }

//         [CmdOp("emit-api-comments")]
//         protected Outcome EmitApiComments(CmdArgs args)
//         {
//             Wf.ApiComments().Collect();
//             return true;
//         }

//         [CmdOp("emit-api-classes")]
//         protected Outcome EmitApiClasses(CmdArgs args)
//         {
//             Wf.ApiCatalogs().EmitApiClasses();
//             return true;
//         }

//         [CmdOp("emit-call-table")]
//         protected Outcome EmitCallTable(CmdArgs args)
//         {
//             Wf.AsmCallPipe().EmitRows(Wf.AsmDecoder().Decode(Blocks()));
//             return true;
//         }

//         [CmdOp("emit-hex-pack")]
//         protected Outcome EmitHexPack(CmdArgs args)
//         {
//             var sorted = SortedBlocks();
//             Wf.ApiHexPacks().Emit(sorted);
//             return true;
//         }

//         [CmdOp("emit-cli-metadata")]
//         protected Outcome EmitCliMetadata(CmdArgs args)
//         {
//             var pipe = Wf.CliEmitter();
//             pipe.EmitRowStats(Wf.ApiCatalog.Components, Db.IndexTable<CliRowStats>());
//             pipe.EmitFieldDefs(Wf.ApiCatalog.Components, Db.IndexTable<FieldDefInfo>());
//             pipe.EmitMethodDefs(Wf.ApiCatalog.Components, Db.IndexTable<MethodDefInfo>());
//             return true;
//         }

//         [CmdOp("emit-cil-opcodes")]
//         protected Outcome EmitCilOpCodes(CmdArgs args)
//         {
//             var dst = Db.IndexTable<CilOpCode>();
//             TableEmit(Cil.opcodes(), dst);
//             return true;
//         }

//         [CmdOp("emit-sym-literals")]
//         protected Outcome EmitSymLiterals(CmdArgs args)
//         {
//             var service = Wf.Symbolism();
//             var dst = Db.AppTablePath<SymLiteralRow>();
//             service.EmitLiterals(dst);
//             return true;
//         }

//         [CmdOp(".emit-api-tokens")]
//         protected Outcome EmitApiTokens(CmdArgs args)
//         {
//             Wf.ApiMetadata().EmitApiTokens();
//             return true;
//         }

//         [CmdOp("emit-respack")]
//         protected Outcome EmitResPack(CmdArgs args)
//         {
//             Wf.ResPackEmitter().Emit(Blocks());
//             return true;
//         }

//         [CmdOp("asm-gen-models")]
//         protected Outcome GenAsmModels(CmdArgs args)
//         {
//             var generator = Wf.Generators();
//             var dst = generator.CodeGenDir("asm.models");
//             //Wf.AsmModelGen().GenModels();
//             return true;
//         }

//         [CmdOp("capture-v2")]
//         protected Outcome CaptureV2(CmdArgs args)
//         {
//            Wf.ApiExtractWorkflow().Run(args);
//            return true;
//         }

//         [CmdOp("emit-xed-catalog")]
//         protected Outcome EmitXedCat(CmdArgs args)
//         {
//            Wf.IntelXed().EmitCatalog();
//            return true;
//         }

//         [CmdOp("capture-process")]
//         protected Outcome RunMachine(CmdArgs args)
//         {
//             using var machine = MachineRunner.create(Wf);
//             machine.Run(WorkflowOptions.@default());
//             return true;
//         }

//         [CmdOp("capture")]
//         protected Outcome CaptureV1(CmdArgs args)
//         {
//             var result = Capture.run();
//             return true;
//         }

//         public Outcome Dispatch(string command, CmdArgs args)
//             => Dispatcher.Dispatch(command, args);

//         public Outcome Dispatch(string command)
//             => Dispatcher.Dispatch(command);

//         public ReadOnlySpan<string> Supported
//         {
//             [MethodImpl(Inline)]
//             get => Dispatcher.Supported;
//         }

//         ReadOnlySpan<ApiCodeBlock> Blocks()
//             => Wf.ApiHex().ReadBlocks().Storage;

//         SortedIndex<ApiCodeBlock> SortedBlocks()
//             => Wf.ApiHex().ReadBlocks().Storage.ToSortedIndex();
//     }
// }
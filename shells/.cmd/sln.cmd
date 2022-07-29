@echo off
call %~dp0config.cmd
%SlnTool% %ShellWs%\calcs.check\z0.calcs.check.csproj
%SlnTool% %ShellWs%\intel\z0.intel.csproj
%SlnTool% %ShellWs%\workers\z0.workers.csproj
%SlnTool% %LibRoot%\api.checks\z0.api.checks.csproj
%SlnTool% %LibRoot%\asm.checks\z0.asm.checks.csproj
%SlnTool% %LibRoot%\clr.checks\z0.clr.checks.csproj
%SlnTool% %LibRoot%\db.shell\z0.db.shell.csproj
%SlnTool% %LibRoot%\llvm.checks\z0.llvm.checks.csproj
%SlnTool% %LibRoot%\memory.checks\z0.memory.checks.csproj
%SlnTool% %LibRoot%\queues.checks\z0.queues.checks.csproj
%SlnTool% %LibRoot%\sos.checks\z0.sos.checks.csproj
%SlnTool% %TestRoot%\test.shell\z0.test.shell.csproj
%SlnTool% %CgRoot%\cg.shell\z0.cg.shell.csproj
%SlnTool% %CgRoot%\cg.test\z0.cg.test.csproj


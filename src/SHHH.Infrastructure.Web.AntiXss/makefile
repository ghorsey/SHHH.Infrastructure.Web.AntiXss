NuGet = ../.nuget/nuget.exe
Name = SHHH.Infrastructure.Web.AntiXss.

SPEC:
	@ECHO CREATING SPEC...
	 $(NuGet) spec $(Name)csproj

PACK: SPEC CLEAN
	@ECHO CREATING PACK...
	$(NuGet) pack $(Name)csproj -Prop Configuration=Release

PUSH: PACK
	@ECHO PUSHING PACK...
	$(NuGet) push $(Name)*.nupkg

CLEAN:
	@ECHO CLEANING PACKS...
	rm -f $(Name)*.nupkg

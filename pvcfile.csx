pvc.Task("nuget-push", () => {
	pvc.Source("src/Pvc.Sass.csproj")
	   .Pipe(new PvcNuGetPack(
			createSymbolsPackage: true
	   ))
	   .Pipe(new PvcNuGetPush());
});
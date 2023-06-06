using Microsoft.AspNetCore.StaticFiles;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var staticFileProvider = new FileExtensionContentTypeProvider();
staticFileProvider.Mappings.Add( ".kaml", "application/kat.application.markup.language" );
app.UseStaticFiles( new StaticFileOptions { ContentTypeProvider = staticFileProvider } );

// app.MapGet("/hello", () => "Hello World!");

app.MapGet( "/katapp/{**viewName}", ( string viewName, IWebHostEnvironment webHostEnvironment ) =>
{
	var kamlPath = Path.Combine( webHostEnvironment.WebRootPath, "KatApp", viewName );
	return Results.File( kamlPath, "application/kat.application.markup.language" );
} );

app.Run();

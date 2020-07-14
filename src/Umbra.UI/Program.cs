using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Logging;
using Avalonia.Logging.Serilog;
using Avalonia.ReactiveUI;
using Serilog;
using Serilog.Filters;
using Splat;

namespace Umbra.UI
{
    class Program
    {
        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.
        public static void Main( string[] args )
        {
//#if DEBUG
//            SerilogLogger.Initialize( new LoggerConfiguration()
//                .Filter.ByIncludingOnly( Matching.WithProperty( "Area", LogArea.Layout ) )
//                .MinimumLevel.Verbose()
//                .WriteTo.Trace( outputTemplate: "{Area}: {Message}" )
//                .CreateLogger() );
//#endif

            var lumina = new Lumina.Lumina( args[0], new Lumina.LuminaOptions
            {
                CacheFileResources = true
            } );
            Locator.CurrentMutable.RegisterConstant( lumina );


            BuildAvaloniaApp().StartWithClassicDesktopLifetime( args );
        }

        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .LogToDebug()
                .UseReactiveUI();
    }
}
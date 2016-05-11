#r "artifacts/build/Cake.Npm.dll"

var target = Argument("target", "Default");
    
Task("Default")
    .Does(() => 
    {
        // npm install gulp -g
        Npm.Install(settings => settings.Package("gulp").Globally());
    
        // npm install gulp
        Npm.Install(settings => settings.Package("gulp"));
        
        // npm install gulp https://path.co/package/v0.1
        Npm.Install(settings => settings.Package("https://path.co/package/v0.1"));
        
        // npm install gulp@">3.9 && < 4.0"
        Npm.Install(settings => settings.Package("gulp", ">3.9 && <4.0"));
        
        // npm install @myorg/gulp@">3.9 && < 4.0"
        Npm.Install(settings => settings.Package("gulp", ">3.9 && <4.0", "myorg"));
        
        // npm install --production
        Npm.Install(settings => settings.ForProduction());
        
        // npm run hello
        Npm.RunScript("hello");
        
        //npm run arguments -- -debug "arg-value.file"
        Npm.RunScript("arguments", settings => settings.WithArgument("-debug").WithArgument("arg-value.file"));
        
        // get package information
        var package = Npm.Package();
        Information("Building '{0}' for version '{1}' (by {2})", package.Name, package.Version, package.Author);
    });
        
//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);    
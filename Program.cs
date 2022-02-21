//dotnet publish --configuration Release

using System.Diagnostics;

string gitCommand = "git";

string remoteName = "origin";
Console.WriteLine("Remote name: origin     [Y or type below]");
string? remoteAcceptance = Console.ReadLine();
if(remoteAcceptance == null){
    Console.WriteLine("Nothing found. Press any key to exit.");
    return;
}
else{
    if(remoteAcceptance.ToString().ToLower() != "y"){
        remoteName = remoteAcceptance.Trim().ToLower();
    }
}


string branchName = "master";
Console.WriteLine("Branch name: master     [Y or type below]");
string? branchAcceptance = Console.ReadLine();
if(branchAcceptance == null){
    Console.WriteLine("Nothing found. Press any key to exit.");
    return;
}
else{
    if(branchAcceptance.ToLower() != "y"){
        branchName = branchAcceptance.Trim().ToLower();
    }
}

string pullSwitch = "--ff-only";

string gitPullArgument = $@"pull {remoteName} {branchName} {pullSwitch}";


//==============================
try
{

    int pullInterval = 10;
    Console.WriteLine("Pull interval (minutes): 10     [Y or type below]");
    string? pullIntervalAcceptance = Console.ReadLine();
    if(pullIntervalAcceptance == null){
        Console.WriteLine("Nothing found. Press any key to exit.");
        return;
    }
    else{
        if(branchAcceptance.ToLower() != "y"){
            pullInterval = Convert.ToInt32(pullIntervalAcceptance.Trim());
        }
    }
    
    int interval = 1000 * 60 * pullInterval;
    Console.WriteLine($"Automatically pull after {pullInterval} minutes. Press ESC to stop.");
    while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape))    
    {
        System.Threading.Thread.Sleep(interval);
        Console.WriteLine($@"git {gitPullArgument} - {DateTime.Now.ToString("hh:mm:ss tt")}" );
        Process.Start(gitCommand, gitPullArgument);
    }

    Console.WriteLine("Auto pull stopped. Bye.");
}
catch (System.Exception exp)
{
    Console.WriteLine(exp.Message);
    return;
}
//=================================







using Elsa.ActivityResults;
using Elsa.Services;
using Elsa.Services.Models;
using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Woo.Wobot.Workflow.Activities;
public class CustomCommandExecute : CompositeActivity
{
    public override async ValueTask<IActivityExecutionResult> ExecuteAsync(ActivityExecutionContext context)
    {
        var command = context.GetVariable<string>("Command").ToLowerInvariant();
        Regex repoPattern =new Regex(@"(github\.com|adens\.cn)/\w+/(\w+)\.git");
        var match = repoPattern.Match(command);
        string repo = "";
        if (match.Success)
        {
            repo = match.Groups[2].Value;

        }
       
        string[] adensPatterns = new string[]{
            "github.com/adensw/*",
            "git.adens.cn/*"};
        string githubPattern= "github.com/(?!adensw)/*";
        try{ 
        if(Regex.IsMatch(command, githubPattern))
        {
            var path =Repository.Clone(command, @"C:\Users\wangdingchen\Repos\Github\"+repo);
            Console.WriteLine(path);
        }
        for (int i = 0; i < adensPatterns.Length; i++)
        {
            if (Regex.IsMatch(command, adensPatterns[i]))
            {
                var path = Repository.Clone(command, @"C:\Users\wangdingchen\Repos\Adens\" + repo);
                Console.WriteLine(path);

                return Done();
            }
        }
        }catch(Exception ex)
        {
            Console.WriteLine(ex.Message);

        }
        return Done();
    }
}

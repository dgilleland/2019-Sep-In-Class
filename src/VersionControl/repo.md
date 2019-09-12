# Make Use of Issues

```markdown
Support various Command-line args for your app.

- [ ] List supported templates
- [ ] Display specific template
- [ ] Create .gitignore
- [ ] Interactive mode
- [ ] Help text
- [ ] Version
```

`repo list`
`repo show visualstudio`
`repo create windows visualstudio`
`repo help`
`repo version`

----

## Overview

In this tutorial, we covered the following.

> ## Create Issues
>
> - Proof-of-concept (reading from the API)
> - Save .gitignore to file - `System.IO.File.WriteAllText(path, text)`
> - `System.IO.File.ReadAllText` vs `.ReadAllLines`
> - Command-line args

----

## Complete Code

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12
{
    class Program
    {
        const string API_BASE = "https://www.gitignore.io/api/";
        const string API_LIST_LINES = API_BASE + "list?format=lines";
        const string API_LIST_JSON = API_BASE + "list?format=json";

        static void Main(string[] args)
        {
            DisplayContent(API_LIST_LINES);
            DisplayContent(API_BASE + "macos,windows,visualstudio");
        }
        static void DisplayContent(string path)
        {
            var client = new HttpClient();
            var response = client.GetAsync(path).GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                Console.WriteLine(content);
            }
        }
    }
}
```

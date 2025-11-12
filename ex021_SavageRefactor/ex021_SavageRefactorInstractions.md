# 🧩 Lesson 21 – Professional Refactor (Savage Mode)
### Subtitle: *“Make your chaos look corporate.”*

---

## 🎯 Objective
Take the single-file **Final Boss Project** and turn it into a professional multi-file, multi-namespace solution.  
No hints. No mercy. Only structure.

---

## 🪓 Instructions

### 1️⃣ Create a new project
- **Name:** `FinalBossRefactored`
- **Type:** Console App (.NET 8)
- **Template:** Empty. No sample code. No soul.

---

### 2️⃣ Rebuild the folder structure
Inside your project root, create:

Controllers/
Models/
Services/
Views/
Utilities/

yaml
Copy code

---

### 3️⃣ Slice the monster
From the original file:

| Move this part | To this folder |
|----------------|----------------|
| `Product`, `Order` classes | `Models/` |
| `StoreController` class | `Controllers/` |
| `DataRepository`, `Logger` | `Services/` |
| `RazorView` | `Views/` |
| Any helper / extension | `Utilities/` |

---

### 4️⃣ Add namespaces
Each file **must** live under its own namespace.

namespace FinalBossRefactored.Models
namespace FinalBossRefactored.Controllers
namespace FinalBossRefactored.Services
namespace FinalBossRefactored.Views
namespace FinalBossRefactored.Utilities

csharp
Copy code

If you forget this step, enjoy 200 red squiggles.

---

### 5️⃣ Remove static abuse
Convert services into interfaces + injected instances.

```csharp
public interface IDataRepository { ... }
public interface ILoggerService { ... }

public class StoreController
{
    private readonly IDataRepository _repo;
    private readonly ILoggerService _log;

    public StoreController(IDataRepository repo, ILoggerService log)
    {
        _repo = repo;
        _log = log;
    }
}
Now the controller depends on abstractions, not chaos.

6️⃣ Clean up Program.cs
The entry point should only:

csharp
Copy code
var services = new ServiceCollection();
services.AddSingleton<IDataRepository, DataRepository>();
services.AddSingleton<ILoggerService, LoggerService>();
services.AddTransient<StoreController>();
var provider = services.BuildServiceProvider();

var controller = provider.GetRequiredService<StoreController>();
await controller.RunMenuAsync();
Nothing else.
If you put logic in Program.cs, you failed DevOps before starting it.

7️⃣ Async everything
All repository calls → async.
All controller actions → await.
If you block threads, Giannis Pythonopoulos will block your salary.

8️⃣ Make it look like something you'd dare to commit
Proper indentation

Logical namespaces

Clear folder hierarchy

Each class does one thing only

Comments optional, sarcasm mandatory

💀 Extra Savage Challenges
Add IOrderService to separate order logic.

Move LINQ queries to Utilities/Extensions.cs.

Add Configuration.json to preload product data.

Implement ILoggerService.LogAsync() and await responsibly.

Build a fake Razor template renderer that returns an HTML-like string.

🧱 Expected Outcome
A structure that could pass a code review without the reviewer sighing loudly.

⚔️ Additional Exercise (to be added)
Assignment: [describe here — to be added by instructor]
The student must implement an extra functionality, integrated properly into the refactored structure.

⚰️ Deadpan Closing Remark
“Congratulations. You’ve just rewritten the same code in more files.
Welcome to enterprise development.”
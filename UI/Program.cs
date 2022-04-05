using UI;
using BL;
using DL;

string connectionString = File.ReadAllText("./connectionString.txt");

// Dependency Injection
IRepository repo = new DBRepository(connectionString);
ISLBL bl = new SLBL(repo);
new MainMenu(bl).Start();
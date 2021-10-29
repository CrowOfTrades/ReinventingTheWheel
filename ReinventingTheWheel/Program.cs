using ReinventingTheWheel.Models;
using ReinventingTheWheel.Recreated;

BaseList<Aluno> list = new();

list.AddFirst(new Aluno("Alfredo"));
list.AddLast(new Aluno("Fred"));
list.RemoveFirst();
list.RemoveLast();
list.AddFirst(new Aluno("Zacarias"));
list.AddFirst(new Aluno("Zueiral"));
list.AddLast(new Aluno("Carla"));
list.RemoveLast();

Aluno? first = list.FirstOrDefault();
Aluno? last = list.LastOrDefault();
Aluno? index = list.Index(2);

list.Show();

Console.ReadKey();

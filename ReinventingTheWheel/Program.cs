using ReinventingTheWheel;

BaseList<Aluno> list = new();

list.AddFirst(new Aluno("Alfredo"));
list.AddLast(new Aluno("Fred"));
list.AddFirst(new Aluno("Zacarias"));
list.AddFirst(new Aluno("Zueiral"));
list.AddLast(new Aluno("Carla"));

list.Show();

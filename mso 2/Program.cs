using System;
using System.Numerics;
using mso_2;
using mso_3;
class Program
{
    static void Main()
    {
        Grid grid = new Grid(0, 0);
        MoveEntity entity = new MoveEntity(new Vector2(1,0), new Vector2(0, 0), grid);

        var move = new MoveCommand(10);
        var turnRight = new TurnCommand(TurnDirection.Right);
        var repeat = new RepeatCommand(4);

        var composite = new CompositeCommand();
        composite.Add(repeat);
        repeat.Add(move);

        Console.WriteLine(composite.Execute(entity));
        Console.WriteLine(entity.GetStatusString());

        Metrics metrics = new Metrics(composite);
        metrics.Analyze();
        Console.WriteLine(metrics.getStringData());
    }
}

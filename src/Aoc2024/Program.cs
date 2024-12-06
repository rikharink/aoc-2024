if (args.Length == 1)
{
    if (args[0].Equals("all", StringComparison.CurrentCultureIgnoreCase))
    {
        Runner.RunAll();
        return 0;
    }

    if (!int.TryParse(args[0], out var day) || day < 1 || day > 25)
    {
        Console.Error.WriteLine($"Invalid day number {args[0]}");
        return 1;
    }

    Runner.Run(day);
    return 0;
}

Runner.Run();
return 0;
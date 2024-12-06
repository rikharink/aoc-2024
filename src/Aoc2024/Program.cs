var day = args.Length == 1 ? int.Parse(args[0]) : -1;
if (day is > 0 and < 26)
{
    Runner.Run(day);
}
else
{
    Runner.Run();
}
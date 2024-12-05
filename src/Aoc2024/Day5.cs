using System.Collections.Immutable;

namespace Aoc2024;

public class Day5(string? input = null) : Day<int>(input)
{
    private FrozenSet<PageOrderingRule> _orderingRules = null!;
    private ImmutableArray<PrintJob> _printJobs;

    public record struct PageOrderingRule(int PageA, int PageB)
    {
        public static PageOrderingRule Parse(string input)
        {
            var (a, b) = input.SplitOn("|");
            return new PageOrderingRule(int.Parse(a), int.Parse(b));
        }
    }

    public record PrintJob(int[] Pages)
    {
        public static PrintJob Parse(string input)
            => new(input.Split(",").Select(int.Parse).ToArray());
    }

    protected override void ParseInput()
    {
        var (top, bottom) = Input.SplitOnBlankLine();
        _orderingRules = top.SplitNewLines().Select(PageOrderingRule.Parse).ToFrozenSet();
        _printJobs = [..bottom.SplitNewLines().Select(PrintJob.Parse)];
    }

    private bool IsCorrect(PrintJob job)
    {
        foreach (var rule in _orderingRules)
        {
            var aIndex = Array.IndexOf(job.Pages, rule.PageA);
            var bIndex = Array.IndexOf(job.Pages, rule.PageB);

            if (aIndex == -1 || bIndex == -1)
            {
                continue;
            }

            if (aIndex > bIndex)
            {
                return false;
            }
        }

        return true;
    }

    private PrintJob FixIncorrect(PrintJob job)
    {
        bool didFix;
        do
        {
            didFix = false;
            foreach (var rule in _orderingRules)
            {
                var aIndex = Array.IndexOf(job.Pages, rule.PageA);
                var bIndex = Array.IndexOf(job.Pages, rule.PageB);

                if (aIndex == -1 || bIndex == -1)
                {
                    continue;
                }

                if (aIndex <= bIndex) continue;

                (job.Pages[aIndex], job.Pages[bIndex]) = (job.Pages[bIndex], job.Pages[aIndex]);
                didFix = true;
            }
        } while (didFix);
        return job;
    }

    public override int Part1()
    {
        return _printJobs
            .Where(IsCorrect)
            .Select(j => j.Pages[j.Pages.Length / 2])
            .Sum();
    }

    public override int Part2()
    {
        var incorrectJobs = _printJobs.Where(j => !IsCorrect(j)).ToImmutableArray();
        var fixedJobs = incorrectJobs.Select(FixIncorrect).ToImmutableArray();
        
        if(!fixedJobs.All(IsCorrect))
            throw new InvalidOperationException("Not all jobs are fixed.");
        
        return fixedJobs.Select(j => j.Pages[j.Pages.Length / 2]).Sum();
    }
}
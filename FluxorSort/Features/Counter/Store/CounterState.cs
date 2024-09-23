using Fluxor;

namespace FluxorSort.Features.Counter.Store;


[FeatureState(Name = nameof(CounterState))]
public record CounterState
{
    public int Count { get; init; }

    private CounterState() {}
}

using Fluxor;
using FluxorSort.Features.Sorting.Sorters;
using FluxorSort.Features.Sorting.Store.Actions;
using FluxorSort.Features.Sorting.Types;

namespace FluxorSort.Features.Sorting.Store.Effects;

public class ExecuteSwapsEffect(IState<SortingState> state)
{

    [EffectMethod]
    public async Task HandleExecuteSwapsAction(ExecuteSwapsAction swapsAction, IDispatcher dispatcher)
    {
        if (state.Value.IsSorting is false || swapsAction.Swaps.Count is 0)
        {
            dispatcher.Dispatch(new PauseSortingAction());
            return;
        }

        var swap = swapsAction.Swaps.Dequeue();
        dispatcher.Dispatch(swap);

        await Task.Delay(1); //Delay to ensure reducers have time to update state for each swap

        dispatcher.Dispatch(swapsAction);
    }
}

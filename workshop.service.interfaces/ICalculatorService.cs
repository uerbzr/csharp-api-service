using workshop.data.models;

namespace workshop.service.interfaces;

public interface ICalculatorService
{
    Task<bool> QueueItem(int a, int b);
    Task<bool> Calculate();
    Task<IEnumerable<Calculation>> GetAll();
    Task<IEnumerable<Calculation>> GetQueued();


}

using workshop.data.models;
using workshop.repository.interfaces;
using workshop.service.interfaces;

namespace workshop.service;

public class CalculatorService : ICalculatorService
{
    private IRepository<Calculation> _repository;
    public CalculatorService(IRepository<Calculation> repository)
    {
        _repository = repository;
    }
    public async Task<bool> QueueItem(int a, int b)
    {
        return await _repository.Insert(new Calculation { FirstNumber = a, SecondNumber = b }) is not null ? true : false;
            
    }
    public async Task<IEnumerable<Calculation>> GetAll()
    {
        var results = await _repository.Get();
        return results.Where(c => c.Result != null).ToList();
    }
    public async Task<IEnumerable<Calculation>> GetQueued()
    {
        var results = await _repository.Get();
        return results.Where(c => c.Result == null).ToList();
    }
    public async Task<bool> Calculate()
    {
        var results = await _repository.Get();
        var queued = results.Where(c => c.Result == null).ToList();
        if (queued == null || queued.Count() == 0)
        {
            return false;
        }
        foreach (var target in queued)
        {
            target.Result = target.FirstNumber + target.SecondNumber;
            target.UpdatedAt = DateTime.UtcNow;
            await _repository.Update(target);
            await _repository.Save();
        }
        return true;
    }
}

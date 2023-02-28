using StepsStatistic.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StepsStatistic.Services.Abstraction
{
    public interface ISerializerService<TModel>
    {
        Task<IEnumerable<TModel>> DeserializeAsync(FilePath filePath);
        Task SerializeAsync(FilePath filePath, TModel model);
    }
}
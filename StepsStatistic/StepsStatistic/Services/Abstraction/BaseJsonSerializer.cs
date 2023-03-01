using Newtonsoft.Json;
using StepsStatistic.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StepsStatistic.Services.Abstraction
{
    public abstract class BaseJsonSerializer<TModel> : ISerializerService<TModel>
    {
        protected JsonSerializer JsonSerializer;

        public BaseJsonSerializer(JsonSerializerSettings settings)
        {
            JsonSerializer = JsonSerializer.Create(settings);
        }

        public abstract Task<IEnumerable<TModel>> DeserializeAsync(FilePath filePath);

        public abstract Task SerializeAsync(FilePath filePath, TModel model);
    }
}
using AutoMapper;
using Newtonsoft.Json;
using StepsStatistic.Models;
using StepsStatistic.Services.Abstraction;
using StepsStatistic.Utils;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace StepsStatistic.Services
{
    public class UserSerializer : BaseJsonSerializer<UserModel>
    {
        private readonly IMapper _mapper;

        public UserSerializer(JsonSerializerSettings settings, IMapper mapper) : base(settings)
        {
            _mapper = mapper;
        }

        public override async Task<IEnumerable<UserModel>> DeserializeAsync(FilePath filePath)
        {
            return await Task.Run(() => Deserialize(filePath));
        }

        public override async Task SerializeAsync(FilePath filePath, UserModel model)
        {
            await Task.Run(() => Serialize(filePath, model));
        }

        private IEnumerable<UserModel> Deserialize(FilePath filePath)
        {
            List<UserJson> userStats;
            using (JsonTextReader reader = new JsonTextReader(new StreamReader(filePath.FullPath)))
            {
                userStats = JsonSerializer.Deserialize<List<UserJson>>(reader);
            }

            return _mapper.Map<IEnumerable<UserModel>>(userStats);
        }

        private void Serialize(FilePath filePath, UserModel model)
        {
            using (JsonTextWriter writer = new JsonTextWriter(new StreamWriter(filePath.FullPath)))
            {
                JsonSerializer.Serialize(writer, model);
            }
        }
    }
}
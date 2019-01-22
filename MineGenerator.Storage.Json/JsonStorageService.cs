using MineGenerator.Core.Storage;
using MineGenerator.Core.Storage.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace MineGenerator.Storage
{
    public class JsonStorageService : IStorageService
    {
        public Package Read(Stream stream)
        {
            Package package;
            using (var reader = new StreamReader(stream))
            {
                package = JsonConvert.DeserializeObject<Package>(reader.ReadToEnd());
            }
            return package;
        }

        public void Write(Stream stream, Package package)
        {
            var json = JsonConvert.SerializeObject(package);
            using (var writer = new StreamWriter(stream))
            {
                writer.Write(json);
            }
        }
    }
}

/**************************************************************************\
    Copyright (C) 2024-2025 SkyForge Corporation. All Rights Reserved.
    Author: Stepan Myasnikov --> tenxdeveloper.
\**************************************************************************/

using System.Text.Json;

namespace LostLifeServerMonitoring.Persistence.JsonPrefs
{
    public abstract class JsonPrefs<TModel>
    {
        private readonly string m_filePath;
        private readonly JsonSerializerOptions? m_jsonOptions;
        
        protected TModel model;
        
        protected JsonPrefs(string filePath)
        {
            m_filePath = filePath;
            m_jsonOptions = new JsonSerializerOptions();
            m_jsonOptions.WriteIndented = true;
            
            var directoryName = Path.GetDirectoryName(m_filePath);
            
            if(!Directory.Exists(directoryName))
                Directory.CreateDirectory(directoryName);
            
            if (!File.Exists(m_filePath))
                File.Create(m_filePath).Close();

            model = LoadFromJson();
        }

        public TModel LoadFromJson()
        {
            using (var fileStream = new FileStream(m_filePath, FileMode.Open))
            {
                try
                {
                    var model = JsonSerializer.Deserialize<TModel>(fileStream, m_jsonOptions);
                    return model;
                }
                catch (Exception e)
                {
                    return Activator.CreateInstance<TModel>();
                }
            }
        }

        public bool SaveToJson(TModel model)
        {
            try
            {
                var jsonData = JsonSerializer.Serialize(model, m_jsonOptions);
                File.WriteAllText(m_filePath, jsonData);
                return true;
            }
            catch (Exception exception)
            {
                Console.WriteLine($"error when try to save model: {typeof(TModel).Name}, error: {exception.Message}");
                return false;
            }
        }
        
    }
}
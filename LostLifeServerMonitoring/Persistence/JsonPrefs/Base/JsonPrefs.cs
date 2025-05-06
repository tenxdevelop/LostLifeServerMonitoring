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

        protected JsonPrefs(string filePath)
        {
            m_filePath = filePath;
            m_jsonOptions = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            
            if (!File.Exists(m_filePath))
                File.Create(m_filePath).Close();
        }

        public TModel LoadFromJson()
        {
            using var fileStream = new FileStream(m_filePath, FileMode.Open);
            try
            {
                return JsonSerializer.Deserialize<TModel>(fileStream, m_jsonOptions) ?? Activator.CreateInstance<TModel>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Activator.CreateInstance<TModel>();
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
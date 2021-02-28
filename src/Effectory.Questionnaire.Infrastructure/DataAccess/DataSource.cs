using System.IO;
using Effectory.Questionnaire.Domain;

namespace Effectory.Questionnaire.Infrastructure.DataAccess
{
    public class DataSource : ILoadDataSource
    {
        private const string DataSourceFileName = "questionnaire.json";
        
        public string Load()
        {
            if (!File.Exists(DataSourceFileName))
                throw new FileNotFoundException("Data source file cannot be found!");
            
            using var streamReader = new StreamReader(DataSourceFileName);
            var fileContent = streamReader.ReadToEnd();

            return fileContent;
        }
    }
}
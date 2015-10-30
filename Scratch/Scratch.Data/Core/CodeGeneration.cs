using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace Scratch.Data.Core
{
    /// <summary>
    /// Handles code generation for Scratch.Data.ContentData and classes in Scratch.Data.ContentDataModel
    /// </summary>
    public class CodeGeneration
    {
        public string AlterProject(string className)
        {
            const string filePath = "C:\\_Projects\\Sandbox\\Scratch\\Scratch.Data\\Scratch.Data.csproj";

            var previousLineOfText = string.Empty;
            var fileContent = new StringBuilder();

            using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite))
            using (var reader = new StreamReader(fileStream))
            {
                string lineOfText;

                while ((lineOfText = reader.ReadLine()) != null)
                {
                    var s = lineOfText.Trim().ToLower();

                    if (s.StartsWith("<compile include="))
                    {
                        previousLineOfText = lineOfText;
                    }

                    fileContent.AppendLine(lineOfText);
                }

                reader.Close();

                fileStream.Close();
            }

            File.WriteAllText(
                filePath,
                fileContent.ToString()
                    .Replace(
                        previousLineOfText,
                        String.Format(
                            "{0}{1}    <Compile Include=\"ContentDataModel\\{2}.cs\" />",
                            previousLineOfText,
                            Environment.NewLine,
                            className)));

            return string.Empty;
        }

        public string GetPath()
        {
            var codeBase = Assembly.GetExecutingAssembly().CodeBase;

            var uri = new UriBuilder(codeBase);

            var path = Uri.UnescapeDataString(uri.Path);

            return Path.GetDirectoryName(path);
        }
    }
}

using System.Data.SqlClient;
using Scratch.Data.Core;

namespace Scratch.Data
{
    public class Schema
    {
        private string ConnectionString
        {
            get { return ""; }
        }

        public void Test()
        {
            using (var contentMetadata = new ContentMetadata())
            {
                //if (!contentMetadata.Database.Exists())
                //{
                //    contentMetadata.Database.Create();
                //}
                //corecontentMetadata.Database.CreateIfNotExists();

                // two-way schema / data model synchronization:
                //  - detect any changes to schema as defined by data model; construct the new tables, etc.
                //  - code generation tool which takes content types from database schema, and generates classes with interfaces and mapper/builder methods
                
                // when a content type is added:
                //  - create its tables on the schema (for active content records)
                //  - if versioning/archiving/history/draft-publish is enabled, create the table for that
                //  - save metadata about the content type
                //  - generate a class file for an entity data model 
                //  - generate an interface based on this class
                //  - include MapTo and BuildFrom methods in the class; they accept an instance of the interface as input parameter
                //  - include a parameterless constructor and one overloaded to ccept an instance of the interface as input parameter; this one calls BuildFrom
                //  - edit the project file to include generated files

                //contentMetadata.Database.CompatibleWithModel()
                //corecontentMetadata.Database.Initialize();
            }
        }

        public void CreateTable()
        {
            var sql = @"
                IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ContentTypes]') AND type in (N'U'))
                BEGIN
                    CREATE TABLE [ContentTypes]
                    (
	                    [Id] [uniqueidentifier] NOT NULL,
	                    [Name] [varchar](50) NOT NULL,
                        CONSTRAINT [PK_ContentTypes] PRIMARY KEY CLUSTERED ([Id] ASC)
                        WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
                        ON [PRIMARY]
                    )
                    ON [PRIMARY]
                END";

            

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                try
                {
                    using (var command = new SqlCommand(sql, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}

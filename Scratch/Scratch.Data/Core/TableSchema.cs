using System.Data.SqlClient;

namespace Scratch.Data.Core
{
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

	// Options for consuming the generated code:
	//  - Problem: A content type entity is created on the fly, including database table and data model class. It requires CRUD operations to be available after creation, but the new code that was generated is not compiled and available to the runtime. It is primarily an aid to the developer who needs to extend the system. It does however need to be operable dynamically without a recompile.
	//  - Solution: Use reflection on entity / data model type and/or data context to determine whether or not it exists (are compiled). The entity names are conventional in this strategy.
	//      a. If not yet compiled: build SQL for CRUD operations
	//      b. If compiled: Use a generic repository for CRUD operations

	public class TableSchema : DataBase
	{
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



			using (var connection = new SqlConnection(Components.Configuration.ConnectionString))
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

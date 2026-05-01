# apbdKolokwium1Base

Adding the required NuGet
	1. Right click on ur project
	2. Manage NuGet
	3. Put Microsoft.Data.SqlClient in the Search box
	4. + and install

Ways of retreiving data:
-ExecuteReader() - is used for SELECTS
-ExecuteScalar() - when SELECT GIVES 1 VALUE(MAX, COUNT, MIN etc.)
-ExecuteNonQuery() - int - number of modified/added/deleted rows
All of them have asynchronous versions:
-ExecuteReaderAsync()
-ExecuteScalarAsync()
-ExecuteNonQueryAsync()

Null w C# i Null w bazach danych to dwa inne
Null w bazach danych w C# reprezentowany jest przez DBNull i jest metoda IsDBNull

	
using apbdKolokwium1Base.DTOs;

namespace apbdKolokwium1Base.Services;
using Microsoft.Data.SqlClient; //remember to add this here

public class SampleDbService : ISampleDbService //interface for dependency injection
{
    private readonly string _connectionString;
    
    public SampleDbService(IConfiguration config)
    {
        _connectionString = config.GetConnectionString("The Name of the connection string from appsettings.json(usually DefaultConnection)") ?? String.Empty;
    }

    public async Task<List<SampleDto>> SampleSelectWithTranscation()
    {
        List<SampleDto> list = new List<SampleDto>();
        
        var query = "some query";

        await using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();
        
        SqlTransaction transaction = connection.BeginTransaction();

        try
        {
            using var command = new SqlCommand(query, connection);

            //replaces a parameter with some value
            command.Parameters.AddWithValue("@SomeParameter", "Some Value");
            
            using var reader =  await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                SampleDto dto = new SampleDto();
                dto.SampleString = reader.GetString(0);
                dto.SampleInt = reader.GetInt32(1);
                dto.SampleDateTime = reader.GetDateTime(2);
                list.Add(dto);
            }
            
            //commits transaction at the end
            await transaction.CommitAsync();
        }
        catch (Exception e)
        {
            //rolls back transaction if an error is met
            await transaction.RollbackAsync();
            throw;
        }

        return list;
    }
    
    
}
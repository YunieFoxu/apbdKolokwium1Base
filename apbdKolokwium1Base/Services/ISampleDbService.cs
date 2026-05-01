using apbdKolokwium1Base.DTOs;

namespace apbdKolokwium1Base.Services;

public interface ISampleDbService
{
    //remember to put all methods in here
    Task<List<SampleDto>> SampleSelectWithTranscation();
}
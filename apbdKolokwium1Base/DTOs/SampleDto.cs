using System.ComponentModel.DataAnnotations;

namespace apbdKolokwium1Base.DTOs;

public class SampleDto
{
    [StringLength((200))] //constraint(should proly be in a controller tho)
    public string SampleString { get; set; } = string.Empty;
    public int SampleInt { get; set; }
    public DateTime SampleDateTime { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace Taller_2_PatronProxy.Models;

public class Heroes
{
    [Key]
    public int Hero_Id { get; set; }
    public string Name { get; set; }
    public string Secret_Name { get; set; }
    public string Description { get; set; }
    public string Power { get; set; }
    public bool IsAlive { get; set; }
}
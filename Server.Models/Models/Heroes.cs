namespace Server.Models.Models;

public class Heroes
{
    public int Hero_Id { get; set; }
    public string Name { get; set; }
    public string Secret_Name { get; set; }
    public string Description { get; set; }
    public string Power { get; set; }
    public bool IsAlive { get; set; }
}
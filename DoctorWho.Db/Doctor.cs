namespace DoctorWho.Db;

public class Doctor
{
    public int DoctorId { get; set; }
    public string DoctorNumber { get; set; }
    public string DoctorName { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime? FirstEpisodeDate { get; set; }
    public DateTime? LastEpisodeDate { get; set; }
}
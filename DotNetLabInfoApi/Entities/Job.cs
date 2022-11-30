namespace DotNetLabInfoApi.Entities
{
    public class Job
    {
        public int Id { get; set; }
        public string JobName { get; set; }
        public string JobDescription { get; set; }
        public string JobStatus { get; set; }
        public DateTime? HiringExpiration { get; set; }
    }
}

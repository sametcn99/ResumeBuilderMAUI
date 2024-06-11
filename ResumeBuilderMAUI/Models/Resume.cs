namespace ResumeBuilderMAUI.Models
{

    public class Person
    {
        public string? ResumeId { get; set; }
        public DateTime? ResumeDate { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Summary { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Website { get; set; }
        public string? LinkedIn { get; set; }
        public string? GitHub { get; set; }
        public string? Languages { get; set; }
        public string? Address { get; set; }
    }

    public class Certification
    {
        public string? ResumeId { get; set; }
        public int Id { get; set; }
        public string? Name { get; set; }
    }

    public class Education
    {
        public string? ResumeId { get; set; }
        public int Id { get; set; }
        public string? School { get; set; }
        public string? Degree { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public string? Grade { get; set; }
        public string? Description { get; set; }
    }

    public class Experience
    {
        public string? ResumeId { get; set; }
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Company { get; set; }
        public string? Position { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public string? Description { get; set; }
    }

    public class Project
    {
        public string? ResumeId { get; set; }
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public string? Status { get; set; }
        public string? Link { get; set; }
    }

    public class Skill
    {
        public string? ResumeId { get; set; }
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}

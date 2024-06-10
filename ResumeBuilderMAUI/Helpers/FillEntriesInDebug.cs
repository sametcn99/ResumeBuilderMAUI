using ResumeBuilderMAUI.Models;
using ResumeBuilderMAUI.Services;
using ResumeBuilderMAUI.ViewModels;

namespace ResumeBuilderMAUI.Helpers
{
    public class FillEntriesInDebug
    {
        public static async void FillEntries(MainViewModel mainViewModel)
        {

            // Personal Information
            mainViewModel.FirstName = "John";
            mainViewModel.LastName = "Doe";
            mainViewModel.Summary = "Highly motivated and results-driven Software Developer with over 3 years of experience in designing, developing, and deploying cutting-edge applications. " +
                                     "Expertise in C#, .NET, and modern web development frameworks. Proven ability to deliver high-quality software solutions within tight deadlines. " +
                                     "Strong problem-solving skills and a keen eye for detail, with a passion for learning new technologies and methodologies. " +
                                     "Experienced in working collaboratively within cross-functional teams to achieve project goals. " +
                                     "Dedicated to continuous improvement and staying updated with the latest industry trends. " +
                                     "Proficient in agile development practices and capable of adapting quickly to changing requirements. " +
                                     "Committed to writing clean, maintainable code and creating seamless user experiences.";
            mainViewModel.PhoneNumber = "1234567890";
            mainViewModel.Email = "john.doe@example.com";
            mainViewModel.Website = "https://www.johndoe.com";
            mainViewModel.LinkedIn = "https://www.linkedin.com/in/johndoe";
            mainViewModel.GitHub = "https://www.github.com/johndoe";
            mainViewModel.Certifications.Add("Microsoft Certified: Azure Developer Associate");
            mainViewModel.Certifications.Add("Certified Scrum Master (CSM)");
            mainViewModel.Languages = "English, Spanish";
            mainViewModel.Address = "1600 Pennsylvania Ave NW, Washington, DC 20500";
            mainViewModel.SkillList.Add("C#");
            mainViewModel.SkillList.Add(".NET");
            mainViewModel.SkillList.Add("ASP.NET Core");
            mainViewModel.SkillList.Add("Angular");
            mainViewModel.SkillList.Add("Xamarin");
            mainViewModel.SkillList.Add("SQL Server");
            mainViewModel.SkillList.Add("Azure");
            mainViewModel.SkillList.Add("Git");
            mainViewModel.SkillList.Add("Agile");
            mainViewModel.SkillList.Add("Scrum");

            mainViewModel.Educations.Add(new Education
            {
                Id = 1,
                Description = "In-depth study of computer science fundamentals including data structures, algorithms, software engineering principles, and system design. Participated in various projects and hackathons, gaining practical experience.",
                Grade = "3.5",
                School = "University of XYZ",
                Degree = "Bachelor of Science in Computer Science",
                StartDate = "2015-08-01",
                EndDate = "2019-05-01",
            });

            mainViewModel.Experiences.Add(new Experience
            {
                Id = 1,
                Title = "Software Developer",
                Company = "XYZ Corp",
                Position = "Software Developer",
                StartDate = "2019-06-01",
                EndDate = "2021-07-01",
                Description = "Worked on developing and maintaining web applications using C# and .NET framework. Implemented various features and enhancements, fixed bugs, and collaborated with cross-functional teams to ensure timely delivery of projects."
            });

            mainViewModel.Experiences.Add(new Experience
            {
                Id = 2,
                Title = "Software Engineer",
                Company = "ABC Inc",
                Position = "Software Engineer",
                StartDate = "2021-08-01",
                EndDate = "Present",
                Description = "Responsible for designing and developing scalable cloud-based applications using Azure services. " +
                              "Collaborated with product managers and UX designers to create user-friendly interfaces and optimize application performance. " +
                              "Implemented CI/CD pipelines for automated testing and deployment. " +
                              "Participated in code reviews and provided mentorship to junior developers. " +
                              "Contributed to the architecture and design of new features and services. " +
                              "Actively involved in agile ceremonies and sprint planning to deliver high-quality software solutions."
            });

            mainViewModel.Projects.Add(new Project
            {
                Id = 1,
                Title = "E-commerce Website",
                Description = "Developed a fully functional e-commerce website using ASP.NET Core and Angular. The project involved creating a responsive and user-friendly interface for an optimal shopping experience. " +
                              "Integrated a secure payment gateway to handle transactions seamlessly. Implemented user authentication and authorization to ensure data security and privacy. " +
                              "Optimized the website for performance and scalability to handle a large number of concurrent users. " +
                              "Conducted thorough testing and debugging to ensure the application was free of errors and provided a smooth user experience. " +
                              "The project was completed on time and received positive feedback from stakeholders for its functionality and reliability.",
                StartDate = "2021-08-01",
                EndDate = "2022-01-01",
                Link = "https://www.project1.com"
            });

            mainViewModel.Projects.Add(new Project
            {
                Id = 2,
                Title = "Mobile Application for Task Management",
                Description = "Currently developing a cross-platform mobile application using Xamarin and MAUI for efficient task management. " +
                              "The app allows users to create, edit, and track tasks, set reminders, and sync data across devices. " +
                              "Key features include a user-friendly interface with drag-and-drop functionality for task organization, real-time notifications for upcoming deadlines, and secure cloud synchronization to ensure data is always up-to-date. " +
                              "The project aims to improve productivity and time management for individuals and teams. " +
                              "Ongoing development involves close collaboration with UI/UX designers to enhance user experience and incorporating user feedback to continuously improve the app's functionality. " +
                              "Expected to launch in the app stores once the final phase of testing and optimization is completed.",
                StartDate = "2022-02-01",
                EndDate = "Present",
                Link = "https://www.project2.com"
            });

            try
            {
                string ResumeId = $"{mainViewModel.FirstName}_{mainViewModel.LastName}_{DateTime.Now:yyyy_MM_dd_HH_mm_ss}";

                await LocalDbService.AddPerson(new Person
                {
                    ResumeId = ResumeId,
                    FirstName = mainViewModel.FirstName,
                    LastName = mainViewModel.LastName,
                    Summary = mainViewModel.Summary,
                    PhoneNumber = mainViewModel.PhoneNumber,
                    Email = mainViewModel.Email,
                    Website = mainViewModel.Website,
                    LinkedIn = mainViewModel.LinkedIn,
                    GitHub = mainViewModel.GitHub,
                    Languages = mainViewModel.Languages,
                    Address = mainViewModel.Address
                });

                for (int i = 0; i < mainViewModel.Certifications.Count; i++)
                {
                    await LocalDbService.AddCertification(new Certification
                    {
                        ResumeId = ResumeId,
                        Id = i,
                        Name = mainViewModel.Certifications[i]
                    });
                }
                for (int i = 0; i < mainViewModel.Educations.Count; i++)
                {
                    var education = mainViewModel.Educations[i];
                    await LocalDbService.AddEducation(new Education
                    {
                        ResumeId = ResumeId,
                        Id = education.Id,
                        School = education.School,
                        Degree = education.Degree,
                        StartDate = education.StartDate,
                        EndDate = education.EndDate,
                        Description = education.Description
                    });
                }

                for (int i = 0; i < mainViewModel.Experiences.Count; i++)
                {
                    var experience = mainViewModel.Experiences[i];
                    await LocalDbService.AddExperience(new Experience
                    {
                        ResumeId = ResumeId,
                        Id = experience.Id,
                        Company = experience.Company,
                        Position = experience.Position,
                        StartDate = experience.StartDate,
                        EndDate = experience.EndDate,
                        Description = experience.Description
                    });
                }

                for (int i = 0; i < mainViewModel.Projects.Count; i++)
                {
                    var project = mainViewModel.Projects[i];
                    await LocalDbService.AddProject(new Project
                    {
                        ResumeId = ResumeId,
                        Id = i,
                        Title = project.Title,
                        Description = project.Description,
                        StartDate = project.StartDate,
                        EndDate = project.EndDate,
                        Status = project.Status,
                        Link = project.Link
                    });
                }

                for (int i = 0; i < mainViewModel.SkillList.Count; i++)
                {
                    var skill = mainViewModel.SkillList[i];
                    await LocalDbService.AddSkill(new Skill
                    {
                        Id = i,
                        ResumeId = ResumeId,
                        Name = skill
                    });
                }

            }
            catch (Exception ex)
            {
                DisplayAlertHelpers.ShowAlert("Error", ex.Message);
            }
        }
    }
}

using ResumeBuilderMAUI.Models;
using ResumeBuilderMAUI.ViewModels;

namespace ResumeBuilderMAUI.Helpers
{
    public class FillEntriesInDebug
    {
        public static void FillEntries(MainViewModel mainViewModel)
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
            mainViewModel.Certifications = "Microsoft Certified: Azure Developer Associate";
            mainViewModel.Languages = "English, Spanish";
            mainViewModel.Address = "123 Main St, City, State, Zip";
            mainViewModel.SkillList = new System.Collections.ObjectModel.ObservableCollection<string>
            {
                "C#",
                "Xamarin",
                "MAUI",
                "Azure",
                "JavaScript",
                "SQL"
            };

            mainViewModel.Educations.Add(new EducationModel
            {
                Id = 1,
                Description = "In-depth study of computer science fundamentals including data structures, algorithms, software engineering principles, and system design. Participated in various projects and hackathons, gaining practical experience.",
                Grade = "3.5",
                School = "University of XYZ",
                Degree = "Bachelor of Science in Computer Science",
                StartDate = "2015-08-01",
                EndDate = "2019-05-01",
            });

            mainViewModel.Experiences.Add(new ExperienceModel
            {
                Id = 1,
                Title = "Software Developer",
                Company = "XYZ Corp",
                Position = "Software Developer",
                StartDate = "2019-06-01",
                EndDate = "2021-07-01",
                Description = "Worked on developing and maintaining web applications using C# and .NET framework. Implemented various features and enhancements, fixed bugs, and collaborated with cross-functional teams to ensure timely delivery of projects."
            });

            mainViewModel.Projects.Add(new ProjectModel
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
                Status = "Completed",
                Link = "https://www.project1.com"
            });

            mainViewModel.Projects.Add(new ProjectModel
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
                EndDate = "2022-07-01",
                Status = "In Progress",
                Link = "https://www.project2.com"
            });
        }
    }
}

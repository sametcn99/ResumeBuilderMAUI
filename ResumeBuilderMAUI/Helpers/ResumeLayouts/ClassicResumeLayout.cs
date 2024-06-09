using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using ResumeBuilderMAUI.ViewModels;

namespace ResumeBuilderMAUI.Helpers
{
    internal class ClassicResumeLayout
    {
        [Obsolete]
        public static Document GenerateClassicResumeLayout(MainViewModel mainViewModel)
        {
            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(1, Unit.Centimetre);
                    page.DefaultTextStyle(x => x.FontSize(14));
                    page.Header().Row(row =>
                    {
                        row.RelativeItem().Stack(stack =>
                        {
                            stack.Item().Text($"{mainViewModel.FirstName} {mainViewModel.LastName}").FontSize(16).Bold();
                        });
                    });

                    page.Content()
                        .PaddingVertical(1, Unit.Centimetre)
                        .Column(x =>
                        {
                            x.Item().Stack(stack =>
                            {
                                if (!string.IsNullOrEmpty(mainViewModel.Email))
                                    stack.Item().Text(mainViewModel.Email).FontSize(12);
                                if (!string.IsNullOrEmpty(mainViewModel.PhoneNumber))
                                    stack.Item().Text(mainViewModel.PhoneNumber).FontSize(12);

                                stack.Item().ExternalLink(mainViewModel.Website ?? "").Text(mainViewModel.Website?.Replace("www.", "") ?? "").FontSize(12);
                                stack.Item().ExternalLink(mainViewModel.GitHub ?? "").Text(mainViewModel.GitHub?.Replace("www.", "") ?? "").FontSize(12);
                                stack.Item().ExternalLink(mainViewModel.LinkedIn ?? "").Text(mainViewModel.LinkedIn?.Replace("www.", "") ?? "").FontSize(12);

                                if (mainViewModel.Email != null)
                                    stack.Item().Text(mainViewModel.Address).FontSize(12);

                                if (mainViewModel.Summary != null)
                                    stack.Item().PaddingTop(5, Unit.Millimetre).Text(mainViewModel.Summary);
                            });

                            if (mainViewModel.Languages != null)
                                if (mainViewModel.Languages.Length > 0)
                                    x.Item().PaddingTop(5, Unit.Millimetre).Column(column =>
                                    {
                                        column.Item().Text("Languages").Bold().FontSize(14);
                                        column.Item().Text(mainViewModel.Languages);
                                    });

                            if (mainViewModel.SkillList.Count > 0)
                                x.Item().PaddingTop(5, Unit.Millimetre).Column(column =>
                                {
                                    column.Item().Text("Skills").Bold().FontSize(14);
                                    string skillText = "";
                                    foreach (var skill in mainViewModel.SkillList)
                                    {
                                        skillText = skillText + ", " + skill;
                                    }
                                    skillText = skillText.TrimStart(',', ' ').Trim();
                                    column.Item().Text(skillText);
                                });

                            if (mainViewModel.Educations.Count > 0)
                                x.Item().PaddingTop(5, Unit.Millimetre).Column(column =>
                                {
                                    column.Item().Text("Education").Bold().FontSize(14);
                                    foreach (var education in mainViewModel.Educations)
                                    {
                                        column.Item().PaddingTop(2, Unit.Millimetre).Text($"{education.School} {education.Degree}").Bold();
                                        column.Item().Text($"{education.StartDate} - {education.EndDate} , Grade: {education.Grade}").Italic().FontSize(12);
                                        column.Item().Text(education.Description);
                                    }
                                });

                            if (mainViewModel.Experiences.Count > 0)
                                x.Item().PaddingTop(5, Unit.Millimetre).Column(column =>
                                {
                                    column.Item().Text("Experience").Bold().FontSize(16);
                                    foreach (var experience in mainViewModel.Experiences)
                                    {
                                        column.Item().PaddingTop(2, Unit.Millimetre).Text($"{experience.Company} {experience.Position}").Bold();
                                        column.Item().Text($"{experience.StartDate} - {experience.EndDate}").Italic().FontSize(12);
                                        column.Item().Text(experience.Description);
                                    }
                                });

                            if (mainViewModel.Projects.Count > 0)
                            {
                                x.Item().PaddingTop(5, Unit.Millimetre).Column(column =>
                                {
                                    column.Item().Text("Projects").Bold().FontSize(14);
                                    foreach (var project in mainViewModel.Projects)
                                    {
                                        column.Item().PaddingTop(2, Unit.Millimetre).Text(project.Title).Bold();
                                        column.Item().Stack(stack =>
                                        {
                                            stack.Item().Text($"{project.StartDate}/ {project.EndDate}").Italic().FontSize(12);
                                            if (!string.IsNullOrEmpty(project.Link))
                                                stack.Item().ExternalLink(project.Link).Text(project.Link).Italic().FontSize(12);
                                        });
                                        column.Item().Text(project.Description);
                                    }
                                });
                            }
                        });
                    page.Footer()
                        .AlignCenter()
                        .Text(x =>
                        {
                            x.Span("Page ").FontSize(10);
                            x.CurrentPageNumber().FontSize(10);
                        });
                });
            });
            return document;
        }
    }
}
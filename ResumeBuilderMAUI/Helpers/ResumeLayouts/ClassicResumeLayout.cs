using PdfSharp.Drawing;
using PdfSharp.Pdf;
using ResumeBuilderMAUI.ViewModels;

namespace ResumeBuilderMAUI.Helpers
{
    internal class ClassicResumeLayout
    {
        public static async Task GenerateClassicResumeLayout(MainViewModel mainViewModel)
        {
            var document = new PdfDocument();
            document.Info.Title = "Resume";

            var page = document.AddPage();
            var gfx = XGraphics.FromPdfPage(page);

            var fontRegular = new XFont("Verdana", 12, XFontStyleEx.Regular);
            var fontSmall = new XFont("Verdana", 10, XFontStyleEx.Regular);
            var fontBold = new XFont("Verdana", 14, XFontStyleEx.Bold);
            var fontItalic = new XFont("Verdana", 12, XFontStyleEx.Italic);

            double margin = 50;
            double y = margin;
            double pageWidth = page.Width - 2 * margin;
            double pageHeight = page.Height - 2 * margin;

            void DrawText(ref PdfPage page, ref XGraphics gfx, string text, XFont font, ref double y, double pageWidth, double pageHeight)
            {
                var words = text.Split(' ');
                string line = "";
                foreach (var word in words)
                {
                    var testLine = line + word + " ";
                    var size = gfx.MeasureString(testLine, font);
                    if (size.Width > pageWidth)
                    {
                        CheckForNewPage(ref page, ref gfx, ref y, pageHeight);
                        gfx.DrawString(line, font, XBrushes.Black, new XRect(margin, y, pageWidth, 20), XStringFormats.TopLeft);
                        line = word + " ";
                        y += 20;
                    }
                    else
                    {
                        line = testLine;
                    }
                }
                CheckForNewPage(ref page, ref gfx, ref y, pageHeight);
                gfx.DrawString(line, font, XBrushes.Black, new XRect(margin, y, pageWidth, 20), XStringFormats.TopLeft);
                y += 20;
            }

            void CheckForNewPage(ref PdfPage page, ref XGraphics gfx, ref double y, double pageHeight)
            {
                if (y + 20 > pageHeight)
                {
                    page = document.AddPage();
                    gfx = XGraphics.FromPdfPage(page);
                    y = margin;
                }
            }

            // Header
            DrawText(ref page, ref gfx, $"{mainViewModel.FirstName} {mainViewModel.LastName}", fontBold, ref y, pageWidth, pageHeight);

            // Contact Information
            if (!string.IsNullOrEmpty(mainViewModel.Email))
                DrawText(ref page, ref gfx, mainViewModel.Email, fontSmall, ref y, pageWidth, pageHeight);

            if (!string.IsNullOrEmpty(mainViewModel.PhoneNumber))
                DrawText(ref page, ref gfx, mainViewModel.PhoneNumber, fontSmall, ref y, pageWidth, pageHeight);

            if (!string.IsNullOrEmpty(mainViewModel.Website))
                DrawText(ref page, ref gfx, mainViewModel.Website.Replace("www.", ""), fontSmall, ref y, pageWidth, pageHeight);

            if (!string.IsNullOrEmpty(mainViewModel.GitHub))
                DrawText(ref page, ref gfx, mainViewModel.GitHub.Replace("www.", ""), fontSmall, ref y, pageWidth, pageHeight);

            if (!string.IsNullOrEmpty(mainViewModel.LinkedIn))
                DrawText(ref page, ref gfx, mainViewModel.LinkedIn.Replace("www.", ""), fontSmall, ref y, pageWidth, pageHeight);

            if (!string.IsNullOrEmpty(mainViewModel.Address))
                DrawText(ref page, ref gfx, mainViewModel.Address, fontSmall, ref y, pageWidth, pageHeight);

            // Summary
            if (!string.IsNullOrEmpty(mainViewModel.Summary))
                DrawText(ref page, ref gfx, mainViewModel.Summary, fontRegular, ref y, pageWidth, pageHeight);

            // Languages
            if (mainViewModel.Languages != null && mainViewModel.Languages.Length > 0)
            {
                DrawText(ref page, ref gfx, "Languages", fontBold, ref y, pageWidth, pageHeight);
                DrawText(ref page, ref gfx, string.Join(", ", mainViewModel.Languages), fontRegular, ref y, pageWidth, pageHeight);
            }

            // Skills
            if (mainViewModel.SkillList.Count > 0)
            {
                DrawText(ref page, ref gfx, "Skills", fontBold, ref y, pageWidth, pageHeight);
                DrawText(ref page, ref gfx, string.Join(", ", mainViewModel.SkillList), fontRegular, ref y, pageWidth, pageHeight);
            }

            // Education
            if (mainViewModel.Educations.Count > 0)
            {
                DrawText(ref page, ref gfx, "Education", fontBold, ref y, pageWidth, pageHeight);
                foreach (var education in mainViewModel.Educations)
                {
                    DrawText(ref page, ref gfx, $"{education.School} - {education.Degree}", fontBold, ref y, pageWidth, pageHeight);
                    DrawText(ref page, ref gfx, $"{education.StartDate} - {education.EndDate} , Grade: {education.Grade}", fontItalic, ref y, pageWidth, pageHeight);
                    DrawText(ref page, ref gfx, education.Description, fontRegular, ref y, pageWidth, pageHeight);
                }
            }

            // Experience
            if (mainViewModel.Experiences.Count > 0)
            {
                DrawText(ref page, ref gfx, "Experience", fontBold, ref y, pageWidth, pageHeight);
                foreach (var experience in mainViewModel.Experiences)
                {
                    DrawText(ref page, ref gfx, $"{experience.Company} - {experience.Position}", fontBold, ref y, pageWidth, pageHeight);
                    DrawText(ref page, ref gfx, $"{experience.StartDate} - {experience.EndDate}", fontItalic, ref y, pageWidth, pageHeight);
                    DrawText(ref page, ref gfx, experience.Description, fontRegular, ref y, pageWidth, pageHeight);
                }
            }

            // Projects
            if (mainViewModel.Projects.Count > 0)
            {
                DrawText(ref page, ref gfx, "Projects", fontBold, ref y, pageWidth, pageHeight);
                foreach (var project in mainViewModel.Projects)
                {
                    DrawText(ref page, ref gfx, project.Title, fontBold, ref y, pageWidth, pageHeight);
                    DrawText(ref page, ref gfx, $"{project.StartDate} - {project.EndDate}", fontItalic, ref y, pageWidth, pageHeight);
                    if (!string.IsNullOrEmpty(project.Link))
                        DrawText(ref page, ref gfx, project.Link, fontItalic, ref y, pageWidth, pageHeight);
                    DrawText(ref page, ref gfx, project.Description, fontRegular, ref y, pageWidth, pageHeight);
                }
            }

            // Save the document
            using (var stream = new MemoryStream())
            {
                document.Save(stream, false);
                var data = stream.ToArray();

                if (data != null)
                {
                    string fileName = $"{mainViewModel.FirstName}_{mainViewModel.LastName}_{DateTime.Now:yyyy_MM_dd_HH_mm_ss}.pdf";
                    var cancellationToken = new CancellationToken();
                    await Dialogs.SaveResume(cancellationToken, fileName, data);
                }
            }
        }
    }
}

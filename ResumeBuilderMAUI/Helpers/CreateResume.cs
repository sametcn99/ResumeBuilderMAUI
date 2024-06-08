using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace ResumeBuilderMAUI.Helpers
{
    internal class CreateResume
    {
        public static void CreateResumePDF()
        {
            string filePath = Path.Combine(FileSystem.Current.AppDataDirectory, $"{DateTime.Now:yyyyMMdd_HHmmss}.pdf");

            try
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }
            catch (IOException ioEx)
            {
                Application.Current.MainPage.DisplayAlert("Error", $"File operation error: {ioEx.Message}", "OK");
                return;
            }

            try
            {
                var document = Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Size(PageSizes.A4);
                        page.Margin(2, Unit.Centimetre);
                        page.DefaultTextStyle(x => x.FontSize(20));

                        page.Header()
                            .Text("Hello PDF!")
                            .SemiBold().FontSize(36);

                        page.Content()
                            .PaddingVertical(1, Unit.Centimetre)
                            .Column(x =>
                            {
                                x.Spacing(20);

                                x.Item().Text(Placeholders.LoremIpsum());
                                x.Item().Image(Placeholders.Image(200, 100));
                            });

                        page.Footer()
                            .AlignCenter()
                            .Text(x =>
                            {
                                x.Span("Page ");
                                x.CurrentPageNumber();
                            });
                    });
                });
                Application.Current.MainPage.DisplayAlert("Success", $"PDF Created Successfully\n {filePath}", "OK");
                // open the PDF file
                try
                {
                    document.GeneratePdf(filePath);
                }
                catch (Exception ex)
                {
                    Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
                }
            }
            catch (Exception ex)
            {
                Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}

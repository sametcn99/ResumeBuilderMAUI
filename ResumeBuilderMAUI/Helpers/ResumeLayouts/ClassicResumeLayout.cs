using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using ResumeBuilderMAUI.ViewModels;

namespace ResumeBuilderMAUI.Helpers
{
    internal class ClassicResumeLayout
    {
        public static Document GenerateClassicResumeLayout(MainViewModel mainViewModel)
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
            return document;
        }
    }
}

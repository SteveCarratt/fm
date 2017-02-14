using System;
using System.Diagnostics;
using System.IO;
using Tesseract;

namespace Recognition
{
    public class Recognise
    {
        public static string TessdataDir { get; set; } =
            Path.Combine(Path.GetDirectoryName(typeof(Recognise).Assembly.Location), "tessdata");


        public static bool TryReadStringFromImage(byte[] imageStream, out string answer)
        {
            answer = string.Empty;
            try
            {
                answer = ReadStringFromImage(imageStream);
                return true;
            }
            catch (Exception e)
            {
                Trace.TraceError(e.ToString());
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        public static string ReadStringFromImage(byte[] imageStream)
        {
            using (var engine = new TesseractEngine(TessdataDir, "eng", EngineMode.Default))
            {
                engine.DefaultPageSegMode = PageSegMode.SingleLine;

                using (var img = Pix.LoadTiffFromMemory(imageStream))
                {
                    using (var page = engine.Process(img))
                    {
                        var text = page.GetText();

                        return text.Trim();
                    }
                }
            }
        }

        public static bool TryReadIntFromImage(string imagePath, out int number)
        {
            string answer;
            number = 0;
            return TryReadStringFromImage(File.ReadAllBytes(imagePath), out answer) && int.TryParse(answer, out number);
        }

        public static bool TryReadIntFromImage(byte[] imageStream, out int number)
        {
            string answer;
            number = 0;
            return TryReadStringFromImage(imageStream, out answer) && int.TryParse(answer, out number);
        }
    }
}
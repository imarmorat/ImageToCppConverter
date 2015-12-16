using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RazorEngine.Templating;
using RazorEngine;
using System.IO;

namespace ImageToCppConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            var templatePath = "template1.cppx";
            var templateOutput = "template1.cpp";

            var image = Bitmap.FromFile("Images/warm 24.png");
            var data = ImageData.FromBitmap((Bitmap) image);
            data.Name = "temperatureIcon";

            var templateContent = File.ReadAllText(templatePath);
            string myParsedTemplate = Engine.Razor.RunCompile(templateContent, "templateNameInTheCache", null, data);
            File.WriteAllText(templateOutput, myParsedTemplate);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using FM;
using ImageProcessor;
using ImageProcessor.Imaging.Filters.EdgeDetection;
using ImageProcessor.Imaging.Formats;

namespace Recognition
{
    public class AttributesImage
    {
        private readonly string _imagePath;

        public AttributesImage(string imagePath)
        {
            _imagePath = imagePath;
        }

        public int GetValueForAttribute(PlayerAttribute attribute)
        {
            using (ImageFactory imageFactory = new ImageFactory(preserveExifData: true))
            {
                int value;
                if (TryGetAttributeValue(imageFactory, AttributesMask.Masks.First(x => x.Key == attribute), out value))
                {
                    return value;
                }
                else return 0;
            }
        }

        public PlayerAttributes GetAttributes()
        {
            var attributes = new WritablePlayerAttributes();
            using (ImageFactory imageFactory = new ImageFactory(preserveExifData: true))
            {
                foreach (var attributeMask in AttributesMask.Masks)
                {
                    int value;
                    if (TryGetAttributeValue(imageFactory, attributeMask, out value))
                    {
                        attributes[attributeMask.Key] = value;
                    }
                }
            }

            return attributes;
        }

        private bool TryGetAttributeValue(ImageFactory imageFactory, KeyValuePair<PlayerAttribute, Rectangle> attributeMask, out int value)
        {
            value = 0;
            foreach (var operation in _operations)
            {
                var memStream = new MemoryStream();

                var image = operation.Value(imageFactory.Load(_imagePath)
                    .Crop(attributeMask.Value)).Format(new TiffFormat());

                image.Save(memStream);

                memStream.Seek(0, SeekOrigin.Begin);

                int attributeValue;

                var imageStream = memStream.ToArray();
                if (Recognise.TryReadIntFromImage(imageStream, out attributeValue))
                {
                    value = attributeValue;
                    return true;
                }

                var wrongstring = Recognise.ReadStringFromImage(imageStream);

                Console.WriteLine($"Attribute {attributeMask.Key} not found by {operation.Key}. String read was {wrongstring}");

                var croppedValueImagePath = Path.Combine(Path.GetDirectoryName(_imagePath),
                    Path.GetFileNameWithoutExtension(_imagePath) +
                    $"cropped{attributeMask.Key}value{operation.Key}.tiff");

                image.Save(croppedValueImagePath);
            }

            return false;
        }

        private readonly KeyValuePair<string, Func<ImageFactory, ImageFactory>>[] _operations =
        {
            new KeyValuePair<string, Func<ImageFactory, ImageFactory>>("normal", x => x),
            new KeyValuePair<string, Func<ImageFactory, ImageFactory>>("white-background",
                x => x.ReplaceColor(Color.FromArgb(61, 75, 72), Color.White, 10)),
            new KeyValuePair<string, Func<ImageFactory, ImageFactory>>("detect-edges",
                x => x.DetectEdges(new PrewittEdgeFilter())),
            
        };
    }
}
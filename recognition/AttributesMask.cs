using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using FM;

namespace Recognition
{
    public class AttributesMask
    { 
        public static PlayerAttribute[] Attributes = Enum.GetValues(typeof(PlayerAttribute)).Cast<PlayerAttribute>().ToArray();

        private static int AttributesLeftStart = 740;
        private static int AttributesTopStart = 381;
        private static int AttributesColumnHeight = 595;
        private static int AttributesColumnMaxLength = 14;
        private static int AttributesCount = Attributes.Length;
        private static int AttributeHeight = AttributesColumnHeight/AttributesColumnMaxLength;
        private static int AttributeKeyWidth = 230;
        private static int AttributeValueMargin = 65;
        private static int AttributeValueWidth = 50;
        public static ReadOnlyDictionary<PlayerAttribute, Rectangle> Masks;


        static AttributesMask()
        {
            var rectangles = new Dictionary<PlayerAttribute, Rectangle> (AttributesCount);

            for (var i = 0; i < Attributes.Length; i++)
            {
                var columnIndex = i/ AttributesColumnMaxLength;
                var attributeTop = AttributesTopStart + ((i - columnIndex*14) *AttributeHeight);
                var attributeValueLeftStart = AttributesLeftStart + (columnIndex +1)*(AttributeKeyWidth + AttributeValueMargin) + columnIndex * AttributeValueWidth;

                rectangles[Attributes[i]] = new Rectangle(attributeValueLeftStart, attributeTop, AttributeValueWidth, AttributeHeight);
            }

            Masks = new ReadOnlyDictionary<PlayerAttribute, Rectangle>(rectangles);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Interferometr 
{
    public enum TypesItems
    {
        EmptyItem,
        Polarizer,
        Filter,
        Phaseshifter,
        Bomb
    }
    public enum OrientationItem
    {
        Vertical,
        Horizontal
    }
    public class ItemObj

    {
        private Rect rect1 = new Rect(0, 0, 0, 0);

        private TypesItems type1 = TypesItems.EmptyItem;
        public static List<BitmapImage> itemsImg { set; get; } = null;

        private OrientationItem orientation1 = OrientationItem.Vertical;
        public ItemObj(Rect myRect, OrientationItem orientation = OrientationItem.Vertical)
        {
            rect1 = myRect;
            orientation1 = orientation;
        }

/// Функция вставки картинки элемента в дропзон
        public void Draw(DrawingContext drawingContext, double coeff, double coeff1)
        {
            SolidColorBrush br = new SolidColorBrush(Color.FromRgb(25, 25, 125));
            Rect rect2 = new Rect(rect1.X*coeff, rect1.Y * coeff1, rect1.Width * coeff, rect1.Height * coeff1);
            Pen pen = new Pen(br, 1);
            drawingContext.DrawRectangle(br, pen, rect2);
        }
    }


}

using Interferometr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace Interferometr
{
    /// <summary>
    /// Interaction logic for DropZone.xaml
    /// </summary>
    public partial class DropZone : UserControl
    {
        public DropZone()
        {
            InitializeComponent();
            ///Bottom Horizontal
            items.Add(new ItemObj(new Rect(201, 700, 45, 130)));
            items.Add(new ItemObj(new Rect(265, 700, 45, 130)));
            items.Add(new ItemObj(new Rect(391, 700, 45, 130)));
            items.Add(new ItemObj(new Rect(476, 700, 45, 130)));
            items.Add(new ItemObj(new Rect(562, 700, 45, 130)));
            items.Add(new ItemObj(new Rect(648, 700, 45, 130)));
            items.Add(new ItemObj(new Rect(732, 700, 45, 130)));
            /// Upper Horizontal
            items.Add(new ItemObj(new Rect(385, 223, 45, 130)));
            items.Add(new ItemObj(new Rect(471, 223, 45, 130)));
            items.Add(new ItemObj(new Rect(557, 223, 45, 130)));
            items.Add(new ItemObj(new Rect(643, 223, 45, 130)));
            items.Add(new ItemObj(new Rect(727, 223, 45, 130)));
            items.Add(new ItemObj(new Rect(867, 223, 45, 130)));
            /// Left Vertical
            items.Add(new ItemObj(new Rect(280, 672, 130, 45)));
            items.Add(new ItemObj(new Rect(280, 587, 130, 45)));
            items.Add(new ItemObj(new Rect(280, 502, 130, 45)));
            items.Add(new ItemObj(new Rect(280, 426, 130, 45)));
            items.Add(new ItemObj(new Rect(280, 343, 130, 45)));
            /// Right Vertical
            items.Add(new ItemObj(new Rect(754, 672, 130, 45)));
            items.Add(new ItemObj(new Rect(754, 587, 130, 45)));
            items.Add(new ItemObj(new Rect(754, 502, 130, 45)));
            items.Add(new ItemObj(new Rect(754, 426, 130, 45)));
            items.Add(new ItemObj(new Rect(754, 343, 130, 45)));
            items.Add(new ItemObj(new Rect(754, 198, 130, 45)));

            ///Добавить элементы

        }

        public 

/// <summary>
        /// Обьявление прямоугольников
        /// </summary>
        List<BitmapImage> itemsImg = new List<BitmapImage>();
        List<ItemObj> items = new List<ItemObj>();
        

        private void UserControl_Drop(object sender, DragEventArgs e)
        {
            var droppedBrush = (Brush)e.Data.GetData("COLOR");
            this.Background = droppedBrush;
///            borderRect.StrokeDashArray = null;
///            borderRect.Stroke = Brushes.Black;
        }

        private void UserControl_DragEnter(object sender, DragEventArgs e)
        {
///            borderRect.StrokeDashArray = new DoubleCollection() { 4, 2 };
///            borderRect.Stroke = Brushes.LightBlue;
        }

        private void UserControl_DragLeave(object sender, DragEventArgs e)
        {
///            borderRect.StrokeDashArray = null;
///            borderRect.Stroke = Brushes.Black;
        }
        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            Draw(drawingContext);
            //            drawingContext.DrawDrawing(backingStore);
        }

        ///Функция для вставки картинки установки
        protected void Draw(DrawingContext drawingContext)
        {
            var fileName = @"Pictures/Scheme.png";

            System.IO.FileInfo fi = new System.IO.FileInfo(fileName);
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(fi.FullName, UriKind.Absolute);
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            bitmap.EndInit();

            DrawingVisual dv = new DrawingVisual();
            using (DrawingContext dc = dv.RenderOpen())
            {
                double coeff = (double)ActualWidth / 1200.0;
                double coeff1 = (double)ActualHeight / 840;
                dc.DrawImage(bitmap, new Rect(0, 0, (int)ActualWidth, (int)ActualHeight));
                foreach (var item in items)
                {
                    item.Draw(dc, coeff, coeff1);
                }
            }
            RenderTargetBitmap rtb = new RenderTargetBitmap((int)ActualWidth, (int)ActualHeight, 96, 96, PixelFormats.Pbgra32);
            rtb.Render(dv);
            image.Source = rtb;
        }
    }
}

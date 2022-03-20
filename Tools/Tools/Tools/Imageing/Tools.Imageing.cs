using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
//using System.Windows.Media.Imaging;
using Tools.Extensions;
using Tools.SysIO;
//using System.Windows.Media;
using Color = System.Drawing.Color;
//Version 0.3

//You sould import from nuget the System.Drawing.Common
///Allow unsafe code in the project properties for the <seealso cref="Tools.Imageing.GenericImage.ToBitmap"/>()

/// <summary>
/// Holds a diversified of tools to handle efficient programs.
/// </summary>
namespace Tools
{
    namespace Imageing
    {
        public class Resolution
        {
            public int Height { get; private set; }
            public int Width { get; private set; }

            public Resolution(int width, int height)
            {
                this.Width = width;
                this.Height = height;
            }

            public static implicit operator Resolution((int width,int height) tuple)
            {
                return new Resolution(tuple.width, tuple.height);
            }
            public static implicit operator Resolution(Size size)
            {
                return new Resolution(size.Width, size.Height);
            }

            public static explicit operator Size(Resolution resolution)=>new Size(resolution.Width,resolution.Height);
            public static explicit operator (int Width,int Height)(Resolution resolution)=>(resolution.Width,resolution.Height);
        }
        /// <summary>
        /// Indicates how this image should be saved to the system memory.
        /// </summary>
        public enum ImageSaveMethod
        {
            /// <summary>
            /// Indicates that this image will be save as raw value in the file with the database. fatser load-takes more disc space.
            /// </summary>
            RawOnFile=0,
            /// <summary>
            /// Indicates that this image will be save as a link to an image file outside of the  database. slower load time- takes less disc space.
            /// </summary>
            Linked=1
        }

        /// <summary>
        /// Represent an image of the basic pixel format 32-bit ARGB
        /// </summary>
        public class GenericImage : ICloneable,IStoreable
        {
            private uint[,] Canvas;
            /// <summary>
            /// The width of the image.
            /// </summary>
            public int Width { get { return Canvas.GetLength(0); } }
            /// <summary>
            /// The height of the image.
            /// </summary>
            public int Height { get { return Canvas.GetLength(1); } }
            /// <summary>
            /// The size of the image.
            /// </summary>
            public Resolution Resolution => new Resolution(Width, Height);
            /// <summary>
            /// The saving method of this image, <see cref="ImageSaveMethod.RawOnFile"/> by default.
            /// </summary>
            public ImageSaveMethod SaveMethod { get; set; } = ImageSaveMethod.RawOnFile;
            /// <summary>
            /// If <see cref="SaveMethod"/> is <see cref="ImageSaveMethod.Linked"/> this property indicates the format in which the image should be save.
            /// </summary>
            public ImageFormat LinkedSaveFormat { get; set; } = ImageFormat.Png;
            /// <summary>
            /// Returns the url of this image if saved via <see cref="ImageSaveMethod.Linked"/>.
            /// <para>
            /// File suffix would be derived only from the <see cref="LinkedSaveFormat"/>.
            /// </para>
            /// </summary>
            public string LinkedFileURL
            {
                get
                {
                    if (linkedFileUrl == "\\")
                        return this.GetHashCode() +"."+ LinkedSaveFormat.ToString();
                    return this.linkedFileUrl;
                }
                set
                {
                    this.linkedFileUrl = value+"."+LinkedSaveFormat.ToString();
                }
            }
            private string linkedFileUrl = "\\";


            /// <summary>
            /// Returns the pixel color in the <paramref name="widthIndex"/> and <paramref name="heightIndex"/> position
            /// </summary>
            /// <param name="widthIndex"></param>
            /// <param name="heightIndex"></param>
            /// <returns></returns>
            public Color this[int widthIndex, int heightIndex]
            {
                get
                {
                    unchecked
                    {
                        return Color.FromArgb((int)Canvas[widthIndex, heightIndex]);
                    }
                }
                set
                {
                    SetPixel(value, widthIndex, heightIndex);
                }
            }

            #region Constructors
            /// <summary>
            /// creates an empty 0 sized image
            /// </summary>
            public GenericImage()
            {
                Canvas = new uint[0, 0];
            }
            /// <summary>
            /// creates an image from the color 2 dimensional array
            /// </summary>
            /// <param name="image"></param>
            public GenericImage(Color[,] image)
            {
                Canvas = new uint[image.GetLength(0), image.GetLength(1)];
                for (int i = 0; i < Canvas.GetLength(0); i++)
                {
                    for (int j = 0; j < Canvas.GetLength(1); j++)
                    {
                        Canvas[i, j] = (uint)image[i, j].ToArgb();
                    }
                }
            }
            /// <summary>
            /// creates an image from the array which each cell represents a 32 bit color of ARGB
            /// </summary>
            /// <param name="image"></param>
            public GenericImage(int[,] image)
            {
                Canvas = new uint[image.GetLength(0), image.GetLength(1)];
                for (int i = 0; i < Canvas.GetLength(0); i++)
                    for (int j = 0; j < Canvas.GetLength(1); j++)
                        Canvas[i, j] = (uint)image[i, j];
            }
            /// <summary>
            /// creates an image from the byte[,] that every 4 adjacent cells represent a value of Alpha, Red, Green and Blue between 0-255.
            /// </summary>
            /// <param name="image"></param>
            public GenericImage(byte[,] image)
            {
                Canvas = new uint[image.GetLength(0) / 4, image.GetLength(1)];
                for (int i = 0; i < Canvas.GetLength(0); i++)
                {
                    for (int j = 0; j < Canvas.GetLength(1); j++)
                    {
                        Canvas[i, j] = 0;
                        Canvas[i, j] += (256 * 256 * 256 * (uint)image[i * 4, j] + 256 * 256 * (uint)image[i * 4 + 1, j] + 256 * (uint)image[i * 4 + 2, j] + image[i * 4 + 3, j]);
                    }
                }
            }
            /// <summary>
            /// creates an image from the array which each cell represents a 32 bit color of ARGB
            /// </summary>
            /// <param name="image"></param>
            public GenericImage(uint[,] image)
            {
                Canvas = new uint[image.GetLength(0), image.GetLength(1)];
                for (int i = 0; i < Canvas.GetLength(0); i++)
                    for (int j = 0; j < Canvas.GetLength(1); j++)
                        Canvas[i, j] = image[i, j];
            }
            /// <summary>
            /// Creates a black image with the attributes above.
            /// </summary>
            /// <param name="Width"></param>
            /// <param name="Height"></param>
            public GenericImage(int Width, int Height)
            {
                Canvas = new uint[Width, Height];
            }
            /// <summary>
            /// Creates Black image with theresulotion above.
            /// </summary>
            /// <param name="r"></param>
            public GenericImage(Resolution r)
            {
                Canvas = new uint[r.Width, r.Height];
            }
            #endregion
            #region Setters
            /// <summary>
            /// Sets the pixel in (<paramref name="widthIndex"/>,<paramref name="heightIndex"/>) to the color represented by <seealso cref="uint"/> color.
            /// </summary>
            /// <param name="color"></param>
            /// <param name="widthIndex"></param>
            /// <param name="heightIndex"></param>
            public void SetPixel(uint color, int widthIndex, int heightIndex)
            {
                Canvas[widthIndex, heightIndex] = color;
            }
            /// <summary>
            /// Sets the pixel in (<paramref name="widthIndex"/>,<paramref name="heightIndex"/>) to the color represented by <seealso cref="Color"/> color.
            /// </summary>
            /// <param name="color"></param>
            /// <param name="widthIndex"></param>
            /// <param name="heightIndex"></param>
            public void SetPixel(Color color, int widthIndex, int heightIndex)
            {
                unchecked
                {
                    Canvas[widthIndex, heightIndex] = (uint)color.ToArgb();
                }
            }
            #endregion
            #region ImageMethods
            /// <summary>
            /// Makes the whole image the same color
            /// </summary>
            /// <param name="color"></param>
            public void Wipe(Color color)
            {
                uint c = (uint)color.ToArgb();
                int w = Width, h = Height;
                for (int i = 0; i < w; i++)
                {
                    for (int j = 0; j < h; j++)
                    {
                        Canvas[i, j] = c;
                    }
                }
            }
            /// <summary>
            /// Creates a gradient from up to down of the image.
            /// </summary>
            /// <param name="up">The color to be at the upper line of the image.</param>
            /// <param name="down">The color to be at the lower line of the image.</param>
            public void GradientUpDown(Color up, Color down)
            {
                int h = Height, w = Width;
                for (int j = 0; j < h; j++)
                {
                    double r = (down.R - up.R) * (j / (double)w) + up.R;
                    double g = (down.G - up.G) * (j / (double)w) + up.G;
                    double b = (down.B - up.B) * (j / (double)w) + up.B;
                    uint c = (uint)Color.FromArgb((int)r, (int)g, (int)b).ToArgb();
                    for (int i = 0; i < w; i++)
                    {
                        Canvas[i, j] = c;
                    }
                }
            }
            /// <summary>
            /// Creates a gradient from left to right of the image.
            /// </summary>
            /// <param name="left">The color to be at the most left line of the image.</param>
            /// <param name="right">The color to be at the most right line of the image.</param>
            public void GradientLeftRight(Color left, Color right)
            {
                int h = Height, w = Width;
                for (int i = 0; i < w; i++)
                {
                    double r = (right.R - left.R) * (i / (double)w) + left.R;
                    double g = (right.G - left.G) * (i / (double)w) + left.G;
                    double b = (right.B - left.B) * (i / (double)w) + left.B;
                    var color= Color.FromArgb((int)r, (int)g, (int)b).ToArgb();
                    uint c;
                    unchecked
                    {
                        c = (uint)color;
                    }
                    for (int j = 0; j < h; j++)
                    {
                        Canvas[i, j] = c;
                    }
                }
            }
            /// <summary>
            /// Creates gradient between 2 points
            /// </summary>
            /// <param name="point1"></param>
            /// <param name="color1"></param>
            /// <param name="point2"></param>
            /// <param name="color2"></param>
            public void Gradient(Point point1, Color color1, Point point2, Color color2)
            {
                int width = this.Width;
                int height = this.Height;
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        Point p = new Point(i, j);
                        double d1 = p.Distance(point1), d2 = p.Distance(point2);
                        double dis = d1 + d2;
                        Color c = Color.Black;
                        double ratio1 = d2 / dis;
                        double ratio2 = 1 - ratio1;
                        c = c.Add(color1.Multiply(ratio1));
                        c = c.Add(color2.Multiply(ratio2));
                        Canvas[i, j] = (uint)c.ToArgb();
                    }
                }
            }
            /// <summary>
            /// Replace every pixel with the old color with the new one
            /// </summary>
            /// <param name="_old">The old color to replace</param>
            /// <param name="_new">The new color to put in.</param>
            public void Replace(Color _old, Color _new)
            {
                uint old = (uint)_old.ToArgb();
                uint n = (uint)_new.ToArgb();
                for (int i = 0; i < Width; i++)
                    for (int j = 0; j < Height; j++)
                        if (Canvas[i, j] == old)
                            Canvas[i, j] = n;
            }
            #endregion

            #region PrivateMethods
            /// <summary>
            /// Multiplies all <paramref name="color"/>'s values (except opacity) by <paramref name="number"/>
            /// </summary>
            /// <param name="color"></param>
            /// <param name="number"></param>
            /// <returns></returns>
            private Color Multiply(Color color, double number)
            {
                double[] d = new double[] { color.R * number, color.G * number, color.B * number };
                for (int i = 0; i < 3; i++)
                {
                    if (d[i] > 255)
                        d[i] = 255;
                    if (d[i] < 0)
                        d[i] = 0;
                }
                return Color.FromArgb(color.A, (int)d[0], (int)d[1], (int)d[2]);
            }
            /// <summary>
            /// Divides all <paramref name="color"/>'s values (except opacity) by <paramref name="number"/>
            /// </summary>
            /// <param name="color"></param>
            /// <param name="number"></param>
            /// <returns></returns>
            private Color Divide(Color color, double number)
            {
                return Multiply(color, 1 / number);
            }
            /// <summary>
            /// Adds <paramref name="number"/> to all <paramref name="color"/>'s values. (except opecity)
            /// </summary>
            /// <param name="color"></param>
            /// <param name="number"></param>
            /// <returns></returns>
            private Color Add(Color color, int number)
            {
                int[] colors = new int[] { color.R + number, color.G + number, color.B + number };
                for (int i = 0; i < 3; i++)
                {
                    if (colors[i] > 255)
                        colors[i] = 255;
                    if (colors[i] < 0)
                        colors[i] = 0;
                }
                return Color.FromArgb(color.A, colors[0], colors[1], colors[2]);
            }
            /// <summary>
            /// Subs <paramref name="number"/> from all <paramref name="color"/>'s values. (except opecity)
            /// </summary>
            /// <param name="color"></param>
            /// <param name="number"></param>
            /// <returns></returns>
            private Color Sub(Color color, int number)
            {
                return Add(color, 0 - number);
            }
            #endregion

            
            //public WriteableBitmap ToWriteableBitmap()
            //{
            //    WriteableBitmap bitmap = new WriteableBitmap(Width, Height, 1, 1, PixelFormats.Bgra32, BitmapPalettes.Halftone256Transparent);
            //    Int32Rect rect = new Int32Rect(0, 0, Width, Height);
            //    bitmap.WritePixels(rect, Canvas, Width * 4, 0);
            //    return bitmap;
            //}

            /// <summary>
            /// Converts this <see cref="GenericImage"/> to <see cref="Bitmap"/> format.
            /// </summary>
            /// <returns></returns>
            public unsafe Bitmap ToBitmap()
            {
                int w = Width, h = Height;
                Bitmap img = new Bitmap(w, h);
                var data = img.LockBits(new Rectangle(0, 0, w, h), System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                int* ip = (int*)data.Scan0.ToPointer();
                uint* p = (uint*)ip;
                int index = 0;
                for (int i = 0; i < h; i++)
                {
                    for (int j = 0; j < w; j++)
                    {
                        p[index++] = Canvas[j, i];
                    }
                }
                img.UnlockBits(data);
                var test = img.GetPixel(0, 0);
                return img;
            }
            /// <summary>
            /// Creates a <see cref="GenericImage"/> from <paramref name="image"/>.
            /// </summary>
            /// <param name="image">The image that should be converted to <see cref="GenericImage"/>'s format.</param>
            /// <returns></returns>
            public static GenericImage From(System.Drawing.Image image)
            {
                GenericImage im = new GenericImage(image.Width, image.Height);
                Bitmap b = (Bitmap)image;
                int w = im.Width, h = im.Height;
                for (int i = 0; i < w; i++)
                    for (int j = 0; j < h; j++)
                        im.SetPixel(b.GetPixel(i, j), i, j);

                return im;
            }
            #region Equalities
            public override bool Equals(object obj)
            {
                if (obj is GenericImage)
                    return this.Equals((GenericImage)obj);
                return base.Equals(obj);
            }
            private bool Equals(GenericImage img)
            {
                for (int i = 0; i < Canvas.GetLength(0); i++)
                    for (int j = 0; j < Canvas.GetLength(1); j++)
                        if (img.Canvas[i, j] != Canvas[i, j])
                            return false;
                return true;
            }
            /// <summary>
            /// Checks if the two images are considered equal
            /// </summary>
            /// <param name="left"></param>
            /// <param name="right"></param>
            /// <returns></returns>
            public static bool operator ==(GenericImage left, GenericImage right)
            {
                return left.Equals(right);
            }
            /// <summary>
            /// Check whether the two images are'nt considered equal
            /// </summary>
            /// <param name="left"></param>
            /// <param name="right"></param>
            /// <returns></returns>
            public static bool operator !=(GenericImage left, GenericImage right)
            {
                return !left.Equals(right);
            }
            public static bool IsNull(GenericImage image)
            {
                return image is null;
            }
            #endregion

            public object Clone()
            {
                var can = (uint[,])Canvas.Clone();
                return new GenericImage(can);
            }
            public override string ToString()
            {
                return "32 bit image: " + Width + "*" + Height;
            }
            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            #region IStoreable
            public SingleLineString ToStringFile()
            {
                string r = $"{(int)SaveMethod}<{Width}<{Height}<";
                if (SaveMethod == ImageSaveMethod.Linked)
                {
                    Bitmap b = this.ToBitmap();
                    b.Save(this.LinkedFileURL,this.LinkedSaveFormat);
                    return r + LinkedFileURL+"|";
                }
                StringBuilder builder = new StringBuilder(r);
                foreach (var item in Canvas)
                {
                    builder.Append($"{item}|");
                }
                return builder.ToString();
            }

            /// <summary>
            /// Gets the image from the <paramref name="URL"/> specified.
            /// </summary>
            /// <param name="URL">The URL of the image.</param>
            /// <returns>resturns the image if the url found and the file was in the correct format, returns null otherwise.</returns>
            public GenericImage FromImageSaveMethodLinked(SingleLineString URL)
            {
                string c = (string)URL;
                var arr = c.Split("|");
                Image b;
                try
                {
                    b = Bitmap.FromFile(arr[0]);
                }
                catch (System.IO.FileNotFoundException)
                {
                    return null;
                }
                return GenericImage.From(b);
            }
            public IStoreable FromStringFile(SingleLineString content)
            {
                string c = (string)content;
                var arr=c.Split("<");
                var method = (ImageSaveMethod)int.Parse(arr[0]);
                if (method == ImageSaveMethod.Linked)
                    return FromImageSaveMethodLinked(arr[3]);

                var width = int.Parse(arr[1]);
                var height = int.Parse(arr[2]);
                var con = arr[3].Split("|");
                GenericImage r = new GenericImage(width, height);
                int index = 0;
                for (int i = 0; i < r.Width; i++)
                {
                    for (int j = 0; j < r.Height; j++)
                    {
                        unchecked
                        {
                            r[i, j] = Color.FromArgb((int)uint.Parse(con[index++]));
                        }
                    }
                }
                return r;
            }
            #endregion
        }
    }
}
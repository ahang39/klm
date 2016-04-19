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
using System.Windows.Shapes;
using System.IO;

namespace klm
{
    public partial class image_edit : Window
    {
        public image_edit()
        {
            InitializeComponent();
            try
            {
                klm_data d = new klm_data();
                var imageStreamSource = File.OpenRead(@d.get_im_src());
                var decoder = BitmapDecoder.Create(imageStreamSource, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
                var bitmapFrame = decoder.Frames[0];

                //CroppedBitmap transformed = new CroppedBitmap(bitmapFrame, new Int32Rect(100, 0, (int)bitmapFrame.Width - 100, (int)bitmapFrame.Height));
                double map_hi = bitmapFrame.Height;
                double map_wi = bitmapFrame.Width;
                string t = "图片尺寸：" + (int)map_hi + " X " + (int)map_wi;
                im_text.Text = t;
                im.Source = bitmapFrame;
                tr_im.Source = work();
            }
            catch (System.NotSupportedException)
            {
                MessageBox.Show("不支持的文件格式");
                this.Close();
            }
            catch (System.ArgumentException)
            {
                MessageBox.Show("文件路径错误");
                this.Close();
            }
            //loc.Maximum = bigger(bitmapFrame.Height, bitmapFrame.Width)*0.68;
            loc.Maximum = 60;
        }
        private double bigger(double n1, double n2)
        {
            if (n1 > n2)
                return n1;
            else
                return n2;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            save_im();
            this.Close();
        }
        private CroppedBitmap work()
        {
            klm_data d = new klm_data();
            try
            {
                var imageStreamSource = File.OpenRead(@d.get_im_src());
                var decoder = BitmapDecoder.Create(imageStreamSource, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
                var bitmapFrame = decoder.Frames[0];
                double re_map_hi = bitmapFrame.Height;
                double re_map_wi = bitmapFrame.Width;
                CroppedBitmap transformed;
                //var encoder = new JpegBitmapEncoder();
                if (re_map_hi > re_map_wi)
                {
                    sc.Maximum = 10;
                    int devide = (int)sc.Value;
                    //int resi = (int)(re_map_wi * sc.Value);
                    try
                    {
                        transformed = new CroppedBitmap(bitmapFrame, new Int32Rect((int)loc.Value, (int)loc_y.Value, (int)(bitmapFrame.PixelWidth / sc.Value), (int)(bitmapFrame.PixelWidth / sc.Value)));
                        loc_y.Maximum = (int)bitmapFrame.PixelHeight - (int)(bitmapFrame.PixelWidth / sc.Value);
                        loc.Maximum = (int)bitmapFrame.PixelWidth - (int)(bitmapFrame.PixelWidth / sc.Value);
                        return transformed;
                    }
                    catch
                    {
                        return null;
                    }
                }
                else
                {
                    sc.Maximum = 10;
                    int devide = (int)sc.Value;
                    try
                    {
                        transformed = new CroppedBitmap(bitmapFrame, new Int32Rect((int)loc.Value, (int)loc_y.Value, (int)(bitmapFrame.PixelHeight / sc.Value), (int)(bitmapFrame.PixelHeight / sc.Value)));
                        loc.Maximum = (int)bitmapFrame.PixelWidth - (int)(bitmapFrame.PixelHeight / sc.Value);
                        loc_y.Maximum = (int)bitmapFrame.PixelHeight - (int)(bitmapFrame.PixelHeight / sc.Value);
                        return transformed;
                    }
                    catch
                    {
                        return null;
                    }
                }
            }
            catch (System.NotSupportedException)
            {
                MessageBox.Show("不支持的文件格式");
                this.Close();
                return null;
            }
            catch (System.ArgumentException)
            {
                MessageBox.Show("文件路径错误");
                this.Close();
                return null;
            }
        }
        private void save_im()
        {
            var encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(work()));
            FileStream newFile = File.Create("D:/ahang/Documents/Visual Studio 2013/Projects/klm/klm/Image/temp/tempcut.jpg");
            encoder.Save(newFile);
            newFile.Dispose();
        }
        private void sc_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            tr_im.Source = work();
        }
        private void loc_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            tr_im.Source = work();
        }
        private void loc_y_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            tr_im.Source = work();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

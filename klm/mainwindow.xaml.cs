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
using System.Windows.Media.Animation;
using System.Windows.Threading;
using System.Drawing;
using System.IO;
using System.Data;
using System.Collections;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Threading;

namespace klm
{
    public partial class MainWindow : Window
    {
        #region 连接MYSQL
        public MySqlConnection getmysqlcon()
        {
            string mysql_conn = "server=localhost;user id=DiaoBL;password=DBA;database=klm;Charset=utf8";
            MySqlConnection myCon = new MySqlConnection(mysql_conn);
            return myCon;
        }
        public void getmysqlcom(string mysql_conn)
        {
            MySqlConnection mysqlcon = this.getmysqlcon();
            mysqlcon.Open();
            MySqlCommand mysqlcom = new MySqlCommand(mysql_conn, mysqlcon);
            mysqlcom.ExecuteNonQuery();
            mysqlcom.Dispose();
            mysqlcon.Close();
            mysqlcon.Dispose();
        }
        public MySqlDataReader getmysqlread(string M_str_sqlstr)
        {
            MySqlConnection mysqlcon = this.getmysqlcon();
            MySqlCommand mysqlcom = new MySqlCommand(M_str_sqlstr, mysqlcon);
            mysqlcon.Open();
            MySqlDataReader mysqlread = mysqlcom.ExecuteReader(CommandBehavior.CloseConnection);
            return mysqlread;
        }
        public int mysqlwrite(string M_str_sqlstr)
        {
            MySqlConnection mysqlcon = this.getmysqlcon();
            MySqlCommand mysqlcom = new MySqlCommand(M_str_sqlstr, mysqlcon);
            mysqlcon.Open();
            int mysqlwrite = mysqlcom.ExecuteNonQuery();
            return mysqlwrite;
        }
        #endregion
        private bool _Expand = true;
        private void Grid_grow()
        {
            int to_width = 220;
            double change_time = 0.25;
            if (_Expand)
            {
                DoubleAnimation width_an = new DoubleAnimation();
                width_an.From = g1.ActualWidth;
                width_an.To = to_width;
                width_an.Duration = TimeSpan.FromSeconds(change_time);
                g1.BeginAnimation(Grid.WidthProperty, width_an);
            }
            else
            {
                DoubleAnimation width_an = new DoubleAnimation();
                width_an.From = g1.ActualWidth;
                width_an.To = 5;
                width_an.Duration = TimeSpan.FromSeconds(change_time);
                g1.BeginAnimation(Grid.WidthProperty, width_an);
            }
        }
        public MainWindow()
        {
            welcome new_dlg = new welcome();
            new_dlg.ShowDialog();
            InitializeComponent();
        }
        private string GetImagePath(string filename, String option = "menu")
        {

            string path = "D:/ahang/Documents/Visual Studio 2013/Projects/klm/klm/Image/" + option + "/" + filename + ".jpg";
            return path;
        }
        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            _Expand = true;

            Grid_grow();
        }
        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            _Expand = false;

            Grid_grow();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("真的要退出“渴了吗”吗？", "真的吗? ：）", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                App.Current.Shutdown();
            }
            else
            {
                // Do not close the window
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog =
                new Microsoft.Win32.OpenFileDialog();
            dialog.ShowDialog();
            te.Text = dialog.FileName;
            klm_data d = new klm_data();
            d.set_im_src(dialog.FileName);
            //image_edit ie = new image_edit();
            //ie.ShowDialog();
            try
            {
                klm_data data = new klm_data();
                var imageStreamSource = File.OpenRead(@data.get_im_src());
                var decoder = BitmapDecoder.Create(imageStreamSource, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
                try
                {
                    image_edit ie = new image_edit();
                    ie.ShowDialog();
                }
                catch { }
            }
            catch (System.NotSupportedException)
            {
                MessageBox.Show("不支持的文件格式");
                te.Clear();
            }
            catch (System.ArgumentException)
            {
                MessageBox.Show("文件路径错误");
                te.Clear();
            }
        }
        private void menu1_Loaded(object sender, RoutedEventArgs e)
        {
            menuRefresh();
        }
        private void menuRefresh()
        {
            menu1.Items.Clear();
            menu2.Items.Clear();
            string sql = "select name,price from menu";
            MySqlDataReader get_menu = getmysqlread(sql);
            while (get_menu.Read())
            {
                try
                {
                    menulist temp = new menulist();
                    temp.name.Content = get_menu["name"];
                    temp.price.Content = get_menu["price"];
                    temp.counters.plus.Click += new RoutedEventHandler(this.menu_Changed);
                    temp.counters.minus.Click += new RoutedEventHandler(this.menu_Changed);
                    this.menu1.Items.Add(temp);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            total.Content = "0.0";
        }
        private void menu_Changed(object sender, RoutedEventArgs e)
        {
            try
            {
                for (int i = 0; i < menu1.Items.Count; i++)
                {
                    menulist ml = menu1.Items[i] as menulist;
                    StackPanel sp = ml.FindName("sp") as StackPanel;
                    Label nametext = sp.Children[0] as Label;
                    Label price = sp.Children[1] as Label;
                    counters cter = sp.Children[2] as counters;
                    TextBlock num = cter.FindName("num") as TextBlock;
                    int num_temp = -1;
                    int.TryParse(num.Text, out num_temp);
                    bool isInclude = false;
                    for (int j = 0; j < menu2.Items.Count; j++)
                    {
                        menulist ml_2 = menu2.Items[j] as menulist;
                        StackPanel sp_2 = ml_2.FindName("sp") as StackPanel;
                        Label nametext_2 = sp_2.Children[0] as Label;
                        if (nametext.Content == nametext_2.Content)
                            isInclude = true;
                        if (ml.name.Content.ToString() == ml_2.name.Content.ToString())
                        {
                            if (num_temp == 0)
                            {
                                image.Source = new BitmapImage(new Uri(GetImagePath(nametext.Content.ToString()), UriKind.RelativeOrAbsolute));
                                if (isInclude)
                                    this.menu2.Items.Remove(menu2.Items[j]);
                            }
                            else
                            {
                                if (isInclude)
                                {
                                    if (ml_2.counters.num.Text != ml.counters.num.Text)
                                        image.Source = new BitmapImage(new Uri(GetImagePath(nametext.Content.ToString()), UriKind.RelativeOrAbsolute));
                                    ml_2.counters.num.Text = num_temp.ToString();
                                }
                            }
                        }
                    }
                    if (!isInclude && num_temp != 0)
                    {
                        try
                        {
                            image.Source = new BitmapImage(new Uri(GetImagePath(nametext.Content.ToString()), UriKind.RelativeOrAbsolute));
                        }
                        catch
                        {
                            MessageBox.Show("气死本宝宝了");
                        }
                        menulist temp = new menulist();
                        temp.name.Content = nametext.Content;
                        temp.price.Content = price.Content;
                        TextBlock tempnum = temp.counters.FindName("num") as TextBlock;
                        tempnum.Text = num.Text;
                        temp.counters.plus.Visibility = Visibility.Hidden;
                        temp.counters.minus.Visibility = Visibility.Hidden;
                        this.menu2.Items.Add(temp);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            double sum = 0;
            for (int i = 0; i < menu2.Items.Count; i++)
            {
                menulist ml_2 = menu2.Items[i] as menulist;
                StackPanel sp_2 = ml_2.sp;
                TextBlock tempnum = ml_2.counters.num;
                Label nametext_2 = sp_2.Children[0] as Label;
                int tempdish;
                double tempprice;
                int.TryParse(tempnum.Text, out tempdish);
                double.TryParse(ml_2.price.Content.ToString(), out tempprice);
                sum += tempprice * tempdish;
            }
            total.Content = sum.ToString();

        }
        private void menu1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                menulist ml = menu1.SelectedItems[0] as menulist;
                StackPanel sp = ml.FindName("sp") as StackPanel;
                Label nametext = sp.Children[0] as Label;
                image.Source = new BitmapImage(new Uri(GetImagePath(nametext.Content.ToString()), UriKind.RelativeOrAbsolute));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void menu2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                menulist ml = menu2.SelectedItems[0] as menulist;
                StackPanel sp = ml.FindName("sp") as StackPanel;
                Label nametext = sp.Children[0] as Label;
                image.Source = new BitmapImage(new Uri(GetImagePath(nametext.Content.ToString()), UriKind.RelativeOrAbsolute));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void te_GotFocus(object sender, RoutedEventArgs e)
        {
            if (te.Text == "输入图片地址")
                te.Text = "";
        }
        private void upgrade_Click(object sender, RoutedEventArgs e)
        {
            double check;
            if (double.TryParse(priceInput.Text, out check))
            {
                if (nameInput.Text != "")
                {
                    string sql = "select * from menu where name ='" + nameInput.Text + "'";
                    MySqlDataReader get_name = getmysqlread(sql);
                    if (get_name.Read())
                    {
                        MessageBox.Show("已存在该条记录");
                    }
                    else
                    {
                        string tempPath = GetImagePath("tempcut", "temp");
                        System.Drawing.Image pic = System.Drawing.Image.FromFile(tempPath);
                        System.Drawing.Image bmp = new System.Drawing.Bitmap(pic);
                        if (pic.Height == pic.Width)
                        {
                            try
                            {
                                sql = "insert into menu (name,price) values ('"
                                + nameInput.Text + "'," + priceInput.Text + ")";
                                mysqlwrite(sql);
                                pic.Save(GetImagePath(nameInput.Text));
                                MessageBox.Show("添加成功!");
                                menuRefresh();
                            }
                            catch
                            {
                                MessageBox.Show("失败!");
                            }


                        }
                    }
                    nameInput.Clear();
                    priceInput.Clear();
                }
                else
                {
                    MessageBox.Show("名称不能为空,请重新输入!");
                }
            }
            else
            {
                MessageBox.Show("价格输入错误,请重新输入!");
                priceInput.Text = "";
            }
        }
        private void submit_Click(object sender, RoutedEventArgs e)
        {
            orderInfo.Items.Clear();
            guestName.IsReadOnly = false;
            address.IsReadOnly = false;
            if (menu2.Items.Count == 0)
            {
                MessageBox.Show("你啥都不点,我给你吃啥呀");
                return;
            }
            for (int i = 0; i < menu2.Items.Count; i++)
            {
                menulist ml = menu2.Items[i] as menulist;
                StackPanel sp = ml.FindName("sp") as StackPanel;
                Label nametext = sp.Children[0] as Label;
                Label price = sp.Children[1] as Label;
                counters cter = sp.Children[2] as counters;
                TextBlock num = cter.FindName("num") as TextBlock;
                menulist temp = new menulist();
                temp.name.Content = nametext.Content;
                temp.price.Content = price.Content;
                TextBlock tempnum = temp.counters.FindName("num") as TextBlock;
                tempnum.Text = num.Text;
                temp.counters.plus.Visibility = Visibility.Hidden;
                temp.counters.minus.Visibility = Visibility.Hidden;
                this.orderInfo.Items.Add(temp);
            }
            tab.SelectedItem = tab3;
            confirmOrder.Visibility = Visibility.Visible;
        }
        private void orderList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            orderInfo.Items.Clear();
            if(confirmOrder.Visibility==Visibility.Visible)
            {
                MessageBox.Show("请先完成订单创建!");
                return;
            }
            if (orderList.SelectedItems.Count==0)
                return;
            orders temp=orderList.SelectedItems[0] as orders;
            string sql = "select * from orders where time='" + temp.time.Text + "'";
            MySqlDataReader get_orders = getmysqlread(sql);
            get_orders.Read();
            guestName.Text = get_orders["NAME"].ToString();
            address.Text = get_orders["address"].ToString() ;
            Program prog = new Program();
            prog.createOrder(get_orders["orders"].ToString(), orderInfo);
            if (get_orders["isEatHere"].ToString() == "1")
            {
                eatHere_order.IsChecked = true;
            }
            else
            {
                takeAway_order.IsChecked = true;
            }
        }
        private void orderListRefresh()
        {
            this.orderList.Items.Clear();
            string sql = "select name,isEatHere,price,time from orders where isFinished='0' order by time desc";
            MySqlDataReader get_order = getmysqlread(sql);
            while (get_order.Read())
            {
                orders temp = new orders();
                temp.name.Text = get_order["name"].ToString();
                if (get_order["isEatHere"].ToString() == "1")
                    temp.option.Text = "堂吃";
                else
                    temp.option.Text = "外卖";
                temp.price.Text = "￥ "+get_order["price"].ToString();
                DateTime dt = (DateTime)get_order["time"];
                temp.time.Text = dt.Year.ToString() + "/" + dt.ToString();
                this.orderList.Items.Add(temp);
            }
        }
        private void orderList_Loaded(object sender, RoutedEventArgs e)
        {
            orderListRefresh();
        }
        private void eatHere_order_Checked(object sender, RoutedEventArgs e)
        {
            optionLabel.Content = "桌号";
        }
        private void takeAway_order_Checked(object sender, RoutedEventArgs e)
        {
            optionLabel.Content = "配送地址";
        }
        private void cancelOrder_Click(object sender, RoutedEventArgs e)
        {
            
            if (confirmOrder.Visibility == Visibility.Hidden)
            {
                try
                {
                    orders temp = orderList.SelectedItems[0] as orders;
                    string sql = "delete from orders where time='" + temp.time.Text + "'";
                    mysqlwrite(sql);

                }
                catch { }
                    guestName.Clear();
                    address.Clear();
                    orderInfo.Items.Clear();
                    orderListRefresh();
            }
            else
            {
                guestName.Clear();
                address.Clear();
                orderInfo.Items.Clear();
                tab.SelectedItem = tab1;
                confirmOrder.Visibility = Visibility.Hidden;
                guestName.IsReadOnly = true;
                address.IsReadOnly = true;
            }
            menuRefresh();
        }
        private void confirmOrder_Click(object sender, RoutedEventArgs e)
        {
            if (guestName.Text != "" && address.Text != "")
            {
                DateTime now = DateTime.Now;
                string time = now.Year.ToString() + "-"
                    + now.Month.ToString() + "-"
                    + now.Day.ToString()
                    + " " + now.Hour.ToString()
                    + ":" + now.Minute.ToString()
                    + ":" + now.Second.ToString();
                string iseathere;
                if ((bool)eatHere_order.IsChecked)
                    iseathere = "1";
                else
                    iseathere = "0";
                string orderString = "";
                for (int i = 0; i < menu2.Items.Count; i++)
                {
                    menulist ml = menu2.Items[i] as menulist;
                    StackPanel sp = ml.FindName("sp") as StackPanel;
                    Label nametext = sp.Children[0] as Label;
                    Label price = sp.Children[1] as Label;
                    counters cter = sp.Children[2] as counters;
                    TextBlock num = cter.FindName("num") as TextBlock;
                    order tempOrder = new order(nametext.Content.ToString(), num.Text);
                    orderString += tempOrder.getOrderString();
                }
                string sql = "insert into orders (name,address,orders,price,time,isEatHere) values ('"
                                + guestName.Text
                                + "','" + address.Text
                                + "','" + orderString
                                + "','" + total.Content.ToString()
                                + "','" + time
                                + "','" + iseathere + "')";
                mysqlwrite(sql);
                MessageBox.Show("提交成功!");
                guestName.IsReadOnly = true;
                address.IsReadOnly = true;
                orderListRefresh();
                guestName.Clear();
                address.Clear();
                orderInfo.Items.Clear();
                confirmOrder.Visibility = Visibility.Hidden;
            }
            else
            {
                MessageBox.Show("输入错误");
            }
            menuRefresh();
        }
        private void finishOrder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                orders oder = orderList.SelectedItems[0] as orders;
                string sql = "update orders set isFinished='1' where time='" + oder.time.Text + "'";
                mysqlwrite(sql);
                orderListRefresh();
                guestName.Clear();
                address.Clear();
                orderInfo.Items.Clear();
            }
            catch { }
            menuRefresh();
        }
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            drawPloy();
            showTime.Content ="日期 " + DateTime.Today.Year + "-" + DateTime.Today.Month + "-" + DateTime.Today.Day;
        }
        private double maxProfit = 0.01;
        private class profit
        {
            public profit(double _v)
            {
                value = _v;
            }
            public double value;
        }
        private PointCollection getPointCollection(ArrayList profitList)
        {
            PointCollection re = new PointCollection();
            int x = 0;

            for (int i = 0; i < profitList.Count; i++)
            {
                if ((profitList[i] as profit).value > maxProfit)
                {
                    maxProfit = (profitList[i] as profit).value;
                }
            }
            for (int i = 0; i < profitList.Count; i++)
            {
                double y = (profitList[i] as profit).value;
                re.Add(new System.Windows.Point(x, 530 - y * 530 / maxProfit));
                x += 20;
            }
            return re;
        }
        private void drawPloy()
        {
            ploy.Points = getPointCollection(getProfitList());
            profitMax.Content = (int)maxProfit;
            halfProfitMax.Content = (int)(maxProfit / 2);

        }
        private ArrayList getProfitList()
        {
            ArrayList profitList = new ArrayList();
            int Day = 1;
            double sum = 0;
            while (DateTime.Today.Day >= Day)
            {
                string sql;
                if(Day<10)
                    sql = "select sum(price) from orders where time like '" + DateTime.Today.Year + "-" + DateTime.Today.Month + "-0" + Day + "%' order by time";
                else
                    sql ="select sum(price) from orders where time like '" + DateTime.Today.Year + "-" + DateTime.Today.Month + "-" + Day + "%' order by time";
                MySqlDataReader get_orders = getmysqlread(sql);
                if (get_orders.Read())
                {
                    double prof;
                    double.TryParse(get_orders[0].ToString(), out prof);
                    sum += prof;
                    profitList.Add(new profit(prof));
                    Day++;
                }
                else
                {
                    profitList.Add(new profit(0));
                }
            }
            while (profitList.Count < 31)
            {
                profitList.Add(new profit(0));
            }
            month_sum.Text = sum.ToString();
            return profitList;
        }
        private void changePrice_upgrade_Click(object sender, RoutedEventArgs e)
        {
            double price;
            if (double.TryParse(ChangePrice_price.Text, out price))
            {
                    string sql = "update menu set price =" + price + " where name ='" + changeprice_dishInfo.SelectedItem.ToString() + "'";
                            try
                            {
                                mysqlwrite(sql);
                                MessageBox.Show("修改成功!");
                            }
                            catch
                            {
                                MessageBox.Show("修改失败!");
                            }
                    ChangePrice_price.Clear();
                      
            }
            else
            {
                MessageBox.Show("价格输入错误,请重新输入!");
                priceInput.Text = "";
            }
            changeprice_dishInfo.Items.Clear();
            deleteDish_dishInfo.Items.Clear();

            changePriceRefresh();
            deleteDishRefresh();
            menuRefresh(); 
        }
        private void changePriceRefresh()
        {
            string sql = "select name from menu";
            MySqlDataReader get_dishName = getmysqlread(sql);
            while (get_dishName.Read())
            {
                try
                {
                    this.changeprice_dishInfo.Items.Add(get_dishName["name"]);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        private void changeprice_dishInfo_Loaded(object sender, RoutedEventArgs e)
        {
            changePriceRefresh();
        }
        private void deleteDishRefresh()
        {
            string sql = "select name from menu";
            MySqlDataReader get_dishName = getmysqlread(sql);
            while (get_dishName.Read())
            {
                try
                {

                    this.deleteDish_dishInfo.Items.Add(get_dishName["name"]);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        private void deleteDish_dishInfo_Loaded(object sender, RoutedEventArgs e)
        {
            deleteDishRefresh();
        }
        private void DeleteDish_upgrade_Click(object sender, RoutedEventArgs e)
        {
                string sql = "delete from menu where name ='"  +  deleteDish_dishInfo.SelectedItem.ToString() + "'"; 
                try
                {
                    mysqlwrite(sql);
                    MessageBox.Show("删除成功!");
                }
                catch
                {
                    MessageBox.Show("删除失败!");
                }
                changePriceRefresh();
                deleteDishRefresh();
                menuRefresh(); 
        }
        private void tab_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

    }
    public class klm_data
    {
        public klm_data() { }
        public static string im_src = "C:\bg.jpg";
        public string get_im_src()
        {
            return im_src;
        }
        public void set_im_src(string input)
        {
            im_src = input;
        }
    }
    class order
    {
        private string dish;
        private string num;
        public order(string d, string n)
        {
            dish = d;
            num = n;
        }
        private void chDish(string d)
        {
            dish = d;
        }
        private void chNum(string n)
        {
            num = n;
        }
        public string getDish()
        {
            return dish;
        }
        public string getNum()
        {
            return num;
        }
        public string getOrderString()
        {
            return "|" + dish + "," + num + "|";
        }
    }
    class Program
    {
        public ArrayList orders = new ArrayList();
        public void createOrder(string input,ListBox orderInfo)
        {
            int state = 0;
            int sStart = 0;
            int sEnd = 0;
            string dish = "";
            string num = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (state == 0)
                {
                    if (input[i] != '|')
                    {
                        continue;
                    }
                    sStart = i + 1;
                    state = 1;
                }
                if (state == 1)
                {
                    if (input[i] != ',')
                    {
                        continue;
                    }
                    sEnd = i - 1;
                    state = 2;
                    dish = input.Substring(sStart, sEnd - sStart + 1);
                    sStart = i + 1;
                }
                if (state == 2)
                {
                    if (input[i] != '|')
                    {
                        continue;
                    }
                    sEnd = i - 1;
                    num = input.Substring(sStart, sEnd - sStart + 1);
                    state = 0;
                    order tmp = new order(dish, num);
                    orders.Add(tmp);
                }

            }
            for (int i = 0; i < orders.Count; i++)
            {
                order tmp = orders[i] as order;
                menulist temp = new menulist();
                temp.name.Content = tmp.getDish();
                temp.price.Content = "";
                TextBlock tempnum = temp.counters.FindName("num") as TextBlock;
                tempnum.Text = tmp.getNum();
                temp.counters.plus.Visibility = Visibility.Hidden;
                temp.counters.minus.Visibility = Visibility.Hidden;
                orderInfo.Items.Add(temp);
            }
        }

    }
}

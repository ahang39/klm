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
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace klm
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class login : Window
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
        public login()
        {
            InitializeComponent();
        }
        private void lo_but_Click(object sender, RoutedEventArgs e)
        {
            string sql = "select * from user where uname ='" + name.Text + "'";
            MySqlDataReader get_user = getmysqlread(sql);
            if (get_user.Read())
            {
                string password = (string)get_user["password"];
                if (password == pwd.Password)
                {
                    DateTime lasttime = (DateTime)get_user["lasttime"];
                    MessageBox.Show("登陆成功,上次登陆时间为: " + lasttime.ToString());
                    DateTime now = DateTime.Now;
                    string time = now.Year.ToString() + "-" 
                        + now.Month.ToString() + "-" 
                        + now.Day.ToString() 
                        + " " + now.Hour.ToString() 
                        + ":" + now.Minute.ToString() 
                        + ":" + now.Second.ToString();
                    sql = "update user set lasttime='" + time + "'where uname='" + name.Text + "'";
                    mysqlwrite(sql);
                    this.Hide();
                }
                else
                    MessageBox.Show("密码错误!");
            }
            else
                MessageBox.Show("用户不存在!");
        }
        private void exit_but_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("真的要退出“渴了吗”吗？",
  "真的吗? ：）", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                this.Close();
                App.Current.Shutdown();
            }
            else
            {
                // Do not close the window
            }
        }
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        private void regi_but_Click(object sender, RoutedEventArgs e)
        {
            register re = new register();
            re.ShowDialog();
        }
        private void name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return")
                lo_but.Focus();
        }
        private void pwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return")
                lo_but.Focus();
        }
    }
}

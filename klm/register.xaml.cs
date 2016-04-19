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
    public partial class register : Window
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

        public register()
        {
            InitializeComponent();
        }
        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void submit_Click(object sender, RoutedEventArgs e)
        {
            if (password.Password != rePassword.Password)
            {
                MessageBox.Show("两次密码不相同,请重新输入");
                return;
            }
            string sql = "insert into user (uname,password) values ('" + userName.Text + "','" + password.Password + "')";
            mysqlwrite(sql);
            this.Close();
        }

    }
     
}

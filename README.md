# dotnet-core
# <a href="https://github.com/52abp">.net core 学习网站52abp github</a>
# <a href="https://www.jianshu.com/p/774287dcdd4e">解决vs2017/vs2019运行时老是出现脚本错误的方法</a>
# <a href="https://github.com/kennycaiguo/dotnet-core/blob/master/SqlUtils.cs">自己封装的sql server工具类</a>
# <a href="https://github.com/kennycaiguo/asp.net/blob/master/%E5%B0%86%E6%95%B0%E6%8D%AE%E5%BA%93%E7%9A%84%E8%A1%A8%E7%9A%84%E5%86%85%E5%AE%B9%E5%8A%A8%E6%80%81%E6%B7%BB%E5%8A%A0%E5%88%B0treeview%E6%8E%A7%E4%BB%B6%E4%B8%AD.txt">将数据库的表的内容动态添加到treeview控件中</a>
# dotnet Core 操作SQL server数据库
1.创建一个 .net core 控制台应用程序
2.添加“System.Data.SqlClient"
具体方法：（1）visual studion ：点击-工具-nuget包管理工具-程序包管理控制台
在下面的命令提示符中输入如下
ps f:\>Install-Package "System.Data.SqlClient" 回车
         （2）vs code：打开terminal窗口，输入dotnet add package "System.Data.SqlClient" 回车
         
3.以操作SQL server数据库中的Workers表为例：
具体代码：
using System;
using System.Data.SqlClient;
using System.Data;



namespace dotnetCore_op_SQLServer
{
    class Program
    {
        static void Main(string[] args)
        {
            string connStr = "server=.;database=kennyDb;uid=kenny;password=kenny1975";
            SqlConnection conn = new SqlConnection(connStr);
            SqlDataAdapter adapter = new SqlDataAdapter("select * from Workers", conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            foreach (DataRow r in dt.Rows)
            {

              Console.WriteLine($"{r["name"]} : {r["age"]} : {r["sal"]}");
            }
            conn.Close();
            Console.ReadKey();
        }
    }
}


# dotnet core 操作Oracle数据库(vs code 开发环境)
1.创建一个solution，（ctrl+shift+p）
2.右击公关创建的solution，选择add project，输入project名称，按两次回车
3.在terminal中输入cd \project名称，回车,进入project目录
4.输入dotnet add package "Oracle.ManagedDataAccess.core" 安装Oracle ManagedAccess支持
5.完成后再main函数中加入如下代码
using System;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
 

namespace NetcoreOracleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //string ConnectString = "WIN-RCFFIK7IK3D/ORCL;User ID=scott;PassWord=tiger";
            string connstr=@"Data Source=(DESCRIPTION=
                                      (ADDRESS= (PROTOCOL=TCP) (HOST = WIN-RCFFIK7IK3D)(PORT = 1521))
                                           (CONNECT_DATA=
                                                (SERVER = DEDICATED)
                                                (SID=orcl)
                                             )
                                       );Persist Security Info=True;User Id=scott;Password=tiger;";
            OracleConnection conn=new OracleConnection(connstr);
            string sql="select count(1) from emp";
            OracleCommand cmd=new OracleCommand(sql,conn);
            conn.Open();
            Console.WriteLine(cmd.ExecuteScalar());
            conn.Close();
            Console.ReadKey();
        }
    }
}

# .net core学习
<a href="https://github.com/kennycaiguo/Bing.NetCore">Bing.NetCore</a><br/>
<a href="https://github.com/kennycaiguo/Vue.NetCore">Vue.NetCore</a><br/>
<a href="https://github.com/kennycaiguo/Zxw.Framework.NetCore">Zxw.Framework.NetCore</a><br/>
<a href="https://github.com/kennycaiguo/FluentEmail">FluentEmail</a><br/>
<a href="https://github.com/kennycaiguo/BlogVue">BlogVue</a><br/>
<a href="https://github.com/kennycaiguo/Blog.Vue">Blog.Vue</a><br/>
<a href="https://github.com/kennycaiguo/.NetCoreGuide">.NetCoreGuide</a><br/>
<a href="https://github.com/kennycaiguo/Miniblog.Core">Miniblog.Core</a><br/>
<a href="https://github.com/kennycaiguo/awesome-dotnet-core">awesome-dotnet-core</a><br/>
<a href="https://github.com/kennycaiguo/aspnetcore">aspnetcore</a><br/>
<a href="https://github.com/kennycaiguo/AspNetCore.Docs">AspNetCore.Docs</a><br/>
<a href="https://github.com/kennycaiguo/ASP.NET-Core-Web-API-Best-Practices-Guide">ASP.NET-Core-Web-API-Best-Practices-Guide</a><br/>
<a href="https://github.com/kennycaiguo/GuidGenerate-.NET-Core-">GuidGenerate-.NET-Core-</a><br/>
<a href="https://github.com/kennycaiguo/RabbitMQ">RabbitMQ 官方.NET CORE教程实操演练</a><br/>
<a href="https://github.com/kennycaiguo/Czar.Cms"></a><br/>
<a href="https://github.com/kennycaiguo/Czar.Cms">.NET Core实战项目之CMS系列教程的源码</a><br/>
<a href="https://github.com/kennycaiguo/asp.net-core-tutorial">ASP.NET Core 入门教程</a><br/>
<a href="https://github.com/kennycaiguo/.net-core-mvc-intermediate">.net core MVC 中级教程</a><br/>
<a href="https://github.com/kennycaiguo/.net-Core-MVC-">博客.net Core MVC初级教程的代码，教程几对应博客教程</a><br/>
<a href="https://github.com/kennycaiguo/ASP.NET-Core-Beginner-TranScript">微软虚拟学院 ASP.NET Core 初级教程</a><br/>
<a href="https://github.com/kennycaiguo/JesseTalkDemos">腾飞ASP .NET Core视频教程的案例代码</a><br/>
<a href="https://github.com/kennycaiguo/ASP.NET-Core-2.1-Angular-6-Demo">中文视频教程 "ASP.NET Core 2.1 + Angular 6 + Identity Server 4 + Angular Material 小项目实战" 的配套代码</a><br/>
<a href="https://github.com/kennycaiguo/netCoreStart">ASP.NET Core MVC 和 Entity Framework Core 入门教程</a><br/>
<a href="https://github.com/kennycaiguo/asp-core-tutorial">ASP.NET Core 教程</a><br/>
<a href="https://github.com/kennycaiguo/dotnetcore-front-end-guide">using .NET Core with a living guide</a><br/>
<a href=""></a>
<a href=""></a>
<a href=""></a>
<a href=""></a>
<a href=""></a>


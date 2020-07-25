# dotnet-core

# <a href="https://cloud.tencent.com/developer/article/1118254">visual studio内置“iis”组件提取及二次开发</a>
# <a href="https://juejin.im/post/5ee346c9f265da771066ea51">C#AutoMapper 使用手册</a>
# <a href="https://github.com/52abp">.net core 学习网站52abp github</a>
# <a href="https://docs.microsoft.com/zh-cn/ef/core/providers/?tabs=dotnet-core-cli">ef core数据库提供程序</a>
# <a href="https://www.jianshu.com/p/774287dcdd4e">解决vs2017/vs2019运行时老是出现脚本错误的方法</a>
# <a href="https://github.com/kennycaiguo/dotnet-core/blob/master/SqlUtils.cs">自己封装的sql server工具类</a>
# <a href="https://github.com/kennycaiguo/asp.net/blob/master/%E4%BD%BF%E7%94%A8libMan%E5%AE%89%E8%A3%85bootstrap.docx">libMan安装bootstrap</a>
# <a href="https://github.com/kennycaiguo/asp.net/blob/master/%E5%B0%86%E6%95%B0%E6%8D%AE%E5%BA%93%E7%9A%84%E8%A1%A8%E7%9A%84%E5%86%85%E5%AE%B9%E5%8A%A8%E6%80%81%E6%B7%BB%E5%8A%A0%E5%88%B0treeview%E6%8E%A7%E4%BB%B6%E4%B8%AD.txt">将数据库的表的内容动态添加到treeview控件中</a>
# <a href="https://github.com/kennycaiguo/asp.net/blob/master/treeview%E6%8E%A7%E4%BB%B6%E8%8A%82%E7%82%B9%E5%8B%BE%E9%80%89%E5%A4%84%E7%90%86.txt">treeview控件节点勾选处理.仅仅供参考，要根据实际业务适当调整代码</a>
# <a href="https://github.com/kennycaiguo/asp.net/blob/master/vs%E5%88%9B%E5%BB%BA%E7%94%A8%E6%88%B7%E8%87%AA%E5%AE%9A%E4%B9%89%E6%8E%A7%E4%BB%B6.docx">vs创建用户自定义控件</a>
# nuget命令窗口执行迁移命令出错Upadate-Database : 无法将“Upadate-Database”项识别为 cmdlet、函数、脚本文件或可运行程序的名称。请检查名称的拼写，如果包括路径，请确保路径正确，然后再试一次。所在位置 行:1 字符: 1(因为没有安装工具集)的解决办法:
安装 Microsoft.EntityFrameworkCore.Tools，具体操作
PM >Install-Package Microsoft.EntityFrameworkCore.Tools
如果一切工作正常，你应该能够运行这样的命令：

Get-Help about_EntityFrameworkCore

显示一个类似一匹马的图案以及常用命令列表

# .Net Core 3.1 EF Core Migration使用CLI数据迁移和同步
    1、创建迁移文件，迁移文件名必填
dotnet ef migrations add 迁移文件名
    2、撤销迁移，只能在未更新数据库前撤销
dotnet ef migrations remove
    3、更新到数据库
dotnet ef database update
     4、删除数据库
    注意不是删除数据更改，是删除数据库，慎用。
dotnet ef database drop
 
## 问题与解决
    1、问题
无法执行，因为找不到指定的命令或文件。
可能的原因包括:
*你拼错了内置的 dotnet 命令。
*你打算执行 .NET Core 程序，但 dotnet-install 不存在。
*你打算运行全局工具，但在路径上找不到名称前缀为 dotnet 的可执行文件。
 
 解决：打开CMD，输入：
dotnet tool install -g dotnet-ef
    2、问题
The EF Core tools version '3.1.0' is older than that of the runtime '3.1.2'. Update the tools for the latest features and bug fixes.
解决：需要更新EF Core tools版本，CMD中执行：
dotnet tool update -g dotnet-ef
    3、问题
It was not possible to find any compatible framework version
The framework 'Microsoft.NETCore.App', version '3.1.2' was not found.
- The following frameworks were found:
2.1.9 at [C:\Program Files\dotnet\shared\Microsoft.NETCore.App]
2.1.15 at [C:\Program Files\dotnet\shared\Microsoft.NETCore.App]
3.1.1 at [C:\Program Files\dotnet\shared\Microsoft.NETCore.App]
You can resolve the problem by installing the specified framework and/or SDK.
The specified framework can be found at:
- https://aka.ms/dotnet-core-applaunch?framework=Microsoft.NETCore.App&framework_version=3.1.2&arch=x64&rid=win10-x64
解决：到最后提供的网址下载SDK安装
    4、问题
No database provider has been configured for this DbContext. A provider can be configured by overriding the DbContext.OnConfiguring method or by using AddDbContext on the application service provider. If AddDbContext is used, then also ensure that your DbContext type accepts a DbContextOptions<TContext> object in its constructor and passes it to the base constructor for DbContext.
解决：需要在网站目录执行
    5、问题
More than one DbContext was found. Specify which one to use. Use the '-Context' parameter for PowerShell commands and the '--context' parameter for dotnet commands.
解决：如果有多个DBContext，需要指定迁移哪个DBContext。如：
dotnet ef migrations add InitialCreate -c DBContext名称
    6、问题
Your target project 'Do.TmsApi' doesn't match your migrations assembly 'Do.Models'. Either change your target project or change your migrations assembly.
Change your migrations assembly by using DbContextOptionsBuilder. E.g. options.UseSqlServer(connection, b => b.MigrationsAssembly("Do.TmsApi")). By default, the migrations assembly is the assembly containing the DbContext.
Change your target project to the migrations project by using the Package Manager Console's Default project drop-down list, or by executing "dotnet ef" from the directory containing the migrations project.
解决：如果DBContext和启动程序不在一个程序集，需要指定要迁移的程序集。代码中添加要迁移的程序集名称：
options.UseSqlServer(connection, b => b.MigrationsAssembly("Do.TmsApi"))
 

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


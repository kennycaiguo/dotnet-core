# dotnet-core
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


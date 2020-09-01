using Microsoft.SqlServer.Management.IntegrationServices;
using System.Data.SqlClient;
using System;
using Microsoft.SqlServer.Dts.Runtime;
 
namespace test
{
    class Program
    {

        static void Main(string[] args)
        {
            // Variables
            string targetServerName = ".";
            string folderName = "C:\\Users\\admin\\source\\repos\\SSIS Excel";
            string projectName = "SSIS Excel";
            string packageName = "ReadAndParseOlineData.dtsx";

            // Create a connection to the server
            string sqlConnectionString = "Data Source=" + targetServerName +
                ";Initial Catalog=DPADemoDb;Integrated Security = true;";
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionString);

            // Create the Integration Services object
            IntegrationServices integrationServices = new IntegrationServices(sqlConnection);

            // Get the Integration Services catalog
            Catalog catalog = integrationServices.Catalogs["SSISDB"];

            // Get the folder
            CatalogFolder folder = catalog.Folders[folderName];

            // Get the project
            ProjectInfo project = folder.Projects[projectName];

            // Get the package
            PackageInfo package = project.Packages[packageName];

            // Run the package
            package.Execute(false, null);

        }
        //  void MM(string[] args)
        //{
        //    string pkgLocation;
        //    Package pkg;
        //    Application app;
        //    DTSExecResult pkgResults;

        //    pkgLocation =@"C:\Program Files\Microsoft SQL Server\100\Samples\Integration Services" +  @"\Package Samples\CalculatedColumns Sample\CalculatedColumns\CalculatedColumns.dtsx";
        //    app = new Application();
        //    pkg = app.LoadPackage(pkgLocation, null);
        //    pkgResults = pkg.Execute();

        //    Console.WriteLine(pkgResults.ToString());
        //    Console.ReadKey();
        //}
    }

}

namespace EFCoreTestDeploy.Data.Helper;

public static class SqlHelper
{
    public static string GetDbPathEf()
    {
        return Path.Combine(FileSystem.AppDataDirectory, "SqlDBTest_EF.db3");
    }
}
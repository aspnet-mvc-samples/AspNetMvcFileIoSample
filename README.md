# AspNetMvcFileIoSample
Read/Write file access sample

プロジェクト直下の App_Data フォルダ内に hoge.txt という名前のファイルを作成するサンプルです。
通常の .NET アプリケーションと同様に StreamWriter を用いてファイル書込を行っています。

## コード抜粋
```csharp
string filepath = Server.MapPath("~/App_Data/hoge.txt");
using (var fout = new StreamWriter(filepath, true))
{
    fout.WriteLine("---");
    fout.WriteLine("DateTime: " + DateTime.Now.ToString());
    fout.WriteLine("Path: " + filepath);
    fout.WriteLine("");
}
```

## コード抜粋前後
```csharp
public ActionResult Index()
{
    string dirpath = Server.MapPath("~/App_Data");
    string filepath = Server.MapPath("~/App_Data/hoge.txt");

    // Check and create directory
    string dirinfo = "";
    if (!Directory.Exists(dirpath))
    {
        dirinfo += "Directory not found: " + dirpath + "\n";

        // Create
        Directory.CreateDirectory(dirpath);
        dirinfo += "Created directory.\n";
    }
    else{
        dirinfo += "Directory already exists: " + dirpath + "\n";
    }
    ViewBag.DirInfo = dirinfo;

    // Write file (append)
    using (var fout = new StreamWriter(filepath, true))
    {
        fout.WriteLine("---");
        fout.WriteLine("DateTime: " + DateTime.Now.ToString());
        fout.WriteLine("Path: " + filepath);
        fout.WriteLine("");
    }

    // Read file
    using (var fin = new StreamReader(filepath))
    {
        ViewBag.FileInfo = fin.ReadToEnd();
    }

    // Remove file if reach the limit
    if (new FileInfo(filepath).Length > 1000)
    {
        System.IO.File.Delete(filepath);
    }

    return View();
}
```

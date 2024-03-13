# ![avalonia-white-purple](https://github.com/c3n9/Avalonia-Samples/assets/108518693/ca9608fa-12f0-4260-ab52-5463b32ab82d) Avalonia projects and test different functions.
**These projects were developed as part of the learning process for Avalonia and PostgreSQL.**
## Projects

- [CRUD](https://github.com/c3n9/Avalonia-Samples/tree/CRUD): This project focuses on basic CRUD (Create, Read, Update, Delete) operations using Avalonia and PostgreSQL.
- [ChitChat](https://github.com/c3n9/Avalonia-Samples/tree/ChitChat): ChitChat is a project showcasing chat functionality developed with Avalonia and PostgreSQL. This system is designed to support the transmission of messages between individual employees and
groups of employees.
- [Hospital](https://github.com/c3n9/Avalonia-Samples/tree/Hospital): Hospital provides a comprehensive view of hospital wards, allowing you to efficiently manage patient occupancy. With our intuitive drag-and-drop feature, you can seamlessly move patients between words (drag&drop).

**Feel free to explore each project for more details and contributions.**


## ![elephant](https://github.com/c3n9/Avalonia-Samples/assets/108518693/b046124a-db97-469e-b438-3813e70b28da) To connect our PostgreSQL database to an Avalonia project


We need to install the following packages in the Avalonia project:

<details>
<summary>Microsoft.EntityFrameworkCore.Design</summary>
  
To install Microsoft.EntityFrameworkCore.Design package using **.NET CLI**, run the following command:

```bash
dotnet add package Microsoft.EntityFrameworkCore.Design --version 9.0.0-preview.2.24128.4
```

To install Microsoft.EntityFrameworkCore.Design package using **Package Manager**, run the following command:

```bash
NuGet\Install-Package Microsoft.EntityFrameworkCore.Design -Version 9.0.0-preview.2.24128.4
```

</details>

<details>
<summary>Npgsql.EntityFrameworkCore.PostgreSQL</summary>
  
To install Npgsql.EntityFrameworkCore.PostgreSQL package using **.NET CLI**, run the following command:

```bash
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --version 9.0.0-preview.1
```

To install Npgsql.EntityFrameworkCore.PostgreSQL package using **Package Manager**, run the following command:

```bash
NuGet\Install-Package Npgsql.EntityFrameworkCore.PostgreSQL -Version 9.0.0-preview.1
```

</details>

This command is used for reverse engineering PostgreSQL databases and automatically generating model classes based on the existing database schema.

```powershell
dotnet ef dbcontext scaffold "Host=0.0.0.0;Username=postgres;Password=password;Database=DataBaseName" Npgsql.EntityFrameworkCore.PostgreSQL --output-dir <Folder where you want to generate classes>
```
To overwrite existing classes, use the --force option.

```powershell
dotnet ef dbcontext scaffold "Host=0.0.0.0;Username=postgres;Password=password;Database=DataBaseName" Npgsql.EntityFrameworkCore.PostgreSQL --output-dir <Folder where you want to generate classes> --force
```

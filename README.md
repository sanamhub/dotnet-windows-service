# 🎗️ .NET Windows Service Template

A minimal and clean template to help you create a Windows Service in .NET.

---

## 🚀 Getting Started

### 1. Clone the Repository

```sh
git clone https://github.com/sanamhub/dotnet-windows-service.git
cd dotnet-windows-service
```

### 2. Open the Project

- **With VS Code**

  ```sh
  code .
  ```

- **Or with Visual Studio (if installed)**
  Open `WindowsService.sln` directly.

### 3. Modify the Worker

Edit the `Worker.cs` file to implement your service logic.

---

## 🧪 Run in Console Mode (For Testing)

```sh
dotnet run
```

Logs will appear in the terminal while running in console mode.

---

## ⚙️ Publish and Install as a Windows Service

### 1. Publish the Project

```sh
dotnet publish -c Release -o ./publish
```

The output will be located in the `publish` folder.

### 2. Install the Service (Run CMD as Administrator)

```sh
sc.exe create MyService binPath= "C:\path\to\your\project\publish\WindowsService.exe"
```

> [!IMPORTANT]
> 🛑 Replace the path with your actual publish folder path.

---

## 🧹 Uninstalling the Service

```sh
sc.exe delete MyService
```

---

> [!NOTE]
>
> - Always run the command prompt as **Administrator** when installing or uninstalling the service.
> - You can manage the service using `services.msc` (Start, Stop, Restart).
> - Customize logging, interval, or behavior inside `Worker.cs`.

---

<div align="center">
  <samp>
    <h3 align="center">
        ════ ⋆★⋆ ════
        <br>
        "Happy Coding 👨‍💻"
    </h3>
  </samp>
</div>

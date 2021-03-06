# net-core-react-starter-app

A Program to getting Started with Net Core, React App and Host it as a service.

Clone this repo:

```shell
git clone https://github.com/gmzdev/net-core-react-starter-app.git
cd net-core-react-starter-app
```

Build the project:

```shell
dotnet restore
dotnet build
```

Run for Development:

```shell
dotnet run -f netcoreapp2.1
```

Publish:

```shell
dotnet publish -c Release -f net461 -r win7-x64
```

Create a Service:

```shell
sc create <SERVICE_NAME> binPath= <PATH_TO_SERVICE_EXECUTABLE>
sc start  <SERVICE_NAME>
```

Check the service:

```shell
sc query <SERVICE_NAME>
```

Remove the service:

```shell
sc delete <SERVICE_NAME>
```
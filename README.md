# Aegis Derm Backend

# Overview
Aegis Derm Backend is a robust backend service designed to support the Aegis Derm application. It provides essential functionalities such as user authentication, data management, and API endpoints to facilitate seamless interaction with the frontend application.
By frontend, we refer to the Aegis Derm mobile application, as well as the Web application.

# Features
- User Authentication: Secure login and registration using JWT tokens.
- Data Management: Efficient handling of user data, including storage and retrieval.
- API Endpoints: RESTful API endpoints for various operations.

# Project Structure
- `src/`: Contains the source code for the backend service.
- `tests/`: Contains unit and integration tests.

For this project we use the SQL Server database. This database does not run in every environment(Operating System). Bearing that in mind, we have created a docker-compose file that will run the database in a container. This way, we can ensure that the database will run in every environment.

## Getting Started with Docker (MacOS):
1. **Install Docker**: If you haven't already, download and install Docker from [Docker's official website](https://www.docker.com/products/docker-desktop).
   1. If you prefer, you can also install Docker via Homebrew:
      ```bash
      brew install --cask docker
      ```
2. **Docker Image**: Pull the SQL Server Docker image by running the following command in your terminal:
   ```bash
   docker pull postgres:latest
   ```
3. **User Secrets Explanation**: Once this is a dotnet project, we use **User Secrets** to store sensitive information such as connection strings. To set up User Secrets, navigate to the project directory and run:
   ```bash
   dotnet user-secrets init
   ```
   This command will create a `UserSecretsId` in your `.csproj` file, that is basically the hash directory in which you should create your `secrets.json`.<br>
   *Bear in mind that this command only creates the hash, it does not create the actual secrets file. So if you just try to access the secrets, you will get an error saying that the file does not exist.
   If you want to see this file, **you must first set a value to the secrets file in order to actually create it**. Then you can use the `Go > Go to Folder` tool from mac and check in the `~/.microsoft/usersecrets` folder*.<br>
   To set a value to the secrets.json file, you can either use the command line:<br><br>
   `dotnet user-secrets set "KeyNameYouWant" "KeyValueYouWant"`<br><br>
   or you can manually create the `secrets.json` file in the `~/.microsoft/usersecrets/{UserSecretsId}` folder and add your secrets in JSON format, like this:
   ```json
   {
     "ExampleOfAKey": "ExampleValueOfAKey"
   }
   ```
    #### Dotnet Secrets Sheet Code:
      - Create the User Secrets:<br>`dotnet user-secrets init`<br><br>
      - Set a Key via Terminal/CLI:<br>`dotnet user-secrets set "YourKeyName" "YourKeyValue"`<br><br>
      - List all you User Secrets:<br>`dotnet user-secrets list`<br><br>
      - Remove an inputted data from your secrets.json:<br>`dotnet user-secrets remove "ConnectionStrings:RedisConnection`<br><br>
      - Deletes everything within the secrets.json file(the file still exists, but empty):<br>`dotnet user-secrets clear`<br><br>

4. **Set Up Environment Variables**: Create a `secrets.json` file in the User Secrets directory and add the following environment variables:
   ```bash
    dotnet user-secrets init
    dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Host=localhost;Port=5432;Database=AegisDermDb;Username=sa;Password=YourStrong!Passw0rd;"
    ```
5. **Run Docker Container**: <br><br>
   First execute:<br>
   ```
   export DB_PASSWORD=$(dotnet user-secrets list | grep -o 'Password=[^;]*' | cut -d'=' -f2)
   ```
   Then run the following command to start the SQL Server container:
   ```
   docker run -d \
   --name aegis_derm_postgres \
   -e POSTGRES_PASSWORD=$DB_PASSWORD \
   -e POSTGRES_DB=AegisDermDb \
   -e POSTGRES_USER=sa \
   -p 5432:5432 \
   -v postgres-data:/var/lib/postgresql/data \
   postgres
   ```
   This command will start the SQL Server container in detached mode.<br><br>

### How to access the database in the docker:

`docker exec -it aegis_derm_postgres psql -U sa -d AegisDermDb`

### Some base Postgres commands:
- List all databases: `\l`
- Connect to a database: `\c database_name`
- List all tables: `\dt`
- Describe a table: `\d table_name`
- Exit psql: `\q`
- Run SQL command: `SELECT * FROM table_name;`
- Create a new database: `CREATE DATABASE database_name;`

## Setting Up DBeaver 🦫:
1. **Install DBeaver**: Download and install DBeaver from [DBeaver's official website](https://dbeaver.io/download/).
2. **Create a New Connection**:
3. Open DBeaver and click on the "New Database Connection" button (or go to Database > New Database Connection).
4. **Select PostgreSQL**: In the list of database types, select "PostgreSQL" and click "Next".
5. **Enter Connection Details**:
    - Host: `localhost`
    - Port: `5432`
    - Database: `AegisDermDb`
    - Username: `sa`
    - Password: `@egisD&rm123`
    - (Optional) Save the password if you want DBeaver to remember it.
    - Click "Test Connection" to ensure everything is set up correctly.
    - Click "Finish" to create the connection.

<details>
  <summary>Docker Initial Steps 🐳</summary>

#### List all local images
`docker images`

#### List only image IDs
`docker images -q`

#### Remove a specific image
`docker rmi image_name`

#### Remove image by ID
`docker rmi 1a2b3c4d5e6f`

#### Force removal (even if containers are using it)
`docker rmi -f image_name`

#### Run container in interactive mode
`docker run -it ubuntu bash`

#### Run container in background (detached)
`docker run -d nginx`

#### Run with custom name
`docker run --name my_container nginx`

#### Run with port mapping
`docker run -p 8080:80 nginx`

#### Explanation: Host port 8080 → Container port 80

#### Run with environment variables
`docker run -e POSTGRES_PASSWORD=password123 postgres`

#### Run with volume
`docker run -v /host/path:/container/path ubuntu`

#### List running containers
`docker ps`

#### List all containers (including stopped)
`docker ps -a`

#### List only container IDs
`docker ps -q`

#### Stop a container
`docker stop name_or_id`

#### Start a stopped container
`docker start name_or_id`

#### Restart a container
`docker restart name_or_id`

#### Remove a container
`docker rm name_or_id`

#### Force remove running container
`docker rm -f name_or_id`

#### Execute command in running container
`docker exec -it container_name bash`

#### Execute single command
`docker exec container_name ls -la`

#### Copy file from host to container
`docker cp file.txt container_name:/destination/path`

#### Copy file from container to host
`docker cp container_name:/path/file.txt ./`

</details>
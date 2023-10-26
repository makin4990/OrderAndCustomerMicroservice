## How to Install

1. **Configuration:**

   - Open the project and configure the following settings:
     - Set the URL, username, and password in the project. RabbitMQ, MongoDB, and PostgreSQL are located on a remote machine. If required, I can share the necessary connection details (URLs, usernames, and passwords).

2. **Docker Compose:**

   - Open your command-line terminal (cmd) and navigate to the directory where the `docker-compose.yml` file is located.

   - Run the following command to start the project components in detached mode (background):

     ```bash
     docker-compose up -d
     ```

   This command will initiate the setup of the project's services and dependencies.

3. **Accessing APIs:**

   Once the services are up and running, you can access the following APIs:

   - **ApiGateway**: Accessible at [http://localhost:7100](http://localhost:7100)
   - **CustomerApi**: Accessible at [http://localhost:7101](http://localhost:7101)
   - **OrderingApi**: Accessible at [http://localhost:7102](http://localhost:7102)

4. **Service Discovery (Consul):**

   The Consul service will be available at [http://localhost:8500](http://localhost:8500) for service discovery and management.

Please ensure that the necessary configurations are correctly set, and the remote services (RabbitMQ, MongoDB, and PostgreSQL) are accessible from your local environment before running the `docker-compose` command.

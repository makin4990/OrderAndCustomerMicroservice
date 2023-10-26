# OrderAndCustomerMicroservice
A microservice which use cqrs  postresql mongo  masstransit rabbitmq and hangfire 


## how to install
  1-) set url, username and password in the project. Rabbitmq, Mongo, and PostgresSql are located in remote machine. In case required i can share the paswords.
  2-) open cmd and set directory where docker-compose.yml is located.
  2-) run "docker-compose.yml up -d" commnad
  4-) ApiGateway will run on port:7100
      CustomerApi will run on port:7101
      OrderingApi will run on port:7102
      Consul will run on port:8500

# Apache Kafka proof of concept

This repository contains a proff of concept for using Kafka to apply event driven microservices architecture between two microservices.

## Composition

Basically the solution is composed by:

* Two microservices: Orders and Customers.
* One Kafka Server for event driving.
* MongoDB for persisting the data and Mongo-express for web managing it (not certainly needed but I'm that cool).

The system is dockerized so make sure you have installed Docker in your machine and in mi personal case I had to enable the experimental features on the Docker Deamon to run it.

One class to take in count is the KafkaConsumer.cs, which has a KafkaEventConsumerConfiguration with a dictionary of event handlers identified by the event name. This configuration also has a list of topics that the consumer is going to subscribe. So the way this KafkaConsumer works is by executing a background infinite loop (until the cancellation token is requested) pulling data from the Kafka broker. Once the broker has new messages for the consumer, it deserializes the message into a Kafka Message (which is composed by a string with the event name and another string with the event data) and gets the event handler with the name from the options dictionary and executes its "Handle" method with the event data.

## Steps to make it work

Use Postman (recommended) or whatever you want to make the requests:

1. Run the docker compose on visual studio.
2. Make a request to create a new customer.
3. Make a request to create a new order.
4. Go to the VS output logs and check that all microservices involved have written something correct.

The repository also includes a **Kafka.POC.postman_collection.json** file that can be imported and used with Postman to make the requests to test the system.

## How does it work?

When a new order in the Orders microservice is created it sends to its Kafka producer on the "ReactiveMicroservices" topic an event saying that an order has been created. Then, the Customers microservice's Kafka consumer recieves that event in real time so the microservice handles it and validates if the user that has made that order has credit enough to make it so it marks an OrderValidatedEvent as valid or not and sends it to its Kafka producer on the "ReactiveMicroservices" topic. The Orders microservice's Kafka consumer will recieve the event and will handle it in a way or another depending on if the order has been validated or not (it could update the order as shipped or as cancelled depending on the validation done in the Customers microservice but for this POC it is ok).

Here is a graphic I have created to explain the flow of the system when a new order is created:

![alt text](https://github.com/riftgg/Kafka.POC/raw/master/Kafka_diagram.png)
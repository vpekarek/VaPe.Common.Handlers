# Common.Handlers

## Four options how to manipulate wiht data

All options are asynchronous (non thread blocking), however only the `Message` is executed in the background.

To use `Event`, `Query` and `Command` you need to inject `IDispatcher` and call corresponding method on it.

To use `Message` you need to inject `IMessageBroker` and call the `PublishAsync` method.

### Event
The event is a reaction to a situation that occurs in the system. 
Raising an event we are notifying the listeners that something happened (eg. the user is authorized, data is exported, password is changed).

#### Definition:
- Event is a `class` implementing `IEvent` interface.
- Event listener is a `class` implementing `IEventListener<TEvent>` interface.
- Event doesn't know anything about the listeners.
- Event listeners are executed unordered.
- Event listeners are executed asynchronously, but the program waits for the execution of all the listeners.

### Query
The query is a request that expects some data to be returned.
The caller doesn't need to know anything about the query handler, because there is a loose coupling.

The query is mostly used in the controllers when we need to return some data to the caller. 

**A query never modifies data.**

#### Definition
- Query is a `class` implementing `IQuery<TResponse>` interface.
- Query handler is a `class` implementing `IQueryHandler<in IQuery, TResponse>` interface.
- Query doesn't know anything about the query handler.
- There is exactly one query handler for each query.
- Query handler is executed and the application waits for the result of the handler.

### Command
The command is a request from one part of an application to execute code in the different places of the application, with loose coupling.
Executing command, we are telling application to "do some work".

The commands are used when we want to execute something, but don't expect anything as a return value.

#### Definition
- Comman is a `class` implementing `ICommand` interface.
- Command handler is a `class` implementing `ICommandHandler<TCommand>` interface.
- Command don't know anything about the command handler.
- There is exactly one command handler for each command.
- Command handler is executed asynchronously, but the program waits for the execution.

### Message (asynchronous event)
Messages are implemented the same way as **Event** but are executed in true asynchronous way.
That means, that the program doesn't wait for the event to be processed. The event is raised - stored in some persistant place - and the execution continues.
Different part of the application than handle the execution of the event listeners.

Currently, the `BackgroundService` is used for the execution. It can be switched for RabbitMQ, Redis Pub/Sub, etc.
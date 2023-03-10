# CQRS_Pattern_NET6

#What is CQRS Pattern?

Command Query Responsibility Segregation (CQRS) is first described in the book Object-Oriented Software Construction by Bertrand Meyer. It is an arcitectural pattern that separates the read and writes operations of your application. Read operations are called Queries and write operations are called Commands. 

Queries –  The operations that return data but don’t change the application state.

Commands – The operations that change the application state and return no data. These are the methods that have side effects within the application. 

The CQRS pattern is a great expression of the single responsibility principle. It states that we should have separate models for Queries and Commands because in the real-world application the requirements for read operations are normally different than the write operations. If you are using separate models, then you can handle complex scenarios without worrying about disturbing the other operations. Without this separation, we can easily end up with domain models that are full of state, commands, and queries and harder to maintain over time

#Pros of CQRS Pattern


CQRS pattern offers the following advantages:

Separation of Concern – We have separate models for read and write operations which not only gives us flexibility but also keeps our models simple and easy to maintain. Normally, the write models have most of the complex business logic whereas the read models are normally simple.
Better Scalability – Reads operations often occur way more than writes so keeping queries separate than commands makes our applications highly scalable. Both read and write models can be scaled independently even by two different developers or teams without any fear of breaking anything.
Better performance – We can use a separate database or a fast cache e.g. Redis for read operations which can improve application performance significantly.
Optimized Data Models – The read models can use a schema or pre-calculated data sources that are optimized for queries. Similarly, the write models can use a schema that is optimized for data updates.
Cons of CQRS Pattern
There are also some challenges of implementing the CQRS pattern which include:

Added Complexity – The basic idea of CQRS is simple but in bigger systems sometimes it increases the complexity especially in scenarios where read operations also need to update data at the same time. Complexity also increased if we also introduce concepts like Event Sourcing.

Eventual consistency– If we use a separate database for read and a separate database for write then synchronizing the read data become a challenge. We have to make sure we are not reading the stale data.

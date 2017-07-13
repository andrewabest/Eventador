DDD, CQRS, and ORMs - Finding the sweet spot
--------------------------------------------

DDD helps us tame the inherent complexity of non-trivial software development. CQRS supports the same goal goal, while providing other tangible benefits like optimisation and scalability. ORMs take the heavy lifting out of transalting between the worlds of Object Oriented software and relational persistance layers.

Finding the sweet spot between these approaches can be a challenge. Some popular ORMs (cough Entity Framework cough) place burdensome constraints on DDD implementations, causing them to bend and contort in wierd and less-than-wonderful ways. They can also be sub-optimal for CQRS concerns. CQRS at times is viewed as introducing unwarranted overhead and complexity where it isn't needed.

In this session we will explore a less-than-wonderful domain model that utilises a single ORM for all of its concerns, and then look at how we can break it apart utilizing a CQRS approach that employs the best tool for the job for each concern, while keeping complexity to a minimum.
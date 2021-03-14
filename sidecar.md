
# Distributed Design Pattern

## Foundational patterns

### Health Probe pattern
Health Probe dictates that every container should implement specific APIs to help the platform observe and manage the application in the healthiest way possible. 

### Predictable Demands pattern
Every container should declare its resource profile and stay confined to the indicated resource requirements. 

### Automated Placement patterns
Influence workload distribution in a multi-node cluster.


## Single-Node Patterns

In addition to this resource isolation, there are other reasons to split your single-node application into multiple containers.
### Init Container pattern
- https://medium.com/bb-tutorials-and-thoughts/kubernetes-learn-init-container-pattern-7a757742de6b

### The Sidecar Pattern
- https://devblogs.microsoft.com/dotnet/collecting-net-core-linux-container-cpu-traces-from-a-sidecar-container/
- https://www.youtube.com/watch?v=1v8SXWXxGvM&ab_channel=DevMentors
- https://blog.tonysneed.com/2019/10/13/enable-ssl-with-asp-net-core-using-nginx-and-docker/
- https://thecloudblog.net/post/tracing-and-profiling-a-net-core-application-on-azure-kubernetes-service-with-a-sidecar-container/

### Ambassadors

### Adapters

## Serving Patterns

### Replicated Load-Balanced Services
### Sharded Services
### Scatter/Gather
### Functions and Event-Driven Processing
### Ownership Election

## Batch Computational Patterns

### Work Queue Systems
### Event-Driven Batch Processing
### Coordinated Batch Processing



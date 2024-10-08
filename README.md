# Expense Tracker Project

## Overview
> ### _This repository contains a "comprehensive expense tracking solution developed as <font color="blue"><u>one of my hobby project</u></font>."_

One of my hobby project architected and deployed on my Linux server. Built on clean architecture as 3 microservices, it features a .NET 8 WebAPI containerized with Docker. Supports distributed logging and tracing with Seq, metrics with Prometheus and Grafana. A Flutter app logs expenses and manages categories. The system uses RabbitMQ for messaging, Redis for caching, MongoDB for persistence, EF Core as ORM, Firebase for notifications, Azure EntraAD for auth & Blob storage for archrivals.

<hr/>

# Technology Stack

## Frontend

| Application Type     | Name    | Version | Details           |
|----------------------|---------|---------|-------------------|
| Web      | React   | 18.2.0  | SPA               |
| Mobile   | Flutter | 3.22    | Android & iOS     |

<hr/>

## Backend

### Backend Architecture
The project follows a microservices architecture with some components hosted in Azure. 

![Expence Tracker v1 Service Architecture drawio](https://github.com/user-attachments/assets/cda79f7d-aadc-428d-9622-bfd8c9c10f98)

| Component             | Name       | Version             | Details                                                       |
|-----------------------|------------|---------------------|---------------------------------------------------------------|
| API                   | .NET       | 8                   | Alpine Chiseled Ubuntu image (aspnet:8.0-jammy-chiseled) on Docker |
| Database              | MongoDB    | 8.0 Preview · 2023  | on Docker                                                     |
| Distributed Caching   | Redis      | 7.0                 | on Docker                                                     |
| Distributed Messaging | RabbitMQ   | 3.13.6              | on Docker                                                     |
| Logging & Tracing     | Seq        | 2023.1              | on Docker                                                     |
|                       | Serilog    |                     | Local logging (file)                                          |
| Metrics & Monitoring  | Grafana    | 11.0.0-preview      | on Docker                                                     |
|                       | Prometheus | 2.53.1 / 2024-07-10 | on Docker                                                     |
| Cloud Storage & Archival  | Azure Blob Storage    |      | Azure                                                     |
| Authentication  | Entra AD    |       | Azure                                                     |
| CDNs  | Azure CDN   |       | Azure                                                     |

<hr/>

### Demo Video

<center>
<iframe width="296" height="628" src="https://www.youtube.com/embed/4neii_v1MAQ" title="Demo" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share" referrerpolicy="strict-origin-when-cross-origin"></iframe>
</center>

### Demo Screenshots

|                        |                        |                        |
|------------------------|------------------------|------------------------|
| ![Image 1](https://github.com/user-attachments/assets/836e89a2-dbea-4f1d-a03f-e0f5268a0850) | ![Image 2](https://github.com/user-attachments/assets/3e5889d8-728d-451b-988b-da44a5309842) | ![Image 3](https://github.com/user-attachments/assets/23f33a41-de92-4a4a-a287-9eecf3a0b90f) |
| ![Image 4](https://github.com/user-attachments/assets/d185de12-ae4d-40b1-8330-1dcd04d9dbf1) | ![Image 5](https://github.com/user-attachments/assets/1af7a03e-c7f6-4c55-a2dc-6227304712ed) | ![Image 6](https://github.com/user-attachments/assets/6f1f6240-c527-487b-9cce-aa64cc5f2b83) |

## Deployment Environment

### Docker Instances

![image](https://github.com/user-attachments/assets/998f1a15-5f85-46b9-b3de-217cebbe34fa)

| Property                | Value                              |
|-------------------------|------------------------------------|
| Operating System        | Ubuntu 23.04                       |
| Kernel                  | Linux 6.2.0-39-generic             |
| Architecture            | x86-64                             |
| Memory                  | 8GB Physical                       |
| CPU(s)                  | 2 vCPUs                            |
| Model name              | AMD EPYC 7543P 32-Core Processor   |
<hr/>

# Other Missilenius Tools Involved

## K6 Performance Tests
- The API has been load tested using K6
- Capable of serving 1000 requests in parallel
- Utilizes distributed caching for improved response times

## Azure Cloud Integration
- Azure EntraAD: Handles authentication and authorization
- Azure Blob Storage: Planned for long-term data archival (cold storage)

## Monitoring and Observability
- Seq: Centralized logging and tracing with OpenTelemetry integration
- Prometheus & Grafana: Real-time monitoring of API traffic and system metrics

## Development Practices
- Build on Clean Architecture principle
- Containerised

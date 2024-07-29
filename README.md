# Expense Tracker Project

## Overview
> ### _This repository contains a "comprehensive expense tracking solution developed as one of my hobby project."_

<hr/>

## Technology Stack

### Frontend

| Application Type     | Name    | Version | Details           |
|----------------------|---------|---------|-------------------|
| Web Application      | React   | 18.2.0  | SPA               |
| Mobile Application   | Flutter | 3.22    | Android & iOS     |

<hr/>

### Backend

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

<hr/>

### Deployment Environment

| Property                | Value                              |
|-------------------------|------------------------------------|
| Operating System        | Ubuntu 23.04                       |
| Kernel                  | Linux 6.2.0-39-generic             |
| Architecture            | x86-64                             |
| Memory                  | 8GB Physical                       |
| CPU(s)                  | 2 vCPUs                            |
| Model name              | AMD EPYC 7543P 32-Core Processor   |



- Core Framework: .NET 9
- Containerization: Docker (Chiselled Ubuntu container on Alpine)
- Database: MongoDB (primary data storage)
- Caching: Redis (distributed caching)
- Logging: Seq (integrated with OpenTelemetry)
- Monitoring: Prometheus and Grafana
- Authentication: Azure EntraAD
- Storage: Azure Blob Storage (cold archive for data archival)
- Load Testing: K6 (capable of handling 1000 parallel requests)

## Architecture
The project follows a microservices architecture with some components hosted in Azure. 

[Insert architecture diagram here]

Key Components:
1. API Gateway
2. Authentication Service
3. Expense Tracking Service
4. Reporting Service
5. Data Archival Service

## Performance
- The API has been load tested using K6
- Capable of serving 1000 requests in parallel
- Utilizes distributed caching for improved response times

## Cloud Integration
- Azure EntraAD: Handles authentication and authorization
- Azure Blob Storage: Planned for long-term data archival (cold storage)

## Monitoring and Observability
- Seq: Centralized logging and tracing with OpenTelemetry integration
- Prometheus & Grafana: Real-time monitoring of API traffic and system metrics

## Development Practices
- Microservices Architecture: Ensures scalability and modularity
- Containerization: Docker for consistent deployment across environments
- Version Control: Git (hosted on GitHub)
- API Testing: Postman collections for endpoint validation

## Future Enhancements
1. Implement machine learning for expense prediction
2. Integrate with financial institutions for automatic transaction import
3. Develop a budgeting feature with alerts
4. Implement multi-currency support

## Setup and Deployment
1. Clone the repository
2. Set up Azure services (EntraAD and Blob Storage)
3. Configure MongoDB and Redis instances
4. Build and deploy Docker containers for backend services
5. Deploy frontend applications (web and mobile)
6. Configure Prometheus and Grafana for monitoring

## Conclusion
This project demonstrates proficiency in:
- Full-stack development (React, Flutter, .NET)
- Cloud services integration (Azure)
- Microservices architecture
- Containerization and orchestration
- Database management (MongoDB, Redis)
- API development and testing
- Performance optimization and load testing
- Monitoring and observability implementation

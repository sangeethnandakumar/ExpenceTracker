# Expense Tracker Project

## Overview
This repository contains a comprehensive expense tracking solution developed as a hobby project. It demonstrates proficiency in full-stack development, cloud services integration, and microservices architecture.

## Technology Stack

### Frontend
1. Web Application
   - Framework: React
   - Type: Single Page Application (SPA)

2. Mobile Application
   - Framework: Flutter
   - Platforms: Android & iOS

   Key Features:
   - Track Page: Real-time expense entry and visualization
   - Records Page: Historical data display and analysis
   - Category Edit Page: Dynamic expense categorization
   - Category Create Page: Custom category management

### Backend
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

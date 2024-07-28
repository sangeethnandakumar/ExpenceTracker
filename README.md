# FrontEnd
Web and mobile frontends are currenty planned. The web will be a React based SPA and mobile app will be build on Flutter

## Flutter Mobile App (Android & iOS)

### 1. Track Page
![WhatsApp Image 2024-07-28 at 20 56 57_3fb871e4](https://github.com/user-attachments/assets/705c16b9-b3bc-400a-b2e2-1c2ce37e8bf7)

### 2. Records Page
![WhatsApp Image 2024-07-28 at 20 56 58_bc640cca](https://github.com/user-attachments/assets/2a6c71f0-e237-4f0a-9440-b27f5308b39b)

### 3. Categry Edit Page
![WhatsApp Image 2024-07-28 at 20 56 58_86b32f16](https://github.com/user-attachments/assets/9232e4e3-3b9d-4aa4-b289-6cdc3cc33824)

### 4. Category Create Page
![WhatsApp Image 2024-07-28 at 20 56 58_34cb92b4](https://github.com/user-attachments/assets/05d75eb1-95fc-4301-ad5e-399fda0e2f87)

# BackEnd
Backend is powered by .NET 9 running on a Chiselled Ubuntu container (Alpine) running on Docker inside my Linux server connected to MongoDB for data persistance. Additionaly Redisis used for distributed caching, Seq for logs and tracing (Open telemetry integrated), Promethius and Grafana is also integrated for motinoting net traffic.

Authentication will be handled using Azure EntraAD. Azure blob storage (cold archive) is planned to be used for data archival

The API load testing has been done using K6 with the server capable of serving 1000 req parally at a time.

The architecture of the entire setup utilizes microservices while part of the components are hosted in Azure. 

## Backend Microservice Architecture
![Expence Tracker v1 Service Architecture drawio](https://github.com/user-attachments/assets/85cff855-3150-4ae2-a3e8-d1e383dfc3be)

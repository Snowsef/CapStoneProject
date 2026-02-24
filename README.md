# Sentry Web - Network Vulnerability Dashboard

**Video Demonstration:** 

## Project Summary
Sentry Web is a browser-based network utility designed to allow system administrators to perform port scans, log security audits, and track vulnerabilities from a centralized dashboard. Unlike traditional ephemeral command-line scanners, this application persists scan data to a Microsoft SQL Server database using Entity Framework Core, allowing security teams to track the open-port history of a network over time. 

Built with C# and ASP.NET Core MVC, the application prioritizes defense-in-depth security. It features strict Regular Expression (Regex) input validation to prevent command injection, and utilizes ASP.NET Core Identity with Role-Based Access Control (RBAC) to ensure that only authenticated administrators can initiate network scans or manipulate audit records.

## Technologies Used
* **Backend:** C#, ASP.NET Core MVC 8.0
* **Database:** Microsoft SQL Server (LocalDB), Entity Framework Core
* **Frontend:** HTML5, Razor Syntax, Bootstrap CSS
* **Security:** ASP.NET Core Identity, Controller-level Authorization, Regex Sanitization

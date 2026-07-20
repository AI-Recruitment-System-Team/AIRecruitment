# AI Recruitment System

## Overview

AI Recruitment System is a smart recruitment platform that helps recruiters manage job postings, review candidates, and analyze applications using AI-powered tools.

The system allows candidates to create profiles, upload resumes, apply for jobs, and receive application updates. Recruiters can manage job openings, review applicants, and use AI analysis to assist in candidate evaluation.

## Architecture

The project follows an N-Tier Architecture:

- **API**: Presentation layer (ASP.NET Core Web API)
- **BLL**: Business logic layer
- **DAL**: Data access layer (Entity Framework Core)
- **Domain**: Entities and domain models

## Technologies

### Backend
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- ASP.NET Identity
- JWT Authentication

### AI Integration
- Separate AI service built using Python
- Pretrained models exposed through APIs

## Main Features

### Candidate
- Register and manage profile
- Upload multiple resume versions
- Manage skills
- Apply for jobs

### Recruiter
- Create and manage job postings
- Review candidate applications
- View AI-generated candidate analysis

### AI Features
- Resume analysis
- Skill extraction
- Candidate-job matching

## Current Status

🚧 Project is currently under development.

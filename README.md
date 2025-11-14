# UM Calendar API

**Live API:** [https://um-calendar-backend.azurewebsites.net/](https://um-calendar-backend.azurewebsites.net/)

A REST API that provides University of Maribor (FOV) calendar data in `.ics` format. Automatically updates daily using GitHub Actions to keep schedules current.

## What It Does

This service:
- **Fetches** calendar data from the UM FOV website automatically via GitHub Actions
- **Serves** calendar files through a secure REST API
- **Updates** every day at 3 AM UTC using scheduled workflows
- **Authenticates** with JWT tokens to protect access

Perfect for building calendar apps, integrations, or automations for UM students and staff.

## API Endpoints

| Endpoint | Description | Auth Required |
|----------|-------------|---------------|
| `GET /generate-token/` | Generate JWT token | API Key (header) |
| `GET /names` | List all available calendars | JWT Bearer token |
| `GET /cal/{name}` | Get specific calendar file | JWT Bearer token |
| `GET /health` | Health check | None |
| `GET /swagger` | API documentation | None |

## Quick Start

### Authentication

**1. Get a JWT token:**
```bash
curl -H "X-API-Key: YOUR_API_KEY" \
  https://um-calendar-backend.azurewebsites.net/generate-token/
```

**2. Use the token to access calendars:**
```bash
# List all calendars
curl -H "Authorization: Bearer YOUR_TOKEN" \
  https://um-calendar-backend.azurewebsites.net/names

# Get a specific calendar
curl -H "Authorization: Bearer YOUR_TOKEN" \
  https://um-calendar-backend.azurewebsites.net/cal/01---1-letnik-VS-Informacijski-sistemi-Redni
```

## How It Works

1. **Python scraper** downloads `.ics` calendar files from UM FOV website daily
2. **GitHub Actions** commits the updated calendars automatically
3. **Azure** deploys the new calendars to the API
4. **API** serves the calendars through authenticated endpoints

All updates happen automatically—no manual intervention needed!

## Technologies

- **Backend:** ASP.NET Core 9.0
- **Scraper:** Python 3.11 (BeautifulSoup4)
- **Auth:** JWT Bearer tokens
- **Automation:** GitHub Actions (daily at 3 AM UTC)
- **Hosting:** Azure App Service

## Local Development

**Requirements:** .NET 9.0 SDK, Python 3.11+

```bash
# Clone and setup
git clone https://github.com/Denotess/um-calendar-backend.git
cd um-calendar-backend

# Create .env file
echo "Jwt__Key=your-dev-key
Jwt__ApiKey=your-api-key
Jwt__Issuer=calendar-api
Jwt__Audience=calendar-api-users" > .env

# Run API
dotnet run
# API available at http://localhost:5000

# Run scraper (optional)
cd scraper
pip install -r requirements.txt
python getFiles.py
```

## Project Structure

```
├── Program.cs                    # API entry point
├── calendars/*.ics              # Calendar files (64 files)
├── scraper/                     # Python scraper
│   ├── getFiles.py             # Downloads calendars
│   └── requirements.txt        # Dependencies
└── .github/workflows/
    ├── main_um-calendar-backend.yml   # Azure deployment
    └── update-calendars.yml           # Daily calendar updates
```

---

**University of Maribor – Faculty of Organizational Sciences**  
Automated calendar service for students and staff

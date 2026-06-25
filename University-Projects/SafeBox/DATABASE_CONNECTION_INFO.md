# Database Connection Information

## Connection String
```
Data Source=DESKTOP-GBH6PR7\SQLEXPRESS;Initial Catalog=SafeBox;Integrated Security=True;Trust Server Certificate=True
```

## Connection Location

### 1. DatabaseHelper.cs (Central Connection Manager)
**Location:** `SafeBox\DataAccessLayer\DatabaseHelper.cs`

This is the **central location** where the connection string is defined. All repositories use this helper class.

**Key Methods:**
- `ConnectionString` - Returns the connection string
- `CreateConnection()` - Creates a new SqlConnection
- `TestConnection()` - Tests if database connection works
- `TestConnection(out string errorMessage)` - Tests connection and returns error message

### 2. All Repositories Use DatabaseHelper

All repositories initialize their connection string from `DatabaseHelper.ConnectionString`:

#### VaultRepository.cs
- **Location:** `SafeBox\DataAccessLayer\VaultRepository.cs`
- **Line 15:** `_connectionString = DatabaseHelper.ConnectionString;`
- **Uses connection in:** 6 methods (Add, GetById, GetByUserId, Delete, GetFileCount, GetTotalSize)

#### FileRepository.cs
- **Location:** `SafeBox\DataAccessLayer\FileRepository.cs`
- **Line 15:** `_connectionString = DatabaseHelper.ConnectionString;`
- **Uses connection in:** 6 methods (Add, GetById, GetByVaultId, GetAllFiles, Delete, GetTotalStorageSize)

#### UserRepository.cs
- **Location:** `SafeBox\DataAccessLayer\UserRepository.cs`
- **Line 15:** `_connectionString = DatabaseHelper.ConnectionString;`
- **Uses connection in:** 11 methods (Add, GetById, GetByUsername, GetAll, Search, Update, ActivateUser, DeactivateUser, GetActiveUserCount, GetInactiveUserCount, GetTotalUserCount)

#### ActivityLogRepository.cs
- **Location:** `SafeBox\DataAccessLayer\ActivityLogRepository.cs`
- **Line 14:** `_connectionString = DatabaseHelper.ConnectionString;`
- **Uses connection in:** 3 methods (Add, GetRecentByUserId, GetAllByUserId)

#### AuditRepository.cs
- **Location:** `SafeBox\DataAccessLayer\AuditRepository.cs`
- **Line 14:** `_connectionString = DatabaseHelper.ConnectionString;`
- **Uses connection in:** 5 methods (Add, GetAll, GetTotalUsers, GetDeactivatedUserCount, GetPasswordResetCount)

#### SharedAccessRepository.cs
- **Location:** `SafeBox\DataAccessLayer\SharedAccessRepository.cs`
- **Line 15:** `_connectionString = DatabaseHelper.ConnectionString;`
- **Uses connection in:** 2 methods (Add, GetByFileId)

### 3. Registration Form
- **Location:** `SafeBox\UI\Registration.cs`
- **Line 11:** `string connectionString = SafeBox.DataAccessLayer.DatabaseHelper.ConnectionString;`
- Uses the connection string for user registration

### 4. Connection Test Service
- **Location:** `SafeBox\Services\DatabaseConnectionService.cs`
- Provides methods to test database connectivity:
  - `TestConnection()` - Returns true/false
  - `TestConnectionWithMessage()` - Shows message box with connection status
  - `GetConnection()` - Returns a new SqlConnection

### 5. Application Startup
- **Location:** `SafeBox\Program.cs`
- **Line 33:** Tests database connection on application startup
- Automatically checks connection when application starts

## How to Test Connection

### Method 1: Programmatically
```csharp
bool connected = SafeBox.Services.DatabaseConnectionService.TestConnection();
```

### Method 2: With Message Box
```csharp
SafeBox.Services.DatabaseConnectionService.TestConnectionWithMessage();
```

### Method 3: Direct Test
```csharp
bool connected = SafeBox.DataAccessLayer.DatabaseHelper.TestConnection();
```

## Connection Usage Summary

- **Total Repository Methods Using Connection:** 33 methods
- **Repositories:** 6 (VaultRepository, FileRepository, UserRepository, ActivityLogRepository, AuditRepository, SharedAccessRepository)
- **Forms Using Connection:** 1 (Registration)
- **Connection Test:** Automatic on startup + manual test available

## All Connection Points

Every database operation in the application uses:
```csharp
using (SqlConnection con = new SqlConnection(_connectionString))
{
    con.Open();
    // ... database operations
}
```

Where `_connectionString` comes from `DatabaseHelper.ConnectionString` in all repositories.

USE master;
GO

IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'SafeBox')
BEGIN
    CREATE DATABASE SafeBox;
END
GO

USE SafeBox;
GO

-- Users Table
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Users' AND xtype='U')
BEGIN
    CREATE TABLE Users (
        user_id INT IDENTITY(1,1) PRIMARY KEY,
        user_username NVARCHAR(50) NOT NULL UNIQUE,
        email NVARCHAR(100) NOT NULL UNIQUE,
        password_hash NVARCHAR(255) NOT NULL,
        status NVARCHAR(10) DEFAULT '1', -- '1' = Active, '0' = Inactive
        created_at DATETIME DEFAULT GETDATE(),
        update_last_login DATETIME NULL
    );
END
GO

-- Admin Table
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Admin' AND xtype='U')
BEGIN
    CREATE TABLE Admin (
        admin_id INT IDENTITY(1,1) PRIMARY KEY,
        admin_username NVARCHAR(50) NOT NULL UNIQUE,
        email NVARCHAR(100) NOT NULL UNIQUE,
        password_hash NVARCHAR(255) NOT NULL,
        status NVARCHAR(10) DEFAULT '1',
        created_at DATETIME DEFAULT GETDATE(),
        update_last_login DATETIME NULL
    );
    
    -- Default Admin (Password: admin123 - ideally should be hashed)
    INSERT INTO Admin (admin_username, email, password_hash)
    SELECT 'admin', 'admin@safebox.com', 'admin123'
    WHERE NOT EXISTS (SELECT 1 FROM Admin WHERE admin_username = 'admin');
END
GO

-- Vaults Table
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Vaults' AND xtype='U')
BEGIN
    CREATE TABLE Vaults (
        vault_id INT IDENTITY(1,1) PRIMARY KEY,
        user_id INT NOT NULL,
        vault_name NVARCHAR(100) NOT NULL,
        description NVARCHAR(255) NULL,
        created_at DATETIME DEFAULT GETDATE(),
        CONSTRAINT FK_Vaults_Users FOREIGN KEY (user_id) REFERENCES Users(user_id) ON DELETE CASCADE
    );
END
GO

-- Files Table
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Files' AND xtype='U')
BEGIN
    CREATE TABLE Files (
        file_id INT IDENTITY(1,1) PRIMARY KEY,
        vault_id INT NOT NULL,
        user_id INT NOT NULL,  -- Redundant but fast for queries
        file_name NVARCHAR(255) NOT NULL,
        file_path NVARCHAR(500) NOT NULL, -- Path on disk
        file_size BIGINT NOT NULL,
        is_encrypted BIT DEFAULT 1,
        uploaded_at DATETIME DEFAULT GETDATE(),
        CONSTRAINT FK_Files_Vaults FOREIGN KEY (vault_id) REFERENCES Vaults(vault_id) ON DELETE CASCADE,
        CONSTRAINT FK_Files_Users FOREIGN KEY (user_id) REFERENCES Users(user_id)
    );
END
GO

-- Activity Logs Table
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='ActivityLogs' AND xtype='U')
BEGIN
    CREATE TABLE ActivityLogs (
        log_id INT IDENTITY(1,1) PRIMARY KEY,
        user_id INT NULL,
        action NVARCHAR(255) NOT NULL,
        details NVARCHAR(MAX) NULL,
        timestamp DATETIME DEFAULT GETDATE(),
        CONSTRAINT FK_ActivityLogs_Users FOREIGN KEY (user_id) REFERENCES Users(user_id) ON DELETE SET NULL
    );
END
GO
